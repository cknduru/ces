using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using CES2020.Integrations.dtos;
using CES2020.Integrs;
using CES2020.Integrs.dto;
using CES2020.Models;
using CES2020.Models.Enums;
using CES2020.Repositories;
using Dijkstra.NET.Graph;
using Dijkstra.NET.ShortestPath;

namespace CES2020.Services
{
    public class RuteberegningService
    {
        private readonly TelstarForbindelseRepository telstarForbindelseRepository;
        private readonly ConnectionsIntegration connectionsIntegration;
        private readonly ByRepository byRepository;
        private readonly GodstypeRepository godstypeRepository;
        private readonly Konfiguration konfiguration;

        public RuteberegningService()
        {
            this.byRepository = new ByRepository();
            this.telstarForbindelseRepository = new TelstarForbindelseRepository();
            this.connectionsIntegration = new ConnectionsIntegration();
            this.konfiguration = new KonfigurationRepository().Get();
            this.godstypeRepository = new GodstypeRepository();
        }

        public IEnumerable<Forbindelse> GetCombinedForbindelser(Forsendelse forsendelse)
        {
            var oceanicForbindelser = ConvertToForbindelser(connectionsIntegration.GetOceanicRoutes(forsendelse), Enums.Forbindelsestype.Oceanic);
            var eastIndiaForbindelser = ConvertToForbindelser(connectionsIntegration.GetEastIndiaTradingRoutes(forsendelse), Enums.Forbindelsestype.EastIndia);

            var possibleForbindelser = GetPossibleTelstarForbindelser(forsendelse).Select(f => f as Forbindelse);
            possibleForbindelser = possibleForbindelser.Concat(oceanicForbindelser);
            possibleForbindelser = possibleForbindelser.Concat(eastIndiaForbindelser);

            return possibleForbindelser;
        }

        public IEnumerable<TelstarForbindelse> GetPossibleTelstarForbindelser(Forsendelse forsendelse)
        {
            var possibleForbindelser = Enumerable.Empty<TelstarForbindelse>();

            if (forsendelse.Vaegt >= this.konfiguration.MaxVaegt) return possibleForbindelser;

            var telstarForbindelser = telstarForbindelseRepository.GetAll();

            var telstarForb = new List<TelstarForbindelse>();
            foreach (var forbindelse in telstarForbindelser)
            {

                forbindelse.Tid = forbindelse.AntalSegmenter * konfiguration.TelstarSegmentTid;
                forbindelse.Pris = forbindelse.AntalSegmenter * (float)konfiguration.TelstarSegmentPris;
                telstarForb.Add(forbindelse);
            }

            possibleForbindelser = telstarForb.Where(f => f.Udløbsdato == null || f.Udløbsdato > forsendelse.Forsendelsesdato);

            return possibleForbindelser;
        }

        public List<ForbindelseDto> GetForbindelseDtos(ForsendelseDto forsendelseDto)
        {
            var forsendelse = ConvertToForsendelse(forsendelseDto);
            var tillaeg = godstypeRepository.Get(forsendelse.Godstype).Tillaeg;

            return GetPossibleTelstarForbindelser(forsendelse).Select(f => new ForbindelseDto()
            {
                From = f.Fra.Name,
                To = f.Til.Name,
                Price = (int)(f.Pris * tillaeg),
                Duration = f.Tid
            }).ToList();
        }

        public Forsendelse ConvertToForsendelse(ForsendelseDto forsendelse)
        {
            return new Forsendelse()
            {
                Godstype = GetGodsType(forsendelse.GoodsTypeIds.FirstOrDefault()),
                Vaegt = forsendelse.Weight,
                Forsendelsesdato = forsendelse.DeliveryDate,
                PakkeDimensioner = new PakkeDimensioner()
                {
                    Bredde = forsendelse.Width,
                    Hoejde = forsendelse.Height,
                    Laengde = forsendelse.Length
                }
            };
        }

        public Enums.GodsType GetGodsType(string godstypeName)
        {
            switch (godstypeName)
            {
                case "":
                    return Enums.GodsType.DEFAULT;
                case "REF":
                    return Enums.GodsType.REF;
                case "ANI":
                    return Enums.GodsType.ANI;
                case "CAU":
                    return Enums.GodsType.CAU;
                case "EXP":
                    return Enums.GodsType.EXP;
                case "WEP":
                    return Enums.GodsType.WEP;
                default:
                    throw new ArgumentException($"Unknown Godstype {godstypeName}");
            }
        }

