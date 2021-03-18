using StokTakipUygulaması.Models;
using StokTakipUygulaması.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StokTakipUygulaması.Data.AltKategoriRepo

{
    public interface IAltKategoriRepository
    {
        AltKategori Get(int id);
        IEnumerable<AltKategori> GetAll();
        void Add(AltKategori kategori);
        void Delete(int id);
        void Update(AltKategori kategori);
    }
}
