using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using CES2020.Models;

namespace CES2020.Integration.dto
{
    public class BeregnetRuteDto
    {
        public float SamletPris { get; set; }
        public int SamletTid { get; set; }
        public int Andel { get; set; }
        public Forsendelse Forsendelse { get; set; }
    }
}