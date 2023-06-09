using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Streeta.API.Models
{
    public class Usuario
    {
        public Usuario(int? id, string nome, string sobrenome, string email, string senha, string? telefone, string cep, string endereco, int numero, string? complemento)
        {
            Id = id;
            Nome = nome;
            Sobrenome = sobrenome;
            Email = email;
            Senha = senha;
            Telefone = telefone;
            Cep = cep;
            Endereco = endereco;
            Numero = numero;
            Complemento = complemento;
        }

        public int? Id {get;set;}
        public string Nome {get;set;}
        public string Sobrenome {get;set;}
        public string Email {get;set;}
        public string Senha {get;set;}
        public string? Telefone {get;set;}
        public string Cep {get;set;}
        public string Endereco {get;set;}
        public int Numero {get;set;}
        public string? Complemento {get;set;}
    }
}