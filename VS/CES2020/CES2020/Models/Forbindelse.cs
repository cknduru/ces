using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CES2020.Models
{
    public class Forbindelse
    {
        private int id { get; set;}
        private  float pris { get; set; }
        private int tid { get; set; }
        private By fra { get; set;}
        private By til { get; set; }

        public enum _forbindelsestype { Telstar, Oceanic, East_India}

        public _forbindelsestype forbindelsestype { get;}


       
}
}