using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using NUINFREPOSITORIO.InfraEstrutura;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace NUINFAPI.Controllers
{
    [Route("api/[controller]")]
    public class PessoaController : Controller
    {
        private readonly IPessoaRepositorio _pessoaRepositorio;

        public PessoaController(IPessoaRepositorio pessoaRepositorio)
        {
            _pessoaRepositorio = pessoaRepositorio;
        }
        // GET: api/<controller>
        [EnableCors("MyPolicy")]
        [HttpGet]
        public IEnumerable<NUINFREPOSITORIO.DTO.PessoasDTOList> Get()
        {
            var pessoas = _pessoaRepositorio.ListarTodos();
            return pessoas;
        }

        // GET api/<controller>/5
        [HttpGet("{id}")]
        public NUINFREPOSITORIO.DTO.PessoaDTOShow Get(int id)
        {
            NUINFREPOSITORIO.DTO.PessoaDTOPersistencia pessoaDTOPersistencia = new NUINFREPOSITORIO.DTO.PessoaDTOPersistencia();
            pessoaDTOPersistencia.codPessoa = id.ToString();
            return _pessoaRepositorio.Pesquisar(pessoaDTOPersistencia);
        }

        // POST api/<controller>
        [HttpPost]
        public void Post([FromBody]NUINFREPOSITORIO.DTO.PessoaDTOPersistencia value)
        {
            _pessoaRepositorio.Salvar(value);
        }

        // PUT api/<controller>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]NUINFREPOSITORIO.DTO.PessoaDTOPersistencia value)
        {
            value.codPessoa = id.ToString();
            if (_pessoaRepositorio.Salvar(value) == 0)
            {
                var resp = new System.Net.Http.HttpResponseMessage(System.Net.HttpStatusCode.NotFound)
                {
                    Content = new System.Net.Http.StringContent(string.Format("Não há pessoas com esse codigo ID = {0}", id)),
                    ReasonPhrase = " Not Found"
                };
            }
        }

        // DELETE api/<controller>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            if (!_pessoaRepositorio.Excluir(id))
            {
                var resp = new System.Net.Http.HttpResponseMessage(System.Net.HttpStatusCode.NotFound)
                {
                    Content = new System.Net.Http.StringContent(string.Format("Não há pessoas com esse codigo ID = {0}", id)),
                    ReasonPhrase = " Not Found"
                };
            }
        }
    }
}
