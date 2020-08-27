using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Web.Script.Serialization;
using CES2020.Integrations.dtos;
using CES2020.Integrs.dto;
using CES2020.Models;
using CES2020.Models.Enums;
using Newtonsoft.Json;
using RestSharp;
using RestSharp.Authenticators;

namespace CES2020.Integrs
{
    public class ConnectionsIntegration
    {
        private static readonly HttpClient client = new HttpClient();
        private static readonly string oceanicSiteBase = "http://wa-tlpl.azurewebsites.net";
        private static readonly string eastIndiaSiteBase = "http://wa-eitpl.azurewebsites.net";
        private static readonly string resource = "/api/connections";


        private IRestResponse GetExternalRoutes(string baseurl, string resource, string json)
        {
            var client = new RestClient(baseurl);
            var request = new RestRequest(resource, Method.POST) { RequestFormat = DataFormat.Json }.AddBody(json);

            return client.Execute(request);
        }

        public List<ForbindelseDto> GetOceanicRoutes(Forsendelse forsendelse)
        {
            return GetRoutes(forsendelse, oceanicSiteBase);
        }

        public List<ForbindelseDto> GetEastIndiaTradingRoutes(Forsendelse forsendelse)
        {
            return GetRoutes(forsendelse, eastIndiaSiteBase);
        }

        public List<ForbindelseDto> GetRoutes(Forsendelse forsendelse, string siteBase)
        {
            var forbindelser = new List<ForbindelseDto>();
            var json = JsonConvert.SerializeObject(ConvertToForsendelseDto(forsendelse));
            var res = GetExternalRoutes(siteBase, resource, json).Content;

            try
            {
                // trim backets from start and end of JSON
                var dtos = JsonConvert.DeserializeObject<List<ForbindelseDto>>(res);
                forbindelser.AddRange(dtos);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }

            return forbindelser;
        }


        public ForsendelseDto ConvertToForsendelseDto(Forsendelse forsendelse)
        {
            return new ForsendelseDto()
            { 
                GoodsTypeIds = new string[] { GetGodstypeName(forsendelse.Godstype) },
                Weight = forsendelse.Vaegt,
                Length = forsendelse.PakkeDimensioner.Laengde,
                Width = forsendelse.PakkeDimensioner.Bredde,
                Height = forsendelse.PakkeDimensioner.Hoejde,
                DeliveryDate = forsendelse.Forsendelsesdato
            };
        }

        private string GetGodstypeName(Enums.GodsType godstype)
        {
            switch (godstype)
            {
                case Enums.GodsType.REF:
                    return "REF";
                case Enums.GodsType.ANI:
                    return "ANI";
                case Enums.GodsType.CAU:
                    return "CAU";
                case Enums.GodsType.EXP:
                    return "EXP";
                case Enums.GodsType.WEP:
                    return "WEP";
                default:
                    return string.Empty;
            }
        }
    }
}