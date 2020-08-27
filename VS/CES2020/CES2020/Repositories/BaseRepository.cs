using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CES2020.Repositories
{
    public class BaseRepository
    {
        private static readonly string connectionString = "Data Source=dbs-tlpl.database.windows.net;Initial Catalog=dbs-tlpl202008;User ID=dbs-tlpl;Password=telStarRox16;Connect Timeout=30;Encrypt=True;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
        private readonly DatabaseContext _db;

        public BaseRepository()
        {
            this._db = new DatabaseContext(connectionString);
        }

        public DatabaseContext GetContext()
        {
            return this._db;
        }
    }
}