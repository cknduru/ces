using System;
using System.Data.Linq.Mapping;
using static CES2020.Models.Enums.Enums;

namespace CES2020.Models
{
    [Table(Name = "TELSTARFORBINDELSE")]
    public class DbTelstarForbindelse
    {
        [Column(Name = "ID", IsPrimaryKey = true, IsDbGenerated = true)]
        public int Id { get; set; }

        [Column(Name = "PRIS")]
        public float Pris { get; set; }

        [Column(Name = "TID")]
        public int Tid { get; set; }

        [Column(Name = "FRA")]
        public int FraId { get; set; }

        [Column(Name = "TIL")]
        public int TilId { get; set; }

        [Column(Name = "FORBINDELSESTYPE")]
        public Forbindelsestype ForbindelsesType { get; set; }

        [Column(Name = "UDLOEBSDATO")]
        public DateTime? Udløbsdato { get; set; }

        [Column(Name = "SEGMENTER")]
        public int AntalSegmenter { get; set; }
    }
}