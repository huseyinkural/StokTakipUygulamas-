using StokTakipUygulaması.Models;
using StokTakipUygulaması.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StokTakipUygulaması.Data.Kullanicilar
{
    public interface IKullaniciRepository
    {
        Kullanici Get(int id);
        IEnumerable<Kullanici> GetAll();
        void Add(Kullanici kullaniciVM);
        void Delete(int id);
        void Update(Kullanici kullaniciVM);
    }
}
