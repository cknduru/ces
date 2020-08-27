using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CES2020.Models
{
    public class Forsendelse
    {
        public By Fra { get; set; }
        public By Til { get; set; }
        public bool Rekommanderet { get; set; }
        public Enums.Enums.GodsType Godstype { get; set; }
        public int Vægt { get; set; }
        public DateTime Forsendelsesdato { get; set; }
        public Pakke_Dimensioner PakkeDimensioner { get; set; }

    }
}