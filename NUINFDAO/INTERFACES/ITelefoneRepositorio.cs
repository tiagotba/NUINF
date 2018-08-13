using NUINFDAO.DOMINIOMAP;
using System;
using System.Collections.Generic;
using System.Text;

namespace NUINFDAO.INTERFACES
{
  public  interface ITelefoneRepositorio
    {
        bool Salvar(TelefoneMap pTelefone);
        IEnumerable<TelefoneMap> ListarTodos();
        void Editar(TelefoneMap pTelefone);
        TelefoneMap Pesquisar(TelefoneMap pTelefone);
    }
}
