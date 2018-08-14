using NUINFDAO.DOMINIOMAP;
using NUINFDOMINIO;
using System;
using System.Collections.Generic;
using System.Text;

namespace NUINFDAO.INTERFACES
{
  public  interface IPessoaDao
    {
        int Salvar(Pessoa pPessoa);
        IEnumerable<Pessoa> ListarTodos();
        int Editar(Pessoa pPessoa);
        Pessoa Pesquisar(Pessoa pPessoa);
    }
}
