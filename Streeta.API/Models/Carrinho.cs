using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Streeta.API.Models
{
    public class Carrinho
    {
        public Carrinho (){

        }

        public Carrinho(int? id, List<Vestuario> produtos, int idUsuario)
        {
            Id = id;
            Produtos = produtos;
            IdUsuario = idUsuario;
        }

        public int? Id {get;set;}
        public List<Vestuario> Produtos {get;set;}
        public int IdUsuario {get;set;}
    }
}
