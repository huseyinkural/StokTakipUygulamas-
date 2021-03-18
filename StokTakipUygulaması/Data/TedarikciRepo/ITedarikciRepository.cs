using StokTakipUygulaması.Models;
using StokTakipUygulaması.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StokTakipUygulaması.Data.TedarikciRepo
{
    public interface ITedarikciRepository
    {
        Tedarikci Get(int id);
        IEnumerable<Tedarikci> GetAll();
        void Add(Tedarikci kategori);
        void Delete(int id);
        void Update(Tedarikci kategori);
    }
}
