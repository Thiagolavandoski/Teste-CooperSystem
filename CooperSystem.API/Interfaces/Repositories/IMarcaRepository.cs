using CooperSystem.API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CooperSystem.API.Interfaces.Repositories
{
    public interface IMarcaRepository
    {
        public List<Marca> GetAll();
        public List<Marca> GetByFilter(string nome, string origem);
        public void Insert(Marca marca);
        public void Edit(Marca marca);
        public void Delete(int id);
    }
}
