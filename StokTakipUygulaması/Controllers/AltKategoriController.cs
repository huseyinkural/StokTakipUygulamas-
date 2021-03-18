using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using StokTakipUygulaması.Data.AltKategoriRepo;
using StokTakipUygulaması.Data.Kategoriler;
using StokTakipUygulaması.Models;
using StokTakipUygulaması.Models.ViewModels;

namespace StokTakipUygulaması.Controllers
{
    public class AltKategoriController : Controller
    {
        private readonly IAltKategoriRepository _altKategoriRepository;
        private readonly IKategoriRepository _kategoriRepository;

        public AltKategoriController(IAltKategoriRepository altKategoriRepository, IKategoriRepository kategoriRepository)
        {
            _altKategoriRepository = altKategoriRepository;
            _kategoriRepository = kategoriRepository;
        }
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Ekle()
        {
            AltKategoriVM kategoriVM = new AltKategoriVM()
            {
                AltKategori = new AltKategori(),
                KategoriListesi = _kategoriRepository.GetAll().Select(i => new SelectListItem
                {
                    Text = i.Isim,
                    Value = i.Id.ToString()
                }),              

            };

            return View(kategoriVM);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Ekle(AltKategoriVM kategoriVM)
        {
            if (ModelState.IsValid)
            {
                kategoriVM.AltKategori.Kategori = _kategoriRepository.Get(kategoriVM.SelectedOrderId);
                _altKategoriRepository.Add(kategoriVM.AltKategori);
                return RedirectToAction(nameof(Index));
            }
            else
            {
                return View();
            }

        }

        public IActionResult Duzenle(int id)
        {
            AltKategoriVM kategoriVM = new AltKategoriVM()
            {
                AltKategori = new AltKategori(),
                KategoriListesi = _kategoriRepository.GetAll().Select(i => new SelectListItem
                {
                    Text = i.Isim,
                    Value = i.Id.ToString()
                }),

            };
            
            kategoriVM.AltKategori = _altKategoriRepository.Get(id);
            kategoriVM.SelectedOrderId = kategoriVM.AltKategori.Kategori.Id;
            return View(kategoriVM);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Duzenle(AltKategoriVM kategoriVM)
        {
            if (ModelState.IsValid)
            {
                kategoriVM.AltKategori.Kategori = _kategoriRepository.Get(kategoriVM.SelectedOrderId);
                _altKategoriRepository.Update(kategoriVM.AltKategori);
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
            var altKategoriler = _altKategoriRepository.GetAll();
            return Json( new { data = altKategoriler });
        }

        [HttpDelete]
        public IActionResult Sil(int id)
        {
            var altKategori = _altKategoriRepository.Get(id);

            if (altKategori == null)
            {
                return Json(new { success = false, message = "Silerken hata oluştu." });
            }

            _altKategoriRepository.Delete(id);

            return Json(new { success = true, message = "Silme işlemi başarılı." });
        }

        #endregion
    }
}
