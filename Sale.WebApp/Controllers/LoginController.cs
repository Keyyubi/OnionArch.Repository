using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Sale.Data.Model;
using Sale.Service;
using Sale.WebApp.Models;

namespace CrazySale.Controllers
{
    public class LoginController : Controller
    {
        private readonly IUserService _userService;
        public LoginController(IUserService userService)
        {
            _userService = userService;
        }


        public IActionResult Index(string msg = null)
        {
            ViewData["ErrorMsg"] = msg;
            return View(new User());
        }

        public IActionResult Login()
        {
            //if(string.IsNullOrEmpty(u.Username) || string.IsNullOrEmpty(u.Password))
            //    return RedirectToAction("Index",new{msg="Kullanıcı Adı veya Şifre girmediniz."});
            
            
            //var result = _userService.Login(u);
            //if (result)
            //    return RedirectToAction("Index", "Home");
            
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        public IActionResult NewUser(User u)
        {
            return View();
        }

        public IActionResult AddUser(User user)
        {
            //if(u == null || string.IsNullOrEmpty(u.Username) || string.IsNullOrEmpty(u.Password))
            //    return RedirectToAction("Index",new{msg="Kullanıcı Adı veya Şifre girmediniz."});

            //if(_userService.CreateUser(u))
            //    return RedirectToAction("Index", new{msg="Kullanıcı Oluşturuldu."});

            //return RedirectToAction("Index",new{msg="Bir hata yaklaşıyor."});

            return View();
        }
    }
}
