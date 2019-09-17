using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Entities
{
    [Table("MANUFACTURER")]
    public class Manufacturer : BaseEntity
    {
        [Required]
        [MaxLength(250)]
        public string Name { get; set; }
        public string Description { get; set; }
        [MaxLength(250)]
        public string Website { get; set; }
        [Column("LogoPath")]
        public string Logo { get; set; }
    }
}
