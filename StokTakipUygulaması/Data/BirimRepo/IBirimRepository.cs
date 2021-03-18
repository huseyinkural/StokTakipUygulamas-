using StokTakipUygulaması.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StokTakipUygulaması.Data.BirimRepo
{
    public interface IBirimRepository
    {
        Birim Get(int id);
        IEnumerable<Birim> GetAll();
        void Add(Birim birim);
        void Delete(int id);
        void Update(Birim birim);
    }
}
