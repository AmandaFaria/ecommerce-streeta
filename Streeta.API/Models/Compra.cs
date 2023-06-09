using System.Globalization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Streeta.API.Models
{
    public class Compra
    {
        public Compra(){
            
        }
        public Compra(int? id, List<Vestuario> produtos, string status, DateTime dataCompra, Cupom? cupom, double valor, double valorFinal, Usuario usuario)
        {
            Id = id;
            Produtos = produtos;
            Status = status;
            DataCompra = dataCompra;
            this.cupom = cupom;
            Valor = valor;
            ValorFinal = valorFinal;
            this.usuario = usuario;
        }

        public int? Id {get;set;}
        public List<Vestuario> Produtos {get;set;}
        public string Status {get;set;}
        public DateTime DataCompra {get;set;}
        public Cupom? cupom {get;set;}
        public double Valor {get;set;}
        public double ValorFinal {get;set;}
        public Usuario usuario {get;set;}
    }
}