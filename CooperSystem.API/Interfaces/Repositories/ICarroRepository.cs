using CooperSystem.API.Models;
using System.Collections.Generic;

namespace CooperSystem.API.Interfaces.Repositories
{
    public interface ICarroRepository
    {
        public void Inserir(Carro carro);
        public void Atualizar(Carro carro);
        public void AlterarStatusCarro(int id);
        public List<Carro> listarTodosOsCarros();
        public List<Carro> ObterPorNomeEOrigem(string nome, string origem);
        public void Delete(int id);
    }
}
