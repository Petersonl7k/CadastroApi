    using CadastroPessoasAPI.Data;
    using CadastroPessoasAPI.Service;
    using CadastroPessoasAPI.ViewModel;
    using Microsoft.AspNetCore.Http;
    using Microsoft.AspNetCore.Mvc;
    using System.Net.Mime;

    namespace CadastroPessoasAPI.Controllers
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

            [HttpGet("GetByName/{primeiroNome}")]
            public PessoaViewModel GetByName(string primeiroNome) 
            {
                var service = new ServicePessoa();
                return service.GetByName(primeiroNome);
            }
            [HttpPut("update/{pessoaId}/{PrimeiroNome}/{segundoNome?}/{ultimoNome?}/{CPF?}")]
            public void UpdatePeopleName(int pessoaId, string PrimeiroNome, string segundoNome, string ultimoNome, string CPF) 
            {
                var service = new ServicePessoa();
                service.UpdatePeopleName(pessoaId, PrimeiroNome, segundoNome, ultimoNome, CPF);
            }
            [HttpPost("Create")]
            public ActionResult Create(PessoaViewModel pessoa) 
            {
                var service = new ServicePessoa();
                var resultado = service.Create(pessoa);

                var result = new
                {
                    Success = true,
                    Data = resultado,
                };
                return Ok(result);
            }   


        
        }
    }
