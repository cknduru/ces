﻿using System;

namespace CES2020.Models
{
    public class TelstarForbindelse : Forbindelse
    {
        public TelstarForbindelse()
        {
            this.ForbindelsesType = Enums.Enums.Forbindelsestype.Telstar;
        }

        public DateTime? Udløbsdato { get; set; }

        public int AntalSegmenter { get; set; }
    }
}