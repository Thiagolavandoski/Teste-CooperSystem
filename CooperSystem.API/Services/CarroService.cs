using CooperSystem.API.Interfaces.Repositories;
using CooperSystem.API.Interfaces.Services;
using CooperSystem.API.Models;
using System.Collections.Generic;

namespace CooperSystem.API.Services
{
    public class CarroService : ICarroService
    {
        private readonly ICarroRepository _carroRepository;

        public CarroService(ICarroRepository carroRepository)
        {
            _carroRepository = carroRepository;
        }

        public void Inserir(Carro carro)
        {
            _carroRepository.Inserir(carro);
        }

        public void Atualizar(Carro carro)
        {
            _carroRepository.Atualizar(carro);
        }
        public void AlterarStatusCarro(int id)
        {
            _carroRepository.AlterarStatusCarro(id);
        }

        public List<Carro> listarTodosOsCarros()
        {
            var result = _carroRepository.listarTodosOsCarros();
            return result;
        }

        public List<Carro> ObterPorNomeEOrigem(string nome, string origem)
        {
            var result = _carroRepository.ObterPorNomeEOrigem(nome, origem);
            return result;
        }

        public void Delete(int id)
        {
            _carroRepository.Delete(id);
        }
    }
}
