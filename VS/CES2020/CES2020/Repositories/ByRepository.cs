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
    public class ByRepository : BaseRepository
    {
        private readonly DatabaseContext db;

        public ByRepository()
        {
            this.db = base.GetContext();
        }

        public void Add(By by)
        {

            db.Byer.InsertOnSubmit(by);

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

        public void AddMultiple(IEnumerable<By> byer)
        {
            db.Byer.InsertAllOnSubmit(byer);

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

        public int GetIdFromName(string name)
        {
            var id = db.Byer.Where(b => b.Name == name).Select(b => b.Id).FirstOrDefault();

            if (id == default)
            {
                throw new InvalidOperationException($"City with name {name} not found");
            }

            return id;
        }
    }
}