using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using StokTakipUygulaması.Data.BirimRepo;
using StokTakipUygulaması.Models;

namespace StokTakipUygulaması.Controllers
{
    public class BirimController : Controller
    {
        private readonly IBirimRepository _birimRepository;

        public BirimController(IBirimRepository birimRepository)
        {
            _birimRepository = birimRepository;
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
        public IActionResult Ekle(Birim birim)
        {
            if (ModelState.IsValid)
            {
                _birimRepository.Add(birim);
                return RedirectToAction(nameof(Index));
            }
            else
            {
                return View();
            }

        }

        public IActionResult Duzenle(int id)
        {
            var birim = _birimRepository.Get(id);
            return View(birim);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Duzenle(Birim birim)
        {
            if (ModelState.IsValid)
            {
                _birimRepository.Update(birim);
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
            var birimler = _birimRepository.GetAll();
            return Json(new { data = birimler });
        }

        [HttpDelete]
        public IActionResult Sil(int id)
        {
            var birim = _birimRepository.Get(id);

            if (birim == null)
            {
                return Json(new { success = false, message = "Silerken hata oluştu." });
            }

            _birimRepository.Delete(id);

            return Json(new { success = true, message = "Silme işlemi başarılı." });
        }

        #endregion
    }
}
