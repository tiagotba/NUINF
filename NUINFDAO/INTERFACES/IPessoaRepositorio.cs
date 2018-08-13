using NUINFDAO.DOMINIOMAP;
using System;
using System.Collections.Generic;
using System.Text;

namespace NUINFDAO.INTERFACES
{
  public  interface IPessoaRepositorio
    {
        bool Salvar(PessoaMap pPessoa);
        IEnumerable<PessoaMap> ListarTodos();
        void Editar(PessoaMap pPessoa);
        PessoaMap Pesquisar(PessoaMap pPessoa);
    }
}
