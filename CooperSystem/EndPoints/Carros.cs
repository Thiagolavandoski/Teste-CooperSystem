using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CooperSystem.EndPoints
{
    public class Carros
    {
        public int Listagem { get; set; }
        public int ColunasNalistagem { get; set; }
        public string Nome { get; set; }
        public int Origem { get; set; }
        public int Ano { get; set; }

        public Carros(int listagem, int colunasNalistagem, string nome, int origem, int ano)
        {
            Listagem = listagem;
            ColunasNalistagem = colunasNalistagem;
            Nome = nome;
            Origem = origem;
            Ano = ano;
        }
    }
}
