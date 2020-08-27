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
        private static readonly String oceanicSiteBase = "http://wa-tlpl.azurewebsites.net";
        private static readonly String eastIndiaSiteBase = "http://wa-eitpl.azurewebsites.net";
        private static readonly String resource = "/api/connections";


        private IRestResponse GetExternalRoutes(String baseurl, String resource, String json)
        {
            var client = new RestClient(baseurl);
            var request = new RestSharp.RestRequest(resource, RestSharp.Method.POST) { RequestFormat = RestSharp.DataFormat.Json }
                .AddBody(json);

            return client.Execute(request);
        }

        public List<ForbindelseDto> GetOceanicRoutes(ForbindelseDto forbindelse)
        {
            List<ForbindelseDto> brds = new List<ForbindelseDto>();
            Forsendelse f = new Forsendelse();

            f.Forsendelsesdato = DateTime.Now;
            By b = new By();
            By b1 = new By();
            b.Name = forbindelse.From;
            b1.Name = forbindelse.To;

            f.Fra = b;
            f.Til = b1;
            f.Godstype = Enums.GodsType.EXP;
            f.PakkeDimensioner = new PakkeDimensioner();
            f.Rekommanderet = false;
            f.Vaegt = 15;

            var json = JsonConvert.SerializeObject(f);
            String res = GetExternalRoutes(oceanicSiteBase, resource, json).Content;
            ForbindelseDto dto = new ForbindelseDto();

            try
            {
                // trim backets from start and end of JSON
                dto = JsonConvert.DeserializeObject<ForbindelseDto>(res.Substring(1, res.Length - 2));
                brds.Add(dto);
            }
            catch (Exception ex)
            {
            }

            return brds;
        }

        public List<ForbindelseDto> GetEastIndiaTradingRoutes()
        {
            List<ForbindelseDto> brds = new List<ForbindelseDto>();
            Forsendelse f = new Forsendelse();

            f.Forsendelsesdato = DateTime.Now;
            f.Fra = new By();
            f.Til = new By();
            f.Godstype = Enums.GodsType.EXP;
            f.PakkeDimensioner = new PakkeDimensioner();
            f.Rekommanderet = false;
            f.Vaegt = 15;

            var json = JsonConvert.SerializeObject(f);
            String res = GetExternalRoutes(eastIndiaSiteBase, resource, json).Content;
            ForbindelseDto dto = new ForbindelseDto();

            try
            {
                // trim backets from start and end of JSON
                dto = JsonConvert.DeserializeObject<ForbindelseDto>(res);
                brds.Add(dto);
            }
            catch (Exception ex)
            {
            }

            return brds;
        }
    }
}