using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AspNetMvc.Models.ViewModels
{
    public class UserRoleResponse
    {
        public string UserName { get; set; }
        public List<string> Roles { get; set; }
    }
}
