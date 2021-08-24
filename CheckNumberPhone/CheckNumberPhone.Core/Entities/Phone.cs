using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FindBeeNumbers.Core.Entities
{
    public class Phone
    {
        [Key]
        public int Id { get; set; }

        [Column("Number", TypeName ="varchar(10)")]
        public string Number { get; set; }

        [Column("Network", TypeName = "varchar(50)")]
        public string Network { get; set; }
    }
}
