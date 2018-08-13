using System;
using System.Collections.Generic;
using System.Text;

namespace NUINFDOMINIO
{
    // Classe POCO representando pessoa
   public class Pessoa
    {
        public long id { get; set; }
        public string nome { get; set; }
        public string cpf { get; set; }
        public DateTime dataNascimento { get; set; }
        public string email { get; set; }
        public List<Telefone> telefones { get; set; }
    }
}
