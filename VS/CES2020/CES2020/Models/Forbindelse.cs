using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CES2020.Models
{
    public class Forbindelse
    {
        public int Id { get; set;}
        public  float Pris { get; set; }
        public int Tid { get; set; }
        public By Fra { get; set;}
        public By Til { get; set; }
        public Enums.Enums.Forbindelsestype ForbindelsesType { get; set; }

}
}