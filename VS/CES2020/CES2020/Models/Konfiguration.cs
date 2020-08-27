using System;
using System.Collections.Generic;
using System.Data.Linq.Mapping;
using System.Linq;
using System.Web;

namespace CES2020.Models
{
    [Table(Name = "KONFIGURATION")]
    public class Konfiguration
    {
        [Column(Name = "ID", IsPrimaryKey = true, IsDbGenerated = true)]
        public int Id { get; set; }

        [Column(Name = "REKOMMANDERETTILLAEG")]
        public float RekommanderetTillaeg { get; set; }

        [Column(Name = "RABAT")]
        public int Rabat { get; set; }

        [Column(Name = "TELSTARSEGMENTPRIS")]
        public float TelstarSegmentPris { get; set; }

        [Column(Name = "MAXVAEGT")]
        public int MaxVaegt { get; set; }

        [Column(Name = "TELSTARSEGMENTTID")]
        public int TelstarSegmentTid { get; set; }
    }
}