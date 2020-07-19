using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AspNetMvc.Models.ViewModels
{
    public class RegisterAccountRequest
    {
        [Required(ErrorMessage = "Không được bỏ trống tên tài khoản")]
        public string UserName { get; set; }

        [Required(ErrorMessage = "Không được bỏ trống mật khẩu")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Required(ErrorMessage = "Không được bỏ trống mật khẩu nhập lại")]
        [DataType(DataType.Password)]
        [Compare("Password",ErrorMessage ="Mật khẩu nhập lại không khớp")]
        public string ConfirmPassword { get; set; }
    }
}
