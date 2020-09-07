using Microsoft.AspNetCore.Mvc;
using SADomain.Entities;
using SADomain.Interfaces.Application;
using System.Collections.Generic;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace SAApi.Controllers
{
    [Route("api/Pessoa")]
    [ApiController]
    public class PessoaController : ControllerBase
    {
        private readonly IPessoaApp _pessoaApp;

        public PessoaController(IPessoaApp pessoaApp)
        {
            this._pessoaApp = pessoaApp;
        }

        // GET: api/<PessoaController>
        [HttpGet]
        public IList<Pessoa> ListarPessoas() =>
            _pessoaApp.Listar();

        // GET api/<PessoaController>/5
        [HttpGet("{id}")]
        public Pessoa ListarPessoas(string id) =>
            _pessoaApp.BuscarPeloId(id);

        // POST api/<PessoaController>
        [HttpPost]
        public void Post([FromBody] Pessoa pessoa)
        {
            _pessoaApp.Cadastrar(pessoa);
        }

        // PUT api/<PessoaController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<PessoaController>/5
        [HttpDelete("{id}")]
        public void Delete(string id)
        {
            _pessoaApp.Excluir(id);
        }
    }
}
