using System;
using System.Collections.Generic;
using System.Text;

namespace ProjetoXamarin.Models
{
    class Pessoa
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Email { get; set; }
        public string Senha { get; set; }

        public Pessoa(string nome, string email, string senha)
        {
            Nome = nome;
            Email = email;
            Senha = senha;
        }
    }
}
