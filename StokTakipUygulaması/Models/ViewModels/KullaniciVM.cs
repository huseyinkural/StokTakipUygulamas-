using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace StokTakipUygulaması.Models.ViewModels
{
    public class KullaniciVM
    {
        [Required]
        [Display(Name = "Kullanıcı Adı")]
        public string KullaniciAdi { get; set; }

        [Required]
        [StringLength(16, ErrorMessage = "{0} alanı  en az {2} karakter uzunluğunda olmalıdır..", MinimumLength = 4)]
        [DataType(DataType.Password)]
        [Display(Name = "Şifre")]
        public string Sifre { get; set; }

        [Required]
        [Display(Name = "İsim")]
        public string Isim { get; set; }

        [Required]
        [Display(Name = "Soyisim")]
        public string Soyisim { get; set; }


    }
}
