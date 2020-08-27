using System.Data.Linq.Mapping;

namespace CES2020.Models
{
    [Table(Name = "BY")]
    public class By
    {
        [Column(Name = "ID", IsPrimaryKey = true, IsDbGenerated = true)]
        public int Id { get; set; }

        [Column(Name = "NAVN")]
        public string Name { get; set; }
    }
}