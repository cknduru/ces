using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CES2020.Models
{
    public class BeregnetRute
    {
        public float SamletPris { get; set; }
        public int SamletTid { get; set; }
        public int Andel { get; set; }
        public Forsendelse Forsendelse { get; set; }
        public int Id { get; set; }

    }
}