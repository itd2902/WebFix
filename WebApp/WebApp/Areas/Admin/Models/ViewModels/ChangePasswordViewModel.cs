using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebApp.Areas.Admin.Models.ViewModels
{
    public class ChangePasswordViewModel
    {
        public ChangePasswordViewModel()
        {
            this.Password = "";
            this.NewPassword = "";
        }
        public int Id { get; set; }
        [Required(ErrorMessage ="Mật khẩu không được trống")]
        [DisplayName("Mật khẩu")]
        public string Password { get; set; }
        [Required(ErrorMessage ="Mật khẩu mới")]
        [DisplayName("Mật khẩu mới")]
        public string NewPassword { get; set; }
    }
}