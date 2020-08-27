using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CES2020.Models
{
    public class Sikkerhedsrolle
    {
        public Enums.Enums.Sikkerhedsrolle Rolle { get; set; }
        public bool Aktiv { get; set; }
    }
}