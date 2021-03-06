﻿using NUINFDAO.DOMINIOMAP;
using NUINFDOMINIO;
using System;
using System.Collections.Generic;
using System.Text;

namespace NUINFDAO.INTERFACES
{
  public  interface ITelefoneDao
    {
        int Salvar(Telefone pTelefone);
        IEnumerable<Telefone> ListarTodos();
        int Editar(Telefone pTelefone);
        bool Excluir(int idTel);
        Telefone Pesquisar(Telefone pTelefone);
    }
}
