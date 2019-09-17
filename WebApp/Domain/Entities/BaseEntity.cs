using Domain.Enum;
using System;

namespace Domain.Entities
{
    public class BaseEntity
    {
        public BaseEntity()
        {
            CreatedDate = DateTime.Now;
            IsDeleted = false;
        }

        public Guid Id { get; set; }
        public DateTime? CreatedDate { get; set; }
        public Guid? CreatedBy { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public Guid? UpdatedBy { get; set; }
        public CommonStatus? Status { get; set; }
        public bool? IsDeleted { get; set; }
    }
}
