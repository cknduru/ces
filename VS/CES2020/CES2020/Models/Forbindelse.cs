using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using static CES2020.Models.Enums.Enums;

namespace CES2020.Models
{
    public class Forbindelse
    {
        public int Id { get; set;}
        public  float Pris { get; set; }
        public int Tid { get; set; }
        public virtual By Fra { get; set;}
        public virtual By Til { get; set; }
        public Forbindelsestype ForbindelsesType { get; set; }
    }
}