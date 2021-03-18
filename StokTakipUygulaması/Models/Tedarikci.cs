﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace StokTakipUygulaması.Models
{
    public class Tedarikci
    {
        public int Id { get; set; }

        [Required]
        [Display(Name = "Tedarikçi Adı/Unvanı")]
        public string Isim { get; set; }

        public string Telefon { get; set; }
        public string Adres { get; set; }

    }
}
