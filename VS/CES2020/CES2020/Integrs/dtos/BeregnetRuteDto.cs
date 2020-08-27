using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using CES2020.Models;

namespace CES2020.Integrs.dto
{
    public class BeregnetRuteDto
    {
        public String To { get; set; }
        public String From { get; set; }
        public int Duration { get; set; }
        public int Price { get; set; }
    }
}