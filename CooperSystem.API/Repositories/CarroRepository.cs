using CooperSystem.API.Context;
using CooperSystem.API.Interfaces.Repositories;
using CooperSystem.API.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CooperSystem.API.Repositories
{
    public class CarroRepository : ICarroRepository
    {
        private readonly ContextDB _context;

        public CarroRepository(ContextDB contextDB)
        {
            _context = contextDB;
        }

        public void Delete(int id)
        {
            var result = _context.Carros.Find(id);

            result.Ativo = false;

            _context.Update(result);
            _context.SaveChanges();
        }

        public void Edit(Carro carro)
        {
            _context.Carros.Update(carro);
            _context.SaveChanges();
        }

        public List<Carro> GetAll()
        {
            var result = _context.Carros.Where(x => x.Ativo).Include(x => x.Marca).AsNoTracking().ToList();
            return result;
        }

        public List<Carro> GetByFilter(string nome, string origem)
        {
            var result = _context.Carros.Where(x => x.Nome.Contains(nome) && x.Origem == origem && x.Ativo).Include(x => x.Marca).AsNoTracking().ToList();
            return result;
        }

        public void Insert(Carro carro)
        {
            _context.Carros.Add(carro);
            _context.SaveChanges();
        }
    }
}
