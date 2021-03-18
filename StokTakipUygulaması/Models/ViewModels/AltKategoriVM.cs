using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StokTakipUygulaması.Models.ViewModels
{
    public class AltKategoriVM
    {
        public int SelectedOrderId { get; set; }
        public AltKategori AltKategori { get; set; }
        public IEnumerable<SelectListItem> KategoriListesi { get; set; }
    }
}
