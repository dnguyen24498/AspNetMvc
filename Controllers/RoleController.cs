using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AspNetMvc.Models.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace AspNetMvc.Controllers
{
    public class RoleController : Controller
    {
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly UserManager<IdentityUser> _userManager;
        public RoleController(RoleManager<IdentityRole> roleManager,
            UserManager<IdentityUser> userManager)
        {
            _roleManager = roleManager;
            _userManager = userManager;
        }

        [Authorize(Roles ="SuperAdmin,Admin,Staff,Salesman")]
        public async Task<IActionResult> Index()
        {
            var listUser =await  _userManager.Users.ToListAsync();
            var userRoleResponse = new List<UserRoleResponse>();
            foreach (var user in listUser)
            {
                var newUserRole = new UserRoleResponse();
                newUserRole.Roles = (List<string>)await _userManager.GetRolesAsync(user);
                newUserRole.UserName = user.UserName;
                userRoleResponse.Add(newUserRole);
            }

            return View(userRoleResponse);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(AddRoleRequest request)
        {
            if (!ModelState.IsValid) return View(request);
            await _roleManager.CreateAsync(new IdentityRole(request.RoleName));
            return View();
        }

    }
}
