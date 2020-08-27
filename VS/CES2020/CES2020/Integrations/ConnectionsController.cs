using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using CES2020.Integrs.dto;
using CES2020.Models;
using CES2020.Models.Enums;

namespace CES2020.Integrs
{
    public class ConnectionsController : ApiController
    {
        // POST api/connections
        public List<ForbindelseDto> Post([FromBody]Forsendelse value)
        {
            /* test data
             ConnectionsIntegration oc = new ConnectionsIntegration();
            List<ForbindelseDto> x = oc.GetOceanicRoutes();
            x.AddRange(oc.GetEastIndiaTradingRoutes());*/

            Forsendelse f = new Forsendelse
            {
                Forsendelsesdato = value.Forsendelsesdato,
                Fra = value.Fra,
                Til = value.Til,
                Godstype = value.Godstype,
                PakkeDimensioner = value.PakkeDimensioner,
                Rekommanderet = value.Rekommanderet,
                Vaegt = value.Vaegt
            };

            // do something and return data
            List<ForbindelseDto> brds = new List<ForbindelseDto>();
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