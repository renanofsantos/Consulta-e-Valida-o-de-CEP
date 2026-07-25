using System.Text.Json;
using ValidadorCEP.Models;

namespace ValidadorCEP.Services
{
    
    public class EnderecoService : IEnderecoService
    {
        private readonly HttpClient _httpClient;

        public EnderecoService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<EnderecoViaCep> ObterEnderecoPorCepAsync(string cep)
        {
            var url = $"https://viacep.com.br/ws/{cep}/json/";

            try
            {
                string json = await _httpClient.GetStringAsync(url);

                var opcoes = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };

                EnderecoViaCep endereco = JsonSerializer.Deserialize<EnderecoViaCep>(json, opcoes);

                return endereco;
            }
            catch (HttpRequestException)
            {
                return null;
            }
        }
    }
}
