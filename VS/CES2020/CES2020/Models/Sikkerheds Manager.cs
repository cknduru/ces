using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CES2020.Models
{
    public class Sikkerheds_Manager
    {
        public void CheckBruger(Bruger bruger)
        { }

        public Bruger OpretBruger(Bruger bruger)
        {
            return new Bruger();
        }
        public void SletBruger(Bruger bruger) 
        { }
    }
}