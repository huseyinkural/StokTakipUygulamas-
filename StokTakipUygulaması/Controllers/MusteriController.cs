using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using StokTakipUygulaması.Data.MusteriRepo;
using StokTakipUygulaması.Models;

namespace StokTakipUygulaması.Controllers
{
    public class MusteriController : Controller
    {
        private readonly IMusteriRepository _musteriRepository;

        public MusteriController(IMusteriRepository musteriRepository)
        {
            _musteriRepository = musteriRepository;
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
        public IActionResult Ekle(Musteri musteri)
        {
            if (ModelState.IsValid)
            {
                _musteriRepository.Add(musteri);
                return RedirectToAction(nameof(Index));
            }
            else
            {
                return View();
            }

        }

        public IActionResult Duzenle(int id)
        {
            var musteri = _musteriRepository.Get(id);
            return View(musteri);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Duzenle(Musteri musteri)
        {
            if (ModelState.IsValid)
            {
                _musteriRepository.Update(musteri);
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
            var musteriler = _musteriRepository.GetAll();
            return Json(new { data = musteriler });
        }

        [HttpDelete]
        public IActionResult Sil(int id)
        {
            var musteri = _musteriRepository.Get(id);

            if (musteri == null)
            {
                return Json(new { success = false, message = "Silerken hata oluştu." });
            }

            _musteriRepository.Delete(id);

            return Json(new { success = true, message = "Silme işlemi başarılı." });
        }

        #endregion
    }
}
