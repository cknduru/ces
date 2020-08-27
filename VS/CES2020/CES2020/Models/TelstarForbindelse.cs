using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CES2020.Models
{
    public class TelstarForbindelse : Forbindelse
    {
        public DateTime? Udløbsdato { get; set; }
        public int AntalSegmenter { get; set; }

    }
}