using CooperSystem.API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CooperSystem.API.Interfaces.Services
{
    public interface ICarroService
    {
        public List<Carro> GetAll();
        public List<Carro> GetByFilter(string nome, string origem);
        public void Insert(Carro carro);
        public void Edit(Carro carro);
        public void Delete(int id);
    }
}
