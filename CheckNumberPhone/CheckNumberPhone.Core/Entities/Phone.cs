using System.ComponentModel.DataAnnotations;

namespace FindBeeNumbers.Core.Entities
{
    public class Phone
    {
        [Key]
        public int Id { get; set; }
        public string Number { get; set; }
        public string Network { get; set; }
    }
}
