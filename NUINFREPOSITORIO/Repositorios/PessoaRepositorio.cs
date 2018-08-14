using NUINFDAO.CONTEXTOS;
using NUINFDAO.DAO;
using NUINFDOMINIO;
using System;
using System.Collections.Generic;
using System.Text;

namespace NUINFREPOSITORIO.Repositorios
{
    public class PessoaRepositorio
    {
        private PessoaDao dao;

        private readonly BD_Nuinf_Context _nuinf_Context;

        public PessoaRepositorio()
        {
            dao = new PessoaDao(_nuinf_Context);
        }

        public IEnumerable<Pessoa> ListarTodos()
        {
            return dao.ListarTodos();
        }

        public int Editar(Pessoa pPessoa)
        {
            if (pPessoa == null || pPessoa.id == 0)
            {
                throw new Exception("Pessoa não encontrada!");
            }
            else
            {
                return Salvar(pPessoa);
            }
        }

        public bool Excluir(int idPessoa)
        {
            if (dao.Excluir(idPessoa))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public int Salvar(Pessoa pPessoa)
        {
            if (pPessoa.id == 0)
            {
                return dao.Salvar(pPessoa);
            }
            else
            {
                return dao.Editar(pPessoa);
            }
        }
    }
}
