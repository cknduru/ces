using System.Data.Linq.Mapping;

namespace CES2020.Models
{
    [Table(Name = "GODSTYPE")]
    public class Godstype
    {
        [Column(Name = "ID", IsPrimaryKey = true, IsDbGenerated = true)]
        public int Id { get; set; }

        [Column(Name = "TILLAEG")]
        public int Tillaeg { get; set; }
        
        [Column(Name = "TYPE")]
        public Enums.Enums.GodsType Type { get; set;}
        
    }
}