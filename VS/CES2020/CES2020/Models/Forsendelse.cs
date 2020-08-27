using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CES2020.Models
{
    public class Forsendelse
    {
        private By Fra { get; set; }
        private By Til { get; set; }
        private bool Rekommanderet { get; set; }
        private Enums.Enums.GodsType Godstype { get; set; }
        private int Vægt { get; set; }
        private DateTime Forsendelsesdato { get; set; }
        private Pakke_Dimensioner PakkeDimensioner { get; set; }

    }
}