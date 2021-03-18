using StokTakipUygulaması.Models;
using StokTakipUygulaması.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StokTakipUygulaması.Data.Kategoriler
{
    public class KategoriRepository : IKategoriRepository
    {
        private readonly DataContext _context;

        public KategoriRepository(DataContext context)
        {
            _context = context;
        }
        public void Add(Kategori kategori)
        {

            _context.Kategoriler.Add(kategori);
            _context.SaveChanges();
        }

        public void Delete(int id)
        {
            Kategori kategori = _context.Kategoriler.FirstOrDefault(k => k.Id == id);
            if(kategori != null)
            {
                _context.Kategoriler.Remove(kategori);
                _context.SaveChanges();
            }
        }

        public Kategori Get(int id)
        {
            return _context.Kategoriler.FirstOrDefault(k => k.Id == id);

        }

        public IEnumerable<Kategori> GetAll()
        {
            return _context.Kategoriler.ToList();
        }

        public void Update(Kategori updatedKategori)
        {
            Kategori kategori = _context.Kategoriler.FirstOrDefault(k => k.Id == updatedKategori.Id);

            kategori.Isim = updatedKategori.Isim;            

            _context.Kategoriler.Update(kategori);
            _context.SaveChanges();
        }
    }
}
