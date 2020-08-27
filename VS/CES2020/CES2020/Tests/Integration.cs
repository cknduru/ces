using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using CES2020.Integrs;
using CES2020.Models;
using CES2020.Models.Enums;
using NUnit.Framework;

namespace CES2020.Tests
{        
    public class Integration
    {
        [Test]
        public void ExternalIntegrationsEAShouldDeliverAnyData()
        {
            ConnectionsIntegration ci = new ConnectionsIntegration();
            Forsendelse forsendelse = new Forsendelse();
            forsendelse.Godstype = Enums.GodsType.EXP;
            forsendelse.Vaegt = 12;
            forsendelse.Fra = new By();
            forsendelse.Til = new By();
            forsendelse.PakkeDimensioner = new PakkeDimensioner();
            forsendelse.Rekommanderet = false;

            var ea = ci.GetEastIndiaTradingRoutes(forsendelse);

            Assert.IsNotEmpty(ea);
        }

        [Test]
        public void ExternalIntegrationsOAShouldDeliverAnyData()
        {
            ConnectionsIntegration ci = new ConnectionsIntegration();
            Forsendelse forsendelse = new Forsendelse();
            forsendelse.Godstype = Enums.GodsType.EXP;
            forsendelse.Vaegt = 12;
            forsendelse.Fra = new By();
            forsendelse.Til = new By();
            forsendelse.PakkeDimensioner = new PakkeDimensioner();
            forsendelse.Rekommanderet = false;

            var oi = ci.GetOceanicRoutes(forsendelse);

            Assert.IsNotEmpty(oi);
        }
    }
}