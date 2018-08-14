using NUINFDAO.CONTEXTOS;
using NUINFDAO.DAO;
using NUINFDOMINIO;
using NUINFREPOSITORIO.DTO;
using NUINFREPOSITORIO.InfraEstrutura;
using System;
using System.Collections.Generic;
using System.Text;

namespace NUINFREPOSITORIO.Repositorios
{
    public class TelefoneRepositorio : ITelefoneRepositorio
    {
        private TelefoneDao dao;
        private readonly BD_Nuinf_Context _nuinf_Context;

        public TelefoneRepositorio()
        {
            dao = new TelefoneDao(_nuinf_Context);
        }


        public IEnumerable<TelefoneDTOList> ListarTodos()
        {
            TelefoneDTOList lTel = new TelefoneDTOList();
            List<TelefoneDTOList> lListTels = new List<TelefoneDTOList>();
            var telefones = dao.ListarTodos();

            foreach (var t in telefones)
            {
                lTel.codTel = t.id.ToString();
                lTel.dddTel = t.ddd;
                lTel.numTel = t.numeros;
                lListTels.Add(lTel);
            }

            return lListTels;
        }

        public int Editar(TelefoneDTOPersistencia pTel)
        {
            if (pTel == null || pTel.codTel == "0")
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

        public int Salvar(TelefoneDTOPersistencia pTel)
        {
            Telefone lTelefone = new Telefone();

            if (pTel.codTel != null && Convert.ToInt64(pTel.codTel) > 0)
            {
                lTelefone.ddd = pTel.dddTel;
                lTelefone.numeros = pTel.numTel;
                lTelefone.Pessoa = new Pessoa();
                lTelefone.Pessoa.id = Convert.ToInt32(pTel.codPessoa);

                return dao.Salvar(lTelefone);
            }
            else
            {
                lTelefone.id = Convert.ToInt32(pTel.codTel);
                lTelefone.ddd = pTel.dddTel;
                lTelefone.numeros = pTel.numTel;
                lTelefone.Pessoa = new Pessoa();
                lTelefone.Pessoa.id = Convert.ToInt32(pTel.codPessoa);

                return dao.Editar(lTelefone);
            }
        }
    }
}
