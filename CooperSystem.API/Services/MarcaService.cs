using CooperSystem.API.Interfaces.Repositories;
using CooperSystem.API.Interfaces.Services;
using CooperSystem.API.Models;
using System.Collections.Generic;

namespace CooperSystem.API.Services
{
    public class MarcaService : IMarcaService
    {
        private readonly IMarcaRepository _marcaRepository;

        public MarcaService(IMarcaRepository marcaRepository)
        {
            _marcaRepository = marcaRepository;
        }
        public void Inserir(Marca marca)
        {
            _marcaRepository.Inserir(marca);
        }
        
        public void Atualizar(Marca marca)
        {
            _marcaRepository.Atualizar(marca);
        }

        public List<Marca> listarTodasAsMarcas()
        {
            var result = _marcaRepository.listarTodasAsMarcas();
            return result;
        }

        public List<Marca> ObterPorNomeEOrigem(string nome, string origem)
        {
            var result = _marcaRepository.ObterPorNomeEOrigem(nome, origem);
            return result;
        }

        public void Delete(int id)
        {
            _marcaRepository.Delete(id);
        }

    }
}
