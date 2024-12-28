using CooperSystem.API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CooperSystem.API.Interfaces.Repositories
{
    public interface IMarcaRepository
    {
        public void Inserir(Marca marca);
        public void Atualizar(Marca marca);
        public List<Marca> listarTodasAsMarcas();
        public List<Marca> ObterPorNomeEOrigem(string nome, string origem);
        public void Delete(int id);
    }
}
