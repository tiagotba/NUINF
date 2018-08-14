using NUINFDAO.CONTEXTOS;
using NUINFDAO.INTERFACES;
using NUINFDOMINIO;
using System;
using System.Collections.Generic;
using System.Text;

namespace NUINFDAO.DAO
{
    public class TelefoneDao : ITelefoneDao
    {
        private readonly BD_Nuinf_Context _nuinf_Context;

        public TelefoneDao(BD_Nuinf_Context nuinf_Context)
        {
            _nuinf_Context = nuinf_Context;
        }

        public int Editar(Telefone pTelefone)
        {
            var telefone = Pesquisar(pTelefone);
            if (pTelefone != null)
            {
                _nuinf_Context.Entry(pTelefone).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                return _nuinf_Context.SaveChanges();
            }
            else
            {
                return 0;
            }
        }

        public IEnumerable<Telefone> ListarTodos()
        {
            var telefones = _nuinf_Context.Telefones;
            return telefones;
        }

        public Telefone Pesquisar(Telefone pTelefone)
        {
            return _nuinf_Context.Telefones.Find(pTelefone.id);
        }

        public int Salvar(Telefone pTelefone)
        {
            _nuinf_Context.Entry(pTelefone).State = Microsoft.EntityFrameworkCore.EntityState.Added;
            return _nuinf_Context.SaveChanges();
        }
    }
}
