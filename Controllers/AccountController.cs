using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AspNetMvc.Models.ViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace AspNetMvc.Controllers
{
    public class AccountController : Controller
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly SignInManager<IdentityUser> _signInManager;

        public AccountController(UserManager<IdentityUser> userManager,
            SignInManager<IdentityUser> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }

        [HttpGet]
        public IActionResult Login()
        {
            return View(new LoginAccountRequest(){LoginSuccess = false,Error = ""});
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginAccountRequest loginAccountRequest)
        {
            if (!ModelState.IsValid)
            {
                return View(loginAccountRequest);
            }
            var user = await _userManager.FindByNameAsync(loginAccountRequest.UserName);
            if (user == null)
            {
                loginAccountRequest.LoginSuccess = false;
                loginAccountRequest.Error = "Sai tên đăng nhập hoặc mật khẩu";
                return View(loginAccountRequest);
            }
            await _signInManager.SignOutAsync();
            var result = await _signInManager.PasswordSignInAsync(user, loginAccountRequest.Password, false, true);
            if (result.Succeeded)
            {
                return RedirectToAction("Index", "Home");
            }

            loginAccountRequest.LoginSuccess = false;
            loginAccountRequest.Error = "Sai tên đăng nhập hoặc mật khẩu";
            return View(loginAccountRequest);
        }

        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Register(RegisterAccountRequest registerAccountRequest)
        {
            if (!ModelState.IsValid)
            {
                return View(registerAccountRequest);
            }

            var user = await _userManager.FindByNameAsync(registerAccountRequest.UserName);

            if (user != null)
            {
                return View();
            }

            IdentityUser newUser = new IdentityUser(registerAccountRequest.UserName);

            var result = await _userManager.CreateAsync(newUser, registerAccountRequest.Password);

            if (!result.Succeeded)
            {
                return View();
            }

            return View();
        }

        [HttpGet]
        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction("Index", "Home");
        }
    }
}
