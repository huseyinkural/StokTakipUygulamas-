using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using StokTakipUygulaması.Data.Kullanicilar;
using StokTakipUygulaması.Models;

namespace StokTakipUygulaması.Controllers
{
    [Authorize(Roles ="Yonetici")]
    public class KullaniciIslemleriController : Controller
    {
        private readonly IKullaniciRepository _kullaniciRepository;

        public KullaniciIslemleriController(IKullaniciRepository kullaniciRepository)
        {
            _kullaniciRepository = kullaniciRepository;
        }
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Ekle()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Ekle(Kullanici kullanici)
        {
            if (ModelState.IsValid)
            {
                _kullaniciRepository.Add(kullanici);
                return RedirectToAction(nameof(Index));
            }
            else
            {
                return View();
            }
            
        }

        public IActionResult Duzenle(int id)
        {
            var kullanici = _kullaniciRepository.Get(id);
            return View(kullanici);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Duzenle(Kullanici kullanici)
        {
            if (ModelState.IsValid)
            {
                _kullaniciRepository.Update(kullanici);
                return RedirectToAction(nameof(Index));
            }
            else
            {
                return View();
            }

        }





        #region API CALLS
        [HttpGet]
        public IActionResult GetAll()
        {
            var kullanicilar = _kullaniciRepository.GetAll();
            return Json(new { data = kullanicilar });
        }

        [HttpDelete]
        public IActionResult Sil(int id)
        {
            var kullanici = _kullaniciRepository.Get(id);

            if (kullanici == null)
            {
                return Json(new { success = false, message = "Silerken hata oluştu." });
            }

            _kullaniciRepository.Delete(id);
            
            return Json(new { success = true, message = "Silme işlemi başarılı." });
        }

        #endregion
    }
}
