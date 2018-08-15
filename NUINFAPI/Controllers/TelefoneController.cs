using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using NUINFREPOSITORIO.InfraEstrutura;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace NUINFAPI.Controllers
{
    [Route("api/[controller]")]
    public class TelefoneController : Controller
    {
        private readonly ITelefoneRepositorio _telefoneRepositorio;

        public TelefoneController(ITelefoneRepositorio telefoneRepositorio)
        {
            _telefoneRepositorio = telefoneRepositorio;
        }

        // GET: api/<controller>
        [HttpGet]
        public IEnumerable<NUINFREPOSITORIO.DTO.TelefoneDTOList> Get()
        {
            var telefones = _telefoneRepositorio.ListarTodos();
            return telefones ;
        }

        // GET api/<controller>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<controller>
        [HttpPost]
        public void Post([FromBody]NUINFREPOSITORIO.DTO.TelefoneDTOPersistencia value)
        {
            _telefoneRepositorio.Salvar(value);
        }

        // PUT api/<controller>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]NUINFREPOSITORIO.DTO.TelefoneDTOPersistencia value)
        {
            value.codTel = id.ToString();
            _telefoneRepositorio.Salvar(value);
            
        }

        // DELETE api/<controller>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            if (!_telefoneRepositorio.Excluir(id))
            {
                var resp = new System.Net.Http.HttpResponseMessage(System.Net.HttpStatusCode.NotFound)
                {
                    Content = new System.Net.Http.StringContent("Não há pessoas com esse telefone"),
                    ReasonPhrase = " Not Found"
                };
            }
        }
    }
}
