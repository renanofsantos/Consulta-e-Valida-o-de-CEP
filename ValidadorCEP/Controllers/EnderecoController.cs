using Microsoft.AspNetCore.Mvc;
using ValidadorCEP.Models;
using ValidadorCEP.Services;

namespace ValidadorCEP.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EnderecoController : ControllerBase
    {
        // guarda a dependência recebida via injecao
        private readonly IEnderecoService _enderecoService;

        public EnderecoController(IEnderecoService enderecoService)
        {
            _enderecoService = enderecoService;
        }
        [HttpGet("{cep}")]
        public async Task<ActionResult<EnderecoViaCep>> ObterEndereco(string cep)
        {
            // chama o Service pra buscar o endereço "await" espera a
            // resposta sem travar a aplicacao
            var endereco = await _enderecoService.ObterEnderecoPorCepAsync(cep);

            if (endereco == null)
            {
                return BadRequest("CEP inválido ou não encontrado!");
            }
            
            return Ok(endereco);
        }
    }
}
