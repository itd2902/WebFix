using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Entities
{
    [Table("CUSTOMER")]
    public class Customer : BaseEntity
    {
        public string FistName { get; set; }
        public string LastName { get; set; }
        public string Address { get; set; }
        public int Age { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
    }
}
