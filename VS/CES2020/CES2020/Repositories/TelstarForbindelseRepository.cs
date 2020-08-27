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
        private readonly DatabaseContext _db;

        public TelstarForbindelseRepository()
        {
            this._db = base.GetContext();
        }

        public void Add(TelstarForbindelse forbindelse)
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

            _db.TelstarForbindelser.InsertOnSubmit(dbForbindelse);

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

        public IEnumerable<TelstarForbindelse> GetAll()
        {
            return _db.TelstarForbindelser.Select(f => new TelstarForbindelse()
            {
                Id = f.Id,
                Fra = _db.Byer.FirstOrDefault(b => b.Id == f.FraId),
                Til = _db.Byer.FirstOrDefault(b => b.Id == f.TilId),
                AntalSegmenter = f.AntalSegmenter,
                Udløbsdato = f.Udløbsdato,
            }).AsEnumerable();
        }
    }
}