﻿using NUINFDAO.CONTEXTOS;
using NUINFDAO.DOMINIOMAP;
using NUINFDAO.INTERFACES;
using NUINFDOMINIO;
using System;
using System.Collections.Generic;
using System.Text;

namespace NUINFDAO.DAO
{
    public class PessoaDao : IPessoaDao
    {
        private readonly BD_Nuinf_Context _nuinf_Context;

        public PessoaDao(BD_Nuinf_Context nuinf_Context)
        {
            _nuinf_Context = nuinf_Context;
        }

        public int Editar(Pessoa pPessoa)
        {
            var pessoa = Pesquisar(pPessoa);
            if (pessoa != null)
            {
                _nuinf_Context.Entry(pPessoa).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                return _nuinf_Context.SaveChanges();
            }
            else
            {
                return 0;
            }
           
        }

        public IEnumerable<Pessoa> ListarTodos()
        {
            var pessoas = _nuinf_Context.Pessoas;
            return pessoas;
        }

        public Pessoa Pesquisar(Pessoa pPessoa)
        {
            return _nuinf_Context.Pessoas.Find(pPessoa.id);
        }

        public int Salvar(Pessoa pPessoa)
        {
            _nuinf_Context.Entry(pPessoa).State = Microsoft.EntityFrameworkCore.EntityState.Added;
            return _nuinf_Context.SaveChanges();
        }
    }
}