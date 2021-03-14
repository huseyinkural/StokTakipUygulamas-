using Microsoft.AspNetCore.Http;
using StokTakipUygulaması.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace StokTakipUygulaması.Data.Anasayfa
{
   
    public class AnasayfaRepository : IAnasayfaRepository
    {
        private readonly DataContext _context;

        public AnasayfaRepository(DataContext context)
        {
            _context = context;
        }
        public void Login(LoginViewModel loginViewModel)
        {
            var user = _context.Kullanicilar.FirstOrDefault(u => u.KullaniciAdi == loginViewModel.KullaniciAdi && u.Sifre == loginViewModel.Sifre);
            if (user != null)
            {

               

            }
        }

        public void Logout()
        {
            throw new NotImplementedException();
        }
    }
}
