using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using CES2020.Integrations.dtos;
using CES2020.Integrs.dto;
using CES2020.Models;
using CES2020.Models.Enums;
using CES2020.Services;

namespace CES2020.Integrs
{
    public class ConnectionsController : ApiController
    {
        // POST api/connections
        public List<ForbindelseDto> Post([FromBody]ForsendelseDto value)
        {
            var ruteberegningService = new RuteberegningService();

            return ruteberegningService.GetForbindelseDtos(value);
        }
    }
}