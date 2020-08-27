using System.Data.Linq.Mapping;

namespace CES2020.Models
{
    [Table(Name = "BY")]
    public class By
    {
        [Column(Name = "ID", IsPrimaryKey = true)]
        public int Id { get; set; }

        [Column(Name = "NAME")]
        public string Name { get; set; }
    }
}