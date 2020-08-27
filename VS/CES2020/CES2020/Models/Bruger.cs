using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CES2020.Models
{
    public class Bruger
    {
        public int Id {get; set; }
        public string Email {get; set; }
        public string Kodeord { get; set; }
        public List<Sikkerhedsrolle> Rolle {get; set;}
    }
}