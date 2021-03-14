using StokTakipUygulaması.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StokTakipUygulaması.Data.Anasayfa
{
    public interface IAnasayfaRepository
    {
        void Login(LoginViewModel loginViewModel);
        void Logout();
    }
}
