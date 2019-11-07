using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;


namespace WebApp.Areas.Admin.Models.ViewModels
{
    public class CategoryViewModel
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Vui lòng nhập tên sản phẩm")]
        [DisplayName("Tên thể loại")]
        [MaxLength(250)]
        public string Name { get; set; }
        [StringLength(2048)]
        [DisplayName("Chi tiết")]
        public string Description { get; set; }
        [StringLength(2048)]
        [DisplayName("Chi tiết")]
        public string DisplayDescription => (this.Description != null) ? ((this.Description.Length > 70) ? this.Description.Substring(0, 70) + "..." : this.Description + "...") : this.Description;
    }

}