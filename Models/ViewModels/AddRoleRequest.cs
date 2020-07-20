using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AspNetMvc.Models.ViewModels
{
    public class AddRoleRequest
    {
        [Required(ErrorMessage ="Không được bỏ trống trường này")]
        public string RoleName { get; set; }
    }
}
