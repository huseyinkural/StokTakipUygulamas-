using StokTakipUygulaması.Models;
using StokTakipUygulaması.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StokTakipUygulaması.Data.TedarikciRepo
{
    public class TedarikciRepository : ITedarikciRepository
    {
        private readonly DataContext _context;

        public TedarikciRepository(DataContext context)
        {
            _context = context;
        }
        public void Add(Tedarikci tedarikci)
        {

            _context.Tedarikciler.Add(tedarikci);
            _context.SaveChanges();
        }

        public void Delete(int id)
        {
            Tedarikci tedarikci = _context.Tedarikciler.FirstOrDefault(k => k.Id == id);
            if(tedarikci != null)
            {
                _context.Tedarikciler.Remove(tedarikci);
                _context.SaveChanges();
            }
        }

        public Tedarikci Get(int id)
        {
            return _context.Tedarikciler.FirstOrDefault(k => k.Id == id);

        }

        public IEnumerable<Tedarikci> GetAll()
        {
            return _context.Tedarikciler.ToList();
        }

        public void Update(Tedarikci updatedTedarikci)
        {
            Tedarikci tedarikci = _context.Tedarikciler.FirstOrDefault(k => k.Id == updatedTedarikci.Id);

            tedarikci.Isim = updatedTedarikci.Isim;
            tedarikci.Telefon = updatedTedarikci.Telefon;
            tedarikci.Adres = updatedTedarikci.Adres;

            _context.Tedarikciler.Update(tedarikci);
            _context.SaveChanges();
        }
    }
}
