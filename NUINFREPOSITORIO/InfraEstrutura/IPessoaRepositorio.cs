using NUINFDOMINIO;
using NUINFREPOSITORIO.DTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace NUINFREPOSITORIO.InfraEstrutura
{
  public  interface IPessoaRepositorio
    {
        int Salvar(PessoaDTOPersistencia pPessoa);
        IEnumerable<PessoasDTOList> ListarTodos();
        int Editar(PessoaDTOPersistencia pPessoa);
        bool Excluir(int idPessoa);
        PessoaDTOShow Pesquisar(PessoaDTOPersistencia pPessoa);
    }
}
