using CadastroPessoasApi.Service;
using CadastroPessoasApi.ViewModel;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CadastroPessoasApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PessoaController : ControllerBase
    {
        [HttpGet("GetAll")]
        public IEnumerable<PessoaViewModel> GetAll()
        {
            var service = new ServicePessoa();
            return service.GetAll();


        }
        [HttpGet("GetById/{pessoaId}")]
        public PessoaViewModel GetById(int pessoaId)
        {
          var service = new ServicePessoa();
          return service.GetById(pessoaId);
        }
        [HttpGet("GetByIdprimeiroNome/{primeiroNome}")]
        public PessoaViewModel GetByprimeiroNome(string primeiroNome)
        {
            var service = new ServicePessoa();
            return service.GetByprimeiroNome(primeiroNome);
        }
        [HttpPut("UpdateById/{pessoaId}")]

        public void Update(int pessoaId, string novoNome)
        {
            var service = new ServicePessoa();
            service.Update(pessoaId, novoNome);
        }
        [HttpPost("create")]

        public ActionResult Create(PessoaViewModel pessoa)
        {
            var service = new ServicePessoa();
            var resultado = service.Create(pessoa);

            var result = new
            {
                success = true,
                Data = resultado,
            };
            return Ok (result);
        }

    }
}
