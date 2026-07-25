using ValidadorCEP.Models;

namespace ValidadorCEP.Services
{
    // uma interface é um "contrato" ela declara QUAIS métodos devem
    // existir mas não implementa nenhum deles
    
    public interface IEnderecoService
    {
        // Task<T> indica que eh um método assincrono que quando
        // terminar devolve um EnderecoViaCep
        // o parâmetro "cep" é o texto digitado pelo usuario
        Task<EnderecoViaCep> ObterEnderecoPorCepAsync(string cep);
    }
}
