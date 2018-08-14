using NUINFDOMINIO;
using NUINFREPOSITORIO.DTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace NUINFREPOSITORIO.InfraEstrutura
{
  public  interface ITelefoneRepositorio
    {
        int Salvar(TelefoneDTOPersistencia pTelefone);
        IEnumerable<TelefoneDTOList> ListarTodos();
        int Editar(TelefoneDTOPersistencia pTelefone);
        bool Excluir(int idTel);
    }
}
