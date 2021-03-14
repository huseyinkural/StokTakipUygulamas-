using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace StokTakipUygulaması.Models.ViewModels
{
    public class LoginViewModel
    {

        [Required]       
        [Display(Name = "Kullanıcı adınız")]
        public string KullaniciAdi { get; set; }

        [Required]
        [StringLength(16, ErrorMessage = "{0} alanı  en az {2} karakter uzunluğunda olmalıdır..", MinimumLength = 4)]
        [DataType(DataType.Password)]
        [Display(Name = "Şifreniz")]
        public string Sifre { get; set; }

    }
}
