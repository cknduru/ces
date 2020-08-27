﻿using System;
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

        public List<BeregnetRuteDto> GetOceanicRoutes()
        {
            /*var values = new Dictionary<string, string>
            {
                { "thing1", "hello" },
                { "thing2", "world" }
            };

            var content = new FormUrlEncodedContent(values);

            var response = await client.PostAsync("http://www.example.com/recepticle.aspx", content);

            var responseString = await response.Content.ReadAsStringAsync();*/

            List<BeregnetRuteDto> brds = new List<BeregnetRuteDto>();

            // do something and return data
            BeregnetRuteDto brd = new BeregnetRuteDto();
            brd.Duration = 5;
            brd.From = "Congo";
            brd.To = "Niger";
            brd.Price = 41;

            brds.Add(brd);

            return brds;
        }

        public List<BeregnetRuteDto> GetEastIndiaTradingRoutes()
        {
            /*var values = new Dictionary<string, string>
            {
                { "thing1", "hello" },
                { "thing2", "world" }
            };

            var content = new FormUrlEncodedContent(values);

            var response = await client.PostAsync("http://www.example.com/recepticle.aspx", content);

            var responseString = await response.Content.ReadAsStringAsync();*/

            List<BeregnetRuteDto> brds = new List<BeregnetRuteDto>();

            // do something and return data
            BeregnetRuteDto brd = new BeregnetRuteDto();
            brd.Duration = 5;
            brd.From = "Congo";
            brd.To = "Niger";
            brd.Price = 41;

            brds.Add(brd);

            return brds;
        }
    }
}