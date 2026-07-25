namespace ValidadorCEP.Models
{
    
  //classe pra representar
    // a "forma" dos dados que a API da ViaCEP devolve em JSON
    // cada propriedade abaixo corresponde a um campo do JSON da ViaCEP

    public class EnderecoViaCep
    {
        public string Cep { get; set; }

        public string Logradouro { get; set; }

        public string Complemento { get; set; }

        public string Unidade { get; set; }

        public string Bairro { get; set; }

        public string Localidade { get; set; }

        public string Uf { get; set; }

        public string Regiao { get; set; }

        public string Ibge { get; set; }

        public string Gia { get; set; }

        public string Ddd { get; set; }

        public string Siafi { get; set; }

    }
}
