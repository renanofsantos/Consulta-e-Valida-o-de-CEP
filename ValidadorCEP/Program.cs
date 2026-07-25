using ValidadorCEP.Services;

// cria o construtor da aplicação, aqui que tudo eh configurado
// antes da aplicação realmente começar a rodar
var builder = WebApplication.CreateBuilder(args);


builder.Services.AddControllers();

builder.Services.AddRazorPages();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// registra IEnderecoService -> EnderecoService, e já garante que todo
// EnderecoService criado recebe um HttpClient configurado
// automaticamente no construtor, eh essa linha que permite tanto o
// Controller quanto a Razor Page pedirem "IEnderecoService" e
// receberem uma instância pronta p uso
builder.Services.AddHttpClient<IEnderecoService, EnderecoService>();

// a partir daqui a aplicação ta montada e pronta pra rodar
var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseStaticFiles();

app.UseAuthorization();

app.MapControllers();

app.MapRazorPages();

app.Run();
