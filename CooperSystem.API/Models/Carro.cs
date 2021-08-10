﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CooperSystem.API.Models
{
    public class Carro
    {
        [Key]
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Cor { get; set; }
        public string Origem { get; set; }
        public string Potencia { get; set; }
        public int MarcaId { get; set; }
        public virtual Marca Marca { get; set; }
        public DateTime AnoModelo { get; set; }
        public DateTime AnoFabricacao { get; set; }
        public bool Ativo { get; set; }
    }
}
