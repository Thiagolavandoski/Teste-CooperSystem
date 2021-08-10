using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CooperSystem.API.Models
{
    public class Marca
    {
        [Key]
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Origem { get; set; }
        //public virtual IList<Carro> Carros { get; set; }
        public bool Ativo { get; set; }
    }
}
