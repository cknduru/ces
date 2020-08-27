using System.Data.Linq;
using CES2020.Models;

namespace CES2020.Repositories
{
    public class DatabaseContext : DataContext
    {
        public  DatabaseContext(string connectionString) : base(connectionString){}

        public Table<DbTelstarForbindelse> TelstarForbindelser;

        public Table<By> Byer;

        public Table<Konfiguration> Konfigurations;
    }
}