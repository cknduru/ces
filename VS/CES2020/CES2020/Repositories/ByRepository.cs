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

        ByRepository()
        {
            this.db = base.GetContext();
        }

        public void AddBy(By by)
        {

            db.Byer.InsertOnSubmit(new By(){Name = by.Name});

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