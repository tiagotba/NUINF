﻿using System;
using System.Collections.Generic;
using System.Text;

namespace NUINFREPOSITORIO.DTO
{
   public class PessoaDTOPersistencia
    {
        public string codPessoa { get; set; } 

        public string nomePessoa { get; set; }

        public string cpfPessoa { get; set; }

        public string emailPessoa { get; set; }

        public string nascPessoa { get; set; }

        public IEnumerable<TelefoneDTOPersistencia> telefones { get; set; }
    }
}
