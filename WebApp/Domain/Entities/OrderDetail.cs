using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Entities
{
    [Table("ORDERDETAIL")]
    public class OrderDetail : BaseEntity
    {
        public int QuantityProduct { get; set; }
        public double BuyPrice { get; set; }

        [ForeignKey("Orders")]
        public Guid? OrderId { get; set; }
        public virtual Order Orders { get; set; }
        [ForeignKey("Product")]
        public Guid? ProductId { get; set; }
        public virtual Product Product { get; set; }
    }
}
