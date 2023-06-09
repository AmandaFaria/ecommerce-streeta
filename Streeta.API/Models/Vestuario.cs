using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Streeta.API.Models
{
    public class Vestuario
    {
        public Vestuario(int? id, string nome, double preco, string descricao, string cor, string tamanho, string imagem, Categoria categoria)
        {
            Id = id;
            Nome = nome;
            Preco = preco;
            Descricao = descricao;
            Cor = cor;
            Tamanho = tamanho;
            Imagem = imagem;
            this.categoria = categoria;
        }

        public int? Id {get;set;}
        public string Nome {get;set;}
        public double Preco {get;set;}
        public string Descricao {get;set;}
        public string Cor {get; set;}
        public string Tamanho {get;set;}
        public string Imagem {get; set;}
        public Categoria categoria {get; set;}

    }
}