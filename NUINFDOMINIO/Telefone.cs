using System;
using System.Collections.Generic;
using System.Text;

namespace NUINFDOMINIO
{
   public class Telefone
    {
        public long id { get; set; }
        public string ddd { get; set; }
        public string numeros { get; set; }

        public virtual Pessoa Pessoa { get; set; }
    }
}
