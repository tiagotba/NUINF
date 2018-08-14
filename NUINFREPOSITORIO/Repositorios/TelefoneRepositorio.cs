using NUINFDAO.CONTEXTOS;
using NUINFDAO.DAO;
using NUINFDOMINIO;
using System;
using System.Collections.Generic;
using System.Text;

namespace NUINFREPOSITORIO.Repositorios
{
 public class TelefoneRepositorio
    {
        private TelefoneDao dao;
        private readonly BD_Nuinf_Context _nuinf_Context;

        public TelefoneRepositorio()
        {
            dao = new TelefoneDao(_nuinf_Context);
        }


        public IEnumerable<Telefone> ListarTodos()
        {
            return dao.ListarTodos();
        }

        public int Editar(Telefone pTel)
        {
            if (pTel == null || pTel.id == 0)
            {
                throw new Exception("Número não encontrado!");
            }
            else
            {
                return Salvar(pTel);
            }
        }

        public bool Excluir(int idTel)
        {
            if (dao.Excluir(idTel))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public int Salvar(Telefone pTel)
        {
            if (pTel.id == 0)
            {
                return dao.Salvar(pTel);
            }
            else
            {
                return dao.Editar(pTel);
            }
        }
    }
}
