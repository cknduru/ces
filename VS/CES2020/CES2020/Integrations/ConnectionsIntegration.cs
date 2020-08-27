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
        private static readonly String oceanicSiteResource = "/api/connections";


        private IRestResponse GetExternalRoutes(String baseurl, String resource, String json)
        {
            var client = new RestClient(baseurl);
            var request = new RestSharp.RestRequest(resource, RestSharp.Method.POST) { RequestFormat = RestSharp.DataFormat.Json }
                .AddBody(json);

            return client.Execute(request);
        }

        public List<ForbindelseDto> GetOceanicRoutes()
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
            String res = GetExternalRoutes(oceanicSiteBase, oceanicSiteResource, json).Content;
            ForbindelseDto dto = new ForbindelseDto();

            try
            {
                // trim backets from start and end of JSON
                dto = JsonConvert.DeserializeObject<ForbindelseDto>(res.Substring(1, res.Length - 2));
            }
            catch (Exception ex)
            {
            }

            brds.Add(dto);

            return brds;
        }

        public List<ForbindelseDto> GetEastIndiaTradingRoutes()
        {
            List<ForbindelseDto> brds = new List<ForbindelseDto>();

            // do something and return data
            ForbindelseDto brd = new ForbindelseDto();
            brd.Duration = 5;
            brd.From = "Congo";
            brd.To = "Niger";
            brd.Price = 41;

            brds.Add(brd);

            return brds;
        }
    }
}