using CooperSystem.API.Context;
using CooperSystem.API.Interfaces.Repositories;
using CooperSystem.API.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CooperSystem.API.Repositories
{
    public class MarcaRepository : IMarcaRepository
    {
        private readonly ContextDB _context;

        public MarcaRepository(ContextDB contextDB)
        {
            _context = contextDB;
        }

        public void Inserir(Marca marca)
        {
            var marcas = _context.Marcas
            .Where(x => x.Ativo && x.Nome == marca.Nome)
            .AsNoTracking()
            .ToList();

            if (marcas.Any())
            {
                throw new InvalidOperationException("Já existe uma marca com o mesmo nome.");
            }

            _context.Marcas.Add(marca);
            _context.SaveChanges();
        }
       
        public void Atualizar(Marca marca)
        {
            var marcas = _context.Marcas
            .Where(x => x.Ativo && x.Nome == marca.Nome && x.Origem == marca.Origem && x.Id != marca.Id)
            .AsNoTracking()
            .ToList();

            if (marcas.Any())
            {
                throw new InvalidOperationException("Já existe uma marca com o mesmo nome e origem.");
            }

            _context.Marcas.Update(marca);
            _context.SaveChanges();
        }

        public List<Marca> listarTodasAsMarcas()
        {
            var result = _context.Marcas.Where(x => x.Ativo).AsNoTracking().ToList();
            return result;
        }

        public List<Marca> ObterPorNomeEOrigem(string nome, string origem)
        {
            var result = _context.Marcas.Where(x => x.Nome.Contains(nome) && x.Origem == origem && x.Ativo).AsNoTracking().ToList();
            return result;
        }

        public void Delete(int id)
        {
            var result = _context.Marcas.Find(id);

            result.Ativo = false;

            _context.Update(result);
            _context.SaveChanges();
        }

    }
}
