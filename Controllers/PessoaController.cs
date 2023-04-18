using Microsoft.AspNetCore.Mvc;
using PrimeiraApiConsulta.Models;
using PrimeiraApiConsulta.Models.Interfaces;

namespace PrimeiraApiConsulta.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PessoaController : ControllerBase
    {
        public readonly IPessoa _pessoa;

        public PessoaController(IPessoa pessoa)
        {
            _pessoa = pessoa;
        }

        [HttpGet("[action]")]
        public List<Pessoa> ObterPessoas()
        {
            return _pessoa.ObterPessoas();
        }

        /*[HttpGet]
        public Pessoa ObterPessoaById(int id)
        {
            Pessoa pessoa = new Pessoa();
            return pessoa.ObterPessoaById(id);
        }

        [HttpGet("{controller}/{action}/{id}/{idTeste}")]
        public Pessoa ObterPessoaById([FromRoute]int id, [FromRoute] int idTeste)
        {
            Pessoa pessoa = new Pessoa();
            return pessoa.ObterPessoaById(id);
        }

        [HttpGet("{controller}/{action}/{id}")]
        public Pessoa ObterPessoaById([FromRoute] int id, [FromQuery] string idTeste)
        {
            Pessoa pessoa = new Pessoa();
            return pessoa.ObterPessoaById(id);
        }*/
    }
}
