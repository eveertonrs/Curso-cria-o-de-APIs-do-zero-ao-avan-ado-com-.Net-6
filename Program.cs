var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

app.MapGet("/", () => "Hello World! 4");
app.MapGet("/user", () => "Everton Barbosa");
app.MapPost("/user", () => new {Name = "Everton barbosa", Age = 26});

app.MapPost("/salvar", (Produto produto) => {
    return produto.Codigo +  " - " + produto.Nome;
});

app.Run();


public class Produto { 
    public string Codigo { get; set; }
    public string Nome { get; set; }
}
