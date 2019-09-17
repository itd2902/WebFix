using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Entities
{
    [Table("CATEGORY")]
    public class Category : BaseEntity
    {
        #region Field
        [Required]
        [MaxLength(250)]
        public string Name { get; set; }
        [StringLength(2048)]
        public string Description { get; set; }
        #endregion
        #region Relation
        public ICollection<Product> Products { get; set; }
        #endregion
    }
}
