using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Entities
{
    [Table("ROLE")]
    public class Role : BaseEntity
    {
        [MaxLength(50)]
        [Column(TypeName = "varchar")]
        public string Name { get; set; }
        public string Description { get; set; }

        #region Relationship
        public virtual IEnumerable<User> Users { get; set; }
        #endregion
    }
}
