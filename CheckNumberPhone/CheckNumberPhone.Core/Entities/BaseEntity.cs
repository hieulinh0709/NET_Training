using System.ComponentModel.DataAnnotations;

namespace CheckNumberPhone.Core.Entities
{
    public abstract class BaseEntity
    {
        [Key]
        public virtual int Id { get; set; }
    }
}
