using Microsoft.EntityFrameworkCore;
using StokTakipUygulaması.Models;
using StokTakipUygulaması.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StokTakipUygulaması.Data.AltKategoriRepo
{
    public class AltKategoriRepository : IAltKategoriRepository
    {
        private readonly DataContext _context;

        public AltKategoriRepository(DataContext context)
        {
            _context = context;
        }
        public void Add(AltKategori altKategori)
        {

            _context.AltKategoriler.Add(altKategori);
            _context.SaveChanges();
        }

        public void Delete(int id)
        {
            AltKategori altKategori = _context.AltKategoriler.Include(a => a.Kategori).FirstOrDefault(k => k.Id == id);
            if(altKategori != null)
            {
                _context.AltKategoriler.Remove(altKategori);
                _context.SaveChanges();
            }
        }

        public AltKategori Get(int id)
        {
            return _context.AltKategoriler.Include(a => a.Kategori).FirstOrDefault(k => k.Id == id);

        }

        public IEnumerable<AltKategori> GetAll()
        {
            var list = _context.AltKategoriler.Include(a=>a.Kategori).ToList();
            return list;
        }

        public void Update(AltKategori updatedAltKategori)
        {
            AltKategori altKategori = _context.AltKategoriler.Include(a => a.Kategori).FirstOrDefault(k => k.Id == updatedAltKategori.Id);

            altKategori.Isim = updatedAltKategori.Isim;
            altKategori.Kategori = updatedAltKategori.Kategori;

            _context.AltKategoriler.Update(altKategori);
            _context.SaveChanges();
        }
    }
}
