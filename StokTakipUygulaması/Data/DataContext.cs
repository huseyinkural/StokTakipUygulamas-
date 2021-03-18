using Microsoft.EntityFrameworkCore;
using StokTakipUygulaması.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StokTakipUygulaması.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options): base(options)
        {

        }

        public DbSet<Kullanici> Kullanicilar { get; set; }
        public DbSet<Kategori> Kategoriler { get; set; }
        public DbSet<AltKategori> AltKategoriler { get; set; }
        public DbSet<Birim> Birimler { get; set; }
        public DbSet<Tedarikci> Tedarikciler { get; set; }
        public DbSet<Musteri> Musteriler { get; set; }
    }
}
