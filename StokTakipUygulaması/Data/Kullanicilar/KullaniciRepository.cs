using StokTakipUygulaması.Models;
using StokTakipUygulaması.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StokTakipUygulaması.Data.Kullanicilar
{
    public class KullaniciRepository : IKullaniciRepository
    {
        private readonly DataContext _context;

        public KullaniciRepository(DataContext context)
        {
            _context = context;
        }
        public void Add(Kullanici kullanici)
        {

            _context.Kullanicilar.Add(kullanici);
            _context.SaveChanges();
        }

        public void Delete(int id)
        {
            Kullanici kullanici = _context.Kullanicilar.FirstOrDefault(k => k.Id == id);
            if(kullanici != null)
            {
                _context.Kullanicilar.Remove(kullanici);
                _context.SaveChanges();
            }
        }

        public Kullanici Get(int id)
        {
            return _context.Kullanicilar.FirstOrDefault(k => k.Id == id);

        }

        public IEnumerable<Kullanici> GetAll()
        {
            return _context.Kullanicilar.ToList();
        }

        public void Update(Kullanici kullaniciVM)
        {
            Kullanici kullanici = _context.Kullanicilar.FirstOrDefault(k => k.Id == kullaniciVM.Id);

            kullanici.Isim = kullaniciVM.Isim;
            kullanici.Soyisim = kullaniciVM.Soyisim;
            kullanici.KullaniciAdi = kullaniciVM.KullaniciAdi;
            kullanici.Sifre = kullaniciVM.Sifre;

            _context.Kullanicilar.Update(kullanici);
            _context.SaveChanges();
        }
    }
}
