using System.Diagnostics.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Streeta.API.Models
{
    public class Categoria
    {
        public Categoria(int? id, string nome)
        {
            Id = id;
            Nome = nome;
        }

        public int? Id {get;set;}
        public string Nome {get;set;}
        
    }
}