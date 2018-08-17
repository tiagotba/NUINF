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
    public class PessoaRepositorio : IPessoaRepositorio
    {
        private PessoaDao dao;

        private TelefoneDao telefoneDao;

        private readonly BD_Nuinf_Context _nuinf_Context = new BD_Nuinf_Context();

        public PessoaRepositorio()
        {
            dao = new PessoaDao(_nuinf_Context);
            telefoneDao = new TelefoneDao(_nuinf_Context);
        }


        public int Editar(PessoaDTOPersistencia pPessoa)
        {
            if (pPessoa == null || pPessoa.codPessoa == "0")
            {
                return 0;
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

        public int Salvar(PessoaDTOPersistencia pPessoa)
        {
            Pessoa lPessoa = new Pessoa();
            int idPessoa = 0;

            if (pPessoa.codPessoa != null && Convert.ToInt64(pPessoa.codPessoa) == 0)
            {
                lPessoa.nome = pPessoa.nomePessoa;
                lPessoa.cpf = pPessoa.cpfPessoa;
                lPessoa.dataNascimento = Convert.ToDateTime(pPessoa.nascPessoa);
                lPessoa.email = pPessoa.emailPessoa;
                lPessoa.telefones = new List<Telefone>();

                idPessoa = dao.Salvar(lPessoa);

                if (pPessoa.telefones != null)
                {
                    Telefone lTelefone;
                    foreach (var tel in pPessoa.telefones)
                    {
                        lTelefone = new Telefone();
                        lTelefone.ddd = tel.dddTel;
                        lTelefone.numeros = tel.numTel;
                        lTelefone.Pessoa = lPessoa;
                        telefoneDao.Salvar(lTelefone);
                    }
                }

                return idPessoa;
            }
            else
            {
                lPessoa.id = Convert.ToInt32(pPessoa.codPessoa);
                lPessoa.nome = pPessoa.nomePessoa;
                lPessoa.cpf = pPessoa.cpfPessoa;
                lPessoa.dataNascimento = Convert.ToDateTime(pPessoa.nascPessoa);
                lPessoa.email = pPessoa.emailPessoa;

                if (pPessoa.telefones != null)
                {
                    Telefone lTelefone;
                    foreach (var tel in pPessoa.telefones)
                    {
                        lTelefone = new Telefone();
                        lTelefone.ddd = tel.dddTel;
                        lTelefone.numeros = tel.numTel;
                        lTelefone.Pessoa = lPessoa;
                        telefoneDao.Salvar(lTelefone);
                    }
                }

                return dao.Editar(lPessoa);
            }
        }


        IEnumerable<PessoasDTOList> IPessoaRepositorio.ListarTodos()
        {
            PessoasDTOList lPessoa = new PessoasDTOList();
            List<PessoasDTOList> lListPessoas = new List<PessoasDTOList>();
            var pessoas = dao.ListarTodos();
            foreach (var p in pessoas)
            {
                lPessoa.codPessoa = p.id.ToString();
                lPessoa.nomePessoa = p.nome;
                lPessoa.emailPessoa = p.email;
                lPessoa.cpfPessoa = p.cpf;
                var hoje = DateTime.Today;

                // calculo da idade da pessoa
                var a = (hoje.Year * 100 + hoje.Month) * 100 + hoje.Day;
                var b = (p.dataNascimento.Year * 100 + p.dataNascimento.Month) * 100 + p.dataNascimento.Day;

                lPessoa.idadePessoa = ((a - b) / 10000).ToString();

                // traz o total de telefones
                //lPessoa.qtdTel = dao.TotalTelefones((int)p.id).ToString();
                lListPessoas.Add(lPessoa);
            }

            return lListPessoas;
        }

        public PessoaDTOShow Pesquisar(PessoaDTOPersistencia pPessoa)
        {
            Pessoa lPessoa = new Pessoa();
            PessoaDTOShow lPessoaDTOShow = new PessoaDTOShow();
            TelefoneDTOPersistencia lTelefoneDTOPersistencia = new TelefoneDTOPersistencia();
            lPessoa.id = Convert.ToInt32(pPessoa.codPessoa);
            lPessoa = dao.Pesquisar(lPessoa);

            lPessoaDTOShow.codPessoa = lPessoa.id.ToString();
            lPessoaDTOShow.nomePessoa = lPessoa.nome;
            lPessoaDTOShow.cpfPessoa = lPessoa.cpf;
            lPessoaDTOShow.emailPessoa = lPessoa.email;
            lPessoaDTOShow.nascPessoa = lPessoa.dataNascimento.ToString();
            lPessoaDTOShow.telefones = new List<TelefoneDTOPersistencia>();
            if (lPessoa.telefones != null)
            {

                foreach (var t in lPessoa.telefones)
                {
                    lTelefoneDTOPersistencia.codTel = t.id.ToString();
                    lTelefoneDTOPersistencia.dddTel = t.ddd;
                    lTelefoneDTOPersistencia.numTel = t.numeros;
                    lPessoaDTOShow.telefones.Add(lTelefoneDTOPersistencia);
                }
            }
            

            return lPessoaDTOShow;
        }

    }
}
