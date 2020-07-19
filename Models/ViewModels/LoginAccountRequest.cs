using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AspNetMvc.Models.ViewModels
{
    public class LoginAccountRequest
    {
        [Required(ErrorMessage ="Tên tài khoản không được để trống")]
        public string UserName { get; set; }

        [Required(ErrorMessage ="Mật khẩu không được để trống")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        public bool LoginSuccess { get; set; }
        public string Error { get; set; }
    }
}
