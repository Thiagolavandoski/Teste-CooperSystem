using CooperSystem.API.Models;
using System.Collections.Generic;

namespace CooperSystem.API.Interfaces.Services
{
    public interface IMarcaService
    {
        public void Inserir(Marca marca);
        public void Atualizar(Marca marca);
        public List<Marca> listarTodasAsMarcas();
        public List<Marca> ObterPorNomeEOrigem(string nome, string origem);
        public void Delete(int id);
    }
}
