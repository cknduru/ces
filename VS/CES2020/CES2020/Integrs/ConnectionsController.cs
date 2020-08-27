using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using CES2020.Integrs.dto;
using CES2020.Integrs.dto;
using CES2020.Models;
using CES2020.Models.Enums;

namespace CES2020.Integration
{
    public class ConnectionsController : ApiController
    {
        // POST api/rute
        public BeregnetRuteDto Post([FromBody]Forsendelse value)
        {
            Forsendelse f = new Forsendelse
            {
                Forsendelsesdato = value.Forsendelsesdato,
                Fra = value.Fra,
                Til = value.Til,
                Godstype = value.Godstype,
                PakkeDimensioner = value.PakkeDimensioner,
                Rekommanderet = value.Rekommanderet,
                Vægt = value.Vægt
            };

            // do something and return data
            BeregnetRuteDto brd = new BeregnetRuteDto();
            brd.Andel = 32;
            brd.Forsendelse = f;
            brd.SamletPris = 2.3f;
            brd.SamletTid = 32;

            return brd;
        }
/*
        public Forsendelse Get()
        {
            Forsendelse f = new Forsendelse();
            f.Forsendelsesdato = DateTime.Now;
            f.Fra = new By();
            f.Til = new By();
            f.Godstype = Enums.GodsType.EXP;
            f.PakkeDimensioner = new PakkeDimensioner();
            f.Rekommanderet = true;
            f.Vægt = 4;

            return f;
        }*/
    }
}