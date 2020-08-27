using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using CES2020.Integrs;
using CES2020.Models;
using NUnit.Framework;

namespace CES2020.Tests
{        
    public class Integration
    {
        [Test]
        public void ExternalIntegrationsEAShouldDeliverAnyData()
        {
            ConnectionsIntegration ci = new ConnectionsIntegration();

            var ea = ci.GetEastIndiaTradingRoutes(new Forsendelse());

            Assert.IsNotEmpty(ea);
        }

        [Test]
        public void ExternalIntegrationsOAShouldDeliverAnyData()
        {
            ConnectionsIntegration ci = new ConnectionsIntegration();

            var oi = ci.GetOceanicRoutes(new Forsendelse());

            Assert.IsNotEmpty(oi);
        }
    }
}