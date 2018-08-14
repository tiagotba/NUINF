using NUINFDAO.DOMINIOMAP;
using System;
using System.Collections.Generic;
using System.Text;

namespace NUINFDAO.INTERFACES
{
  public  interface ITelefoneDao
    {
        bool Salvar(TelefoneMap pTelefone);
        IEnumerable<TelefoneMap> ListarTodos();
        void Editar(TelefoneMap pTelefone);
        TelefoneMap Pesquisar(TelefoneMap pTelefone);
    }
}
