using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using static CES2020.Models.Enums.Enums;

namespace CES2020.Models
{
    public class Forsendelse
    {
        public By Fra { get; set; }
        public By Til { get; set; }
        public bool Rekommanderet { get; set; }
        public GodsType Godstype { get; set; }
        public int Vaegt { get; set; }
        public DateTime Forsendelsesdato { get; set; }
        public PakkeDimensioner PakkeDimensioner { get; set; }

    }
}