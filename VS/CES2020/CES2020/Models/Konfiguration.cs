using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CES2020.Models
{
    public class Konfiguration
    {
        public float RekommanderetTillaeg { get; set; }
        public int Rabat { get; set; }
        public float TelstarSegmentPris { get; set; }
        public int MaxVaegt { get; set; }
        public int TelstarSegmentTid { get; set; }
    }
}