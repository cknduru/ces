using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CES2020.Models
{
    public class RuteManager
    {
        public RuteBeregner RuteBeregner()
        {
            return new RuteBeregner();
        }

        public Konfiguration Konfiguration()
        {
            return new Konfiguration();
        }
    }
}