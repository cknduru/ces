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
            return _db.Konfigurations.Single();
        }

        public void Set(Konfiguration konfiguration)
        {
            _db.Konfigurations.InsertOnSubmit(konfiguration);

            try
            {
                _db.SubmitChanges();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        public void SetTelstarSegmentPris(double telstarSegmentPris)
        {
            _db.Konfigurations.Single().TelstarSegmentPris = telstarSegmentPris;

            try
            {
                _db.SubmitChanges();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }
    }
}