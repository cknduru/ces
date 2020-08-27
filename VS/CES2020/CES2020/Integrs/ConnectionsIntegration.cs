using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Net.Http;
using CES2020.Integrs.dto;
using CES2020.Models;

namespace CES2020.Integrs
{
    public class ConnectionsIntegration
    {
        private static readonly HttpClient client = new HttpClient();

        public List<BeregnetRute> GetOceanicRoutes()
        {
            /*var values = new Dictionary<string, string>
            {
                { "thing1", "hello" },
                { "thing2", "world" }
            };

            var content = new FormUrlEncodedContent(values);

            var response = await client.PostAsync("http://www.example.com/recepticle.aspx", content);

            var responseString = await response.Content.ReadAsStringAsync();*/

            List<BeregnetRute> brds = new List<BeregnetRute>();

            // do something and return data
            BeregnetRute brd = new BeregnetRute();
            brd.Andel = 32;
            brd.Forsendelse = new Forsendelse();
            brd.SamletPris = 2.3f;
            brd.SamletTid = 32;
            brds.Add(brd);

            return brds;
        }

        public List<BeregnetRute> GetEastIndiaTradingRoutes()
        {
            /*var values = new Dictionary<string, string>
            {
                { "thing1", "hello" },
                { "thing2", "world" }
            };

            var content = new FormUrlEncodedContent(values);

            var response = await client.PostAsync("http://www.example.com/recepticle.aspx", content);

            var responseString = await response.Content.ReadAsStringAsync();*/

            List<BeregnetRute> brds = new List<BeregnetRute>();

            // do something and return data
            BeregnetRute brd = new BeregnetRute();
            brd.Andel = 32;
            brd.Forsendelse = new Forsendelse();
            brd.SamletPris = 2.3f;
            brd.SamletTid = 32;
            brds.Add(brd);

            return brds;
        }
    }
}