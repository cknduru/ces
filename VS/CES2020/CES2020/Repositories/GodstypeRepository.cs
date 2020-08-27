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
    public class GodstypeRepository : BaseRepository
    {
        private readonly DatabaseContext _db;

        public GodstypeRepository()
        {
            this._db = base.GetContext();
        }

        public void AddMulitple(IEnumerable<Godstype> godstyper)
        {
            _db.Godstyper.InsertAllOnSubmit(godstyper);

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

        public Godstype Get(Enums.GodsType godstype)
        {
            return _db.Godstyper.FirstOrDefault(g => g.Type == godstype);
        }

        public IEnumerable<Godstype> GetAll()
        {
            return _db.Godstyper.ToList();
        }
    }
}