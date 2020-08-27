using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.Linq;
using System.Linq;
using System.Web;
using CES2020.Models;
using CES2020.Models.Enums;

namespace CES2020.Repositories
{
    public class KonfigurationRepository : BaseRepository
    {
        private readonly DatabaseContext _db;

        public KonfigurationRepository()
        {
            this._db = base.GetContext();
        }

        public Konfiguration Get()
        {
            return _db.Konfigurations.First();
        }
    }
}