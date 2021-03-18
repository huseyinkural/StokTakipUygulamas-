using StokTakipUygulaması.Models;
using StokTakipUygulaması.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StokTakipUygulaması.Data.MusteriRepo
{
    public interface IMusteriRepository
    {
        Musteri Get(int id);
        IEnumerable<Musteri> GetAll();
        void Add(Musteri kategori);
        void Delete(int id);
        void Update(Musteri kategori);
    }
}
