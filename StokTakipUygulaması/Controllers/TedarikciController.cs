using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using StokTakipUygulaması.Data.TedarikciRepo;
using StokTakipUygulaması.Models;

namespace StokTakipUygulaması.Controllers
{
    public class TedarikciController : Controller
    {
        private readonly ITedarikciRepository _tedarikciRepository;

        public TedarikciController(ITedarikciRepository tedarikciRepository)
        {
            _tedarikciRepository = tedarikciRepository;
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
        public IActionResult Ekle(Tedarikci tedarikci)
        {
            if (ModelState.IsValid)
            {
                _tedarikciRepository.Add(tedarikci);
                return RedirectToAction(nameof(Index));
            }
            else
            {
                return View();
            }

        }

        public IActionResult Duzenle(int id)
        {
            var tedarikci = _tedarikciRepository.Get(id);
            return View(tedarikci);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Duzenle(Tedarikci tedarikci)
        {
            if (ModelState.IsValid)
            {
                _tedarikciRepository.Update(tedarikci);
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
            var tedarikciler = _tedarikciRepository.GetAll();
            return Json(new { data = tedarikciler });
        }

        [HttpDelete]
        public IActionResult Sil(int id)
        {
            var tedarikci = _tedarikciRepository.Get(id);

            if (tedarikci == null)
            {
                return Json(new { success = false, message = "Silerken hata oluştu." });
            }

            _tedarikciRepository.Delete(id);

            return Json(new { success = true, message = "Silme işlemi başarılı." });
        }

        #endregion
    }
}
