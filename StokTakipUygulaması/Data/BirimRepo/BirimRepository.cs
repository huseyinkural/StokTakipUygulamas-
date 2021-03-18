using StokTakipUygulaması.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StokTakipUygulaması.Data.BirimRepo
{
    public class BirimRepository : IBirimRepository
    {
        private readonly DataContext _context;

        public BirimRepository(DataContext context)
        {
            _context = context;
        }
        public void Add(Birim birim)
        {

            _context.Birimler.Add(birim);
            _context.SaveChanges();
        }

        public void Delete(int id)
        {
            Birim birim = _context.Birimler.FirstOrDefault(b => b.Id == id);
            if (birim != null)
            {
                _context.Birimler.Remove(birim);
                _context.SaveChanges();
            }
        }

        public Birim Get(int id)
        {
            return _context.Birimler.FirstOrDefault(k => k.Id == id);

        }

        public IEnumerable<Birim> GetAll()
        {
            return _context.Birimler.ToList();
        }

        public void Update(Birim updatedKategori)
        {
            Birim birim = _context.Birimler.FirstOrDefault(k => k.Id == updatedKategori.Id);

            birim.Isim = updatedKategori.Isim;

            _context.Birimler.Update(birim);
            _context.SaveChanges();
        }
    }
}
