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
    public class TelstarForbindelseRepository : BaseRepository
    {
        private readonly DatabaseContext db;

        TelstarForbindelseRepository()
        {
            this.db = base.GetContext();
        }

        public void AddForbindelse(TelstarForbindelse forbindelse)
        {
            var dbForbindelse = new DbTelstarForbindelse()
            {
                FraId = forbindelse.Fra.Id,
                TilId = forbindelse.Til.Id,
                Pris = forbindelse.Pris,
                Tid = forbindelse.Tid,
                ForbindelsesType = forbindelse.ForbindelsesType,
                Udløbsdato = forbindelse.Udløbsdato,
                AntalSegmenter = forbindelse.AntalSegmenter
            };

            db.TelstarForbindelser.InsertOnSubmit(dbForbindelse);

            try
            {
                db.SubmitChanges();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }
    }
}