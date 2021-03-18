using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using StokTakipUygulaması.Data.Kategoriler;
using StokTakipUygulaması.Models;

namespace StokTakipUygulaması.Controllers
{
    public class KategoriController : Controller
    {
        private readonly IKategoriRepository _kategoriRepository;

        public KategoriController(IKategoriRepository kategoriRepository)
        {
            _kategoriRepository = kategoriRepository;
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
        public IActionResult Ekle(Kategori kategori)
        {
            if (ModelState.IsValid)
            {
                _kategoriRepository.Add(kategori);
                return RedirectToAction(nameof(Index));
            }
            else
            {
                return View();
            }

        }

        public IActionResult Duzenle(int id)
        {
            var kategori = _kategoriRepository.Get(id);
            return View(kategori);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Duzenle(Kategori kategori)
        {
            if (ModelState.IsValid)
            {
                _kategoriRepository.Update(kategori);
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
            var kategoriler = _kategoriRepository.GetAll();
            return Json(new { data = kategoriler });
        }

        [HttpDelete]
        public IActionResult Sil(int id)
        {
            var kategori = _kategoriRepository.Get(id);

            if (kategori == null)
            {
                return Json(new { success = false, message = "Silerken hata oluştu." });
            }

            _kategoriRepository.Delete(id);

            return Json(new { success = true, message = "Silme işlemi başarılı." });
        }

        #endregion
    }
}
