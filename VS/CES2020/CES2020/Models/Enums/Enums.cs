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
            DEFAULT,
            ANI,
            EXP,
            CAU,
            REF,
            WEP
        } //Live animals, Explosive items, Cautious parcels, Refrigerated goods, Weapons

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