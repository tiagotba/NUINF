﻿using System;
using System.Collections.Generic;
using System.Text;

namespace NUINFDOMINIO
{
    // Classe POCO representando telefones das pessoas
    public class Telefone
    {
        public long id { get; set; }
        public string ddd { get; set; }
        public string numeros { get; set; }
        public string TelefoneCompleto()
        {
            return ddd + " " + numeros;
        }
        public virtual Pessoa Pessoa { get; set; }
    }
}
