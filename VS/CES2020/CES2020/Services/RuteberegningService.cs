using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
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

        public RuteberegningService()
        {
            this.byRepository = new ByRepository();
            this.telstarForbindelseRepository = new TelstarForbindelseRepository();
            this.connectionsIntegration = new ConnectionsIntegration();
        }

        public IEnumerable<Forbindelse> GetPossibleForbindelser(Forsendelse forsendelse)
        {
            var oceanicForbindelser = ConvertToForbindelser(connectionsIntegration.GetOceanicRoutes(), Enums.Forbindelsestype.Oceanic);
            var eastIndiaForbindelser = ConvertToForbindelser(connectionsIntegration.GetEastIndiaTradingRoutes(), Enums.Forbindelsestype.EastIndia);

            var telstarForbindelser = telstarForbindelseRepository.GetAll();
            var konfiguration = new Konfiguration();

            foreach (var forbindelse in telstarForbindelser)
            {
                forbindelse.ComputePricesAndTimes(konfiguration);
            }
            
            var possibleForbindelser = telstarForbindelser.Where(f => f.Udløbsdato == null || f.Udløbsdato > forsendelse.Forsendelsesdato).Select(f => f as Forbindelse);
            
            possibleForbindelser = possibleForbindelser.Concat(oceanicForbindelser);
            possibleForbindelser = possibleForbindelser.Concat(eastIndiaForbindelser);

            return possibleForbindelser;
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

        public ShortestPathResult ShortestPath(List<Forbindelse> forbindelser, List<By> byer, int fra, int til)
        {
            var graph = new Graph<int, string>();
            foreach (By by in byer)
            {
                graph.AddNode(by.Id);
            }

            foreach (Forbindelse forbindelse in forbindelser)
            {
                graph.Connect((uint)forbindelse.Fra.Id, (uint)forbindelse.Til.Id, forbindelse.Tid, "Tid");
            }
            ShortestPathResult result = graph.Dijkstra((uint)fra, (uint)til); //result contains the shortest path

            return result;

        }

        
    }
}
