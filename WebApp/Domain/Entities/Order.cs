using Domain.Enum;
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Entities
{
    [Table("ORDER")]
    public class Order : BaseEntity
    {
        #region Field
        public DateTime? OrderDate { get; set; }
        public DateTime? ShippedDate { get; set; }
        //tình trạng giao hàng
        public CommonStatus StatusPayment { get; set; }
        //đã hủy
        public CommonStatus Cancelled { get; set; }
        //đã xóa
        public CommonStatus Deleted { get; set; }

        #endregion
        #region Relationship
        [ForeignKey("Customer")]
        public Guid CustomerId { get; set; }
        public virtual Customer Customer { get; set; }
        #endregion
    }
}
