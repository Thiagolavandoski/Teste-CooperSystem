using CooperSystem.API.Interfaces.Repositories;
using CooperSystem.API.Interfaces.Services;
using CooperSystem.API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CooperSystem.API.Services
{
    public class CarroService : ICarroService
    {
        private readonly ICarroRepository _carroRepository;

        public CarroService(ICarroRepository carroRepository)
        {
            _carroRepository = carroRepository;
        }

        public void Delete(int id)
        {
            _carroRepository.Delete(id);
        }

        public void Edit(Carro carro)
        {
            _carroRepository.Edit(carro);
        }

        public List<Carro> GetAll()
        {
            var result = _carroRepository.GetAll();
            return result;
        }

        public List<Carro> GetByFilter(string nome, string origem)
        {
            var result = _carroRepository.GetByFilter(nome, origem);
            return result;
        }

        public void Insert(Carro carro)
        {
            _carroRepository.Insert(carro);
        }
    }
}
