using CooperSystem.API.Interfaces.Repositories;
using CooperSystem.API.Interfaces.Services;
using CooperSystem.API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CooperSystem.API.Services
{
    public class MarcaService : IMarcaService
    {
        private readonly IMarcaRepository _marcaRepository;

        public MarcaService(IMarcaRepository marcaRepository)
        {
            _marcaRepository = marcaRepository;
        }

        public void Delete(int id)
        {
            _marcaRepository.Delete(id);
        }

        public void Edit(Marca marca)
        {
            _marcaRepository.Edit(marca);
        }

        public List<Marca> GetAll()
        {
            var result = _marcaRepository.GetAll();
            return result;
        }

        public List<Marca> GetByFilter(string nome, string origem)
        {
            var result = _marcaRepository.GetByFilter(nome, origem);
            return result;
        }

        public void Insert(Marca marca)
        {
            _marcaRepository.Insert(marca);
        }
    }
}
