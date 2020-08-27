using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CES2020.Models.Enums
{
    public class Enums
    {
        public enum GodsType
        {
            ANI,
            EXP,
            CAU,
            REF
        } //Live animals, Explosive items, Cautious parcels, Refrigerated goods

        public enum Forbindelsestype
        {
            Telstar, 
            Oceanic, 
            EastIndia
        }
        public enum Sikkerhedsrolle
        {
            Admin,
            PrisAdmin,
            Booker
        }
}
}