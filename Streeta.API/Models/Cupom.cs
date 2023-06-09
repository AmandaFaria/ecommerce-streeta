using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Streeta.API.Models
{
    public class Cupom
    {
        public Cupom(){
            
        }
        public Cupom(int? id, double porcentagem)
        {
            Id = id;
            Porcentagem = porcentagem;
        }

        public int? Id {get;set;}
        public double Porcentagem {get;set;}
    }
}