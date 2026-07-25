using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ValidadorCEP.Models;
using ValidadorCEP.Services;

namespace ValidadorCEP.Pages
{
    public class IndexModel : PageModel
    {
        private readonly IEnderecoService _enderecoService;

        public IndexModel(IEnderecoService enderecoService)
        {
            _enderecoService = enderecoService;
        }
        [BindProperty]
        public string Cep { get; set; }

        public EnderecoViaCep? Endereco { get; set; }

        // guarda uma mensagem de erro, se a busca falhar
        public string? MensagemErro { get; set; }

          public void OnGet()
        {
        }

         public async Task OnPostAsync()
        {
         
            Endereco = await _enderecoService.ObterEnderecoPorCepAsync(Cep);

            if (Endereco == null)
            {
             
                MensagemErro = "CEP inválido ou não encontrado.";
            }
        }
    }
}
