using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using StokTakipUygulaması.Data;
using StokTakipUygulaması.Models;
using StokTakipUygulaması.Models.ViewModels;

namespace StokTakipUygulaması.Controllers
{
    enum Roles
    {
        Yonetici = 1,
        Personel = 2
    }
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly DataContext _context;

        public HomeController(ILogger<HomeController> logger, DataContext context)
        {
            _logger = logger;
            _context = context;
        }

        [Authorize]
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Giris()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Giris(LoginViewModel loginViewModel)
        {
            if (ModelState.IsValid)
            {
                var user = _context.Kullanicilar.FirstOrDefault(x => x.KullaniciAdi == loginViewModel.KullaniciAdi && x.Sifre == loginViewModel.Sifre);

                if (user != null)
                {
                  
                    List<Claim> claims = new List<Claim>
                    {
                        new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
                        new Claim(ClaimTypes.Name, user.KullaniciAdi),
                        new Claim(ClaimTypes.Role, ((Roles)user.Rol).ToString())
                    };
                    var claimsIdentity = new ClaimsIdentity(claims, "User Identity");
                    var userPrincipal = new ClaimsPrincipal(new[] { claimsIdentity });                    

                   

                    await HttpContext.SignOutAsync();

                    await HttpContext.SignInAsync(userPrincipal);

                    return RedirectToAction("Privacy", "Home");
                    
                }
                else
                {
                    ModelState.AddModelError("", "Kullanıcı adı veya şifre yanlış");
                }
            }

            return View(loginViewModel);
        }

        [HttpPost]
        public async Task<IActionResult> Cikis()
        {
            await HttpContext.SignOutAsync();
            return RedirectToAction(nameof(Index));
        }
        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
