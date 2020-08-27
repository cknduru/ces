using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using CES2020.Integrs.dto;
using CES2020.Models;
using CES2020.Models.Enums;
using CES2020.Repositories;
using CES2020.Services;

namespace CES2020.Integrs
{
    public class InternalConnectionsController : ApiController
    {
        // POST api/internalconnections
        public List<BeregnetRuteInternalDto> Post([FromBody]Forsendelse value)
        {
            List<BeregnetRuteInternalDto> brds = new List<BeregnetRuteInternalDto>();

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
            BeregnetRuteInternalDto brd = new BeregnetRuteInternalDto();
            brd.Forsendelse = f;
            brd.SamletTid = 18;
            brd.Andel = 43;
            brd.SamletPris = 321.5f;
            brds.Add(brd);

            return brds;
        }
    }
}