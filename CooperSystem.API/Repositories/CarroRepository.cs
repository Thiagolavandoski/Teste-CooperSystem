using CooperSystem.API.Context;
using CooperSystem.API.Interfaces.Repositories;
using CooperSystem.API.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CooperSystem.API.Repositories
{
    public class CarroRepository : ICarroRepository
    {
        private readonly ContextDB _context;

        public CarroRepository(ContextDB contextDB)
        {
            _context = contextDB;
        }
        public void Inserir(Carro carro)
        {
            var carros = _context.Carros
            .Where(x => x.Ativo && x.Nome == carro.Nome && x.Origem == carro.Origem && x.MarcaId == carro.MarcaId && x.Cor != carro.Cor)
            .AsNoTracking()
            .ToList();

            if (carros.Any())
            {
                throw new InvalidOperationException("Já existe um carro o mesmo nome, origem e marca.");
            }
            _context.Carros.Add(carro);
            _context.SaveChanges();
        }

        public void Atualizar(Carro carro)
        {
            var carros = _context.Carros
                .Where(x => x.Ativo && x.Nome == carro.Nome && x.Origem == carro.Origem && x.Cor != carro.Cor && x.Id != carro.Id)
                .AsNoTracking()
                .ToList();

            if (carros.Any())
            {
                throw new InvalidOperationException("Já existe um carro com o mesmo nome, origem e marca.");
            }

            // Obtém o registro atual do banco de dados
            var carroAtual = _context.Carros.FirstOrDefault(x => x.Id == carro.Id);
            if (carroAtual == null)
            {
                throw new KeyNotFoundException("Carro não encontrado.");
            }

            // Atualiza apenas os campos que não são nulos
            carroAtual.Nome = carro.Nome ?? carroAtual.Nome;
            carroAtual.Cor = carro.Cor ?? carroAtual.Cor;
            carroAtual.Origem = carro.Origem ?? carroAtual.Origem;
            carroAtual.Potencia = carro.Potencia ?? carroAtual.Potencia;
            carroAtual.MarcaId = carro.MarcaId != 0 ? carro.MarcaId : carroAtual.MarcaId;
            carroAtual.QtdCarros = carro.QtdCarros != 0 ? carro.QtdCarros : carroAtual.QtdCarros;
            carroAtual.AnoModelo = carro.AnoModelo != default ? carro.AnoModelo : carroAtual.AnoModelo;
            carroAtual.AnoFabricacao = carro.AnoFabricacao != default ? carro.AnoFabricacao : carroAtual.AnoFabricacao;

            // Ignora a alteração da propriedade "Ativo"
            _context.Entry(carroAtual).Property(x => x.Ativo).IsModified = false;

            _context.SaveChanges();
        }

        public void AlterarStatusCarro(int id)
        {
            // Obtém o registro atual do banco de dados
            var carro = _context.Carros.FirstOrDefault(x => x.Id == id);
            if (carro == null)
            {
                throw new KeyNotFoundException("Carro não encontrado.");
            }

            carro.Ativo = !carro.Ativo;

            // Salva as alterações no banco de dados
            _context.SaveChanges();
        }

        public List<Carro> listarTodosOsCarros()
        {
            var result = _context.Carros.Where(x => x.Ativo).Include(x => x.Marca).AsNoTracking().ToList();
            return result;
        }

        public List<Carro> ObterPorNomeEOrigem(string nome, string origem)
        {
            var result = _context.Carros.Where(x => x.Nome.Contains(nome) && x.Origem == origem && x.Ativo).Include(x => x.Marca).AsNoTracking().ToList();
            return result;
        }

        public void Delete(int id)
        {
            // Busca o carro pelo ID
            var result = _context.Carros.Find(id);
            if (result == null)
            {
                throw new KeyNotFoundException("Carro não encontrado.");
            }

            // Remove o carro do banco de dados
            _context.Carros.Remove(result);

            // Salva as alterações
            _context.SaveChanges();
        }
    }
}
