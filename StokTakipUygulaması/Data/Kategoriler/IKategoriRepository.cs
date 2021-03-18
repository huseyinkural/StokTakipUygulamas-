using StokTakipUygulaması.Models;
using StokTakipUygulaması.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StokTakipUygulaması.Data.Kategoriler
{
    public interface IKategoriRepository
    {
        Kategori Get(int id);
        IEnumerable<Kategori> GetAll();
        void Add(Kategori kategori);
        void Delete(int id);
        void Update(Kategori kategori);
    }
}
