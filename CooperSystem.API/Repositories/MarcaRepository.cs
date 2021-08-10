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
    public class MarcaRepository : IMarcaRepository
    {
        private readonly ContextDB _context;

        public MarcaRepository(ContextDB contextDB)
        {
            _context = contextDB;
        }
        public void Delete(int id)
        {
            var result = _context.Marcas.Find(id);

            result.Ativo = false;

            _context.Update(result);
            _context.SaveChanges();
        }

        public void Edit(Marca marca)
        {
            _context.Marcas.Update(marca);
            _context.SaveChanges();
        }

        public List<Marca> GetAll()
        {
            var result = _context.Marcas.Where(x => x.Ativo).AsNoTracking().ToList();
            return result;
        }

        public List<Marca> GetByFilter(string nome, string origem)
        {
            var result = _context.Marcas.Where(x => x.Nome.Contains(nome) && x.Origem == origem && x.Ativo).AsNoTracking().ToList();
            return result;
        }

        public void Insert(Marca marca)
        {
            _context.Marcas.Add(marca);
            _context.SaveChanges();
        }
    }
}
