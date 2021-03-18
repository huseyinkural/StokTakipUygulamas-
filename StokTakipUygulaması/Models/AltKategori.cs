using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace StokTakipUygulaması.Models
{
    public class AltKategori
    {
       
        public int Id { get; set; }

        [Required]
        [Display(Name = "Alt Kategori Adı")]
        public string Isim { get; set; }
        public virtual Kategori Kategori{ get; set; }
      
    }
}
