using StokTakipUygulaması.Models;
using StokTakipUygulaması.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StokTakipUygulaması.Data.MusteriRepo
{
    public class MusteriRepository : IMusteriRepository
    {
        private readonly DataContext _context;

        public MusteriRepository(DataContext context)
        {
            _context = context;
        }
        public void Add(Musteri musteri)
        {

            _context.Musteriler.Add(musteri);
            _context.SaveChanges();
        }

        public void Delete(int id)
        {
            Musteri musteri = _context.Musteriler.FirstOrDefault(k => k.Id == id);
            if(musteri != null)
            {
                _context.Musteriler.Remove(musteri);
                _context.SaveChanges();
            }
        }

        public Musteri Get(int id)
        {
            return _context.Musteriler.FirstOrDefault(k => k.Id == id);

        }

        public IEnumerable<Musteri> GetAll()
        {
            return _context.Musteriler.ToList();
        }

        public void Update(Musteri updatedMusteri)
        {
            Musteri musteri = _context.Musteriler.FirstOrDefault(k => k.Id == updatedMusteri.Id);

            musteri.Isim = updatedMusteri.Isim;
            musteri.Telefon = updatedMusteri.Telefon;
            musteri.Adres = updatedMusteri.Adres;

            _context.Musteriler.Update(musteri);
            _context.SaveChanges();
        }
    }
}