        public IEnumerable<Forbindelse> ConvertToForbindelser(IEnumerable<ForbindelseDto> forbindelseDtos, Enums.Forbindelsestype forbindelsestype)
        {
            return forbindelseDtos.Select(f => new Forbindelse()
            {
                Pris = f.Price,
                Tid = f.Duration,
                Fra = new By() { Id = byRepository.GetIdFromName(f.From), Name = f.From },
                Til = new By() { Id = byRepository.GetIdFromName(f.To), Name = f.To },
                ForbindelsesType = forbindelsestype
            });
        }

        public List<BeregnetRute> GetBeregnetRuter(List<Forbindelse> forbindelser, List<By> byer,
            Forsendelse forsendelse)
        {
            var tidBR = ShortestPath(forbindelser, byer, forsendelse, "tid");
            var prisBR = ShortestPath(forbindelser, byer, forsendelse,"pris");
            var blandetBR = ShortestPath(forbindelser, byer, forsendelse, "blandet");
            
            List<BeregnetRute> brList = new List<BeregnetRute>(){tidBR, prisBR, blandetBR};

            return brList;
        }

        public BeregnetRute ShortestPath(List<Forbindelse> forbindelser, List<By> byer, Forsendelse forsendelse, string priority)
        {
            var graph = new Graph<int, string>();
            foreach (By by in byer)
            {
                graph.AddNode(by.Id);
            }

            var priorityVar = 0;

            foreach (Forbindelse forbindelse in forbindelser)
            {
                if (priority is "tid")
                {
                    priorityVar = forbindelse.Tid;
                }
                else if (priority is "pris")
                {
                    priorityVar = (int)forbindelse.Pris;
                }
                else if (priority is "blandet")
                {
                    priorityVar = (int)(0.5*forbindelse.Tid) + (int)(0.5*forbindelse.Pris);
                }
                graph.Connect((uint)forbindelse.Fra.Id, (uint)forbindelse.Til.Id, priorityVar, "");
            }
            ShortestPathResult result = graph.Dijkstra((uint)forsendelse.Fra.Id, (uint)forsendelse.Til.Id); //result contains the shortest path

            var path = result.GetPath().ToList();
            var minForbindelseList = new List<Forbindelse>();
            for (int i = 0; i < path.Count() - 1; i++)
            {
                var matchingForbindelser = forbindelser.Where(f => f.Fra.Id == path[i] && f.Til.Id == path[i + 1]);
                var minForbindelse =
                    matchingForbindelser.FirstOrDefault(m => m.Tid == matchingForbindelser.Select(x => x.Tid).Min());
                minForbindelseList.Add(minForbindelse);
            }

            var beregnetRute = CreateBeregnetRute(minForbindelseList, forsendelse);

            return beregnetRute;

        }

        public BeregnetRute CreateBeregnetRute(List<Forbindelse> forbindelser, Forsendelse forsendelse)
        {
            var andel = Andel(forbindelser);

            var samletTid = SamletTid(forbindelser);

            var tillaeg = godstypeRepository.Get(forsendelse.Godstype).Tillaeg;

            var samletPris = SamletPris(forbindelser) + tillaeg;


            BeregnetRute br = new BeregnetRute()
            {
                Forbindelser = forbindelser,
                Andel = (int)(andel * (1 - konfiguration.Rabat / 100)),
                Forsendelse = forsendelse,
                SamletTid = samletTid,
                SamletPris = samletPris
            };

            return br;
        }

        private float SamletPris(List<Forbindelse> forbindelser)
        {
            var pris = 0.0f;
            foreach (var forbindelse in forbindelser)
            {
                if (forbindelse.ForbindelsesType == Enums.Forbindelsestype.Telstar)
                {
                    pris += forbindelse.Pris * (1 - konfiguration.Rabat / 100);
                }
                else
                {
                    pris += forbindelse.Pris;
                }
            }

            return pris;
        }

        private static int SamletTid(List<Forbindelse> forbindelser)
        {
            return forbindelser.Sum(f => f.Tid);
        }

        private static float Andel(List<Forbindelse> forbindelser)
        {
            float andel = 0.0f;

            foreach (Forbindelse forbindelse in forbindelser)
            {
                if (forbindelse.ForbindelsesType == Enums.Forbindelsestype.Telstar)
                {
                    andel += forbindelse.Pris;
                }
            }

            return andel;
        }


    }
}
