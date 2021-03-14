using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StokTakipUygulaması.Models
{
    public class Kullanici
    {
        public int Id { get; set; }
        public string Isim { get; set; }
        public string Soyisim { get; set; }
        public string Sifre { get; set; }
        public string KullaniciAdi { get; set; }
        public int Rol { get; set; } = 2;
    }
}
