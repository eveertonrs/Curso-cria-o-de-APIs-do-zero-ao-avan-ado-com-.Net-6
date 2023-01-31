using Microsoft.AspNetCore.Mvc;

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

//Salva o produto em memoria
app.MapPost("/produtos", (Produto produto) => {
    RepositorioProduto.Add(produto);
    return Results.Created($"/produtos/{produto.Codigo}", produto.Codigo);
});

//Pega o produto na memoria por ID
app.MapGet("/produtos/{codigo}", ([FromRoute] string codigo) => {
    var produto = RepositorioProduto.Getby(codigo);
    if(produto != null)
    return Results.Ok(produto);
        return Results.NotFound(produto);

});

//Edita o produto
app.MapPut("/produtos",(Produto produto) => {
    //Busca o produto salvo pelo o ID
    var produtosalvo = RepositorioProduto.Getby(produto.Codigo);
    //edita a variavel nome
    produtosalvo.Nome = produto.Nome;
    return Results.Ok(); 
});

app.MapDelete("/produtos/{codigo}", ([FromRoute] string codigo) => {
     var produtosalvo = RepositorioProduto.Getby(codigo);
     RepositorioProduto.Remove(produtosalvo);
     return Results.Ok();
});

app.Run();


//Repositorio para salvar dados em memoria sem banco de dados
// Lista para salvar os produtos e função para adicionar a essa lista
public class  RepositorioProduto{
    public static List<Produto> Produtos { get; set; }

    //Adiciona o produto na Lista produto
    public static void Add(Produto produto){
        if(Produtos == null)
            Produtos = new List<Produto>();

        Produtos.Add(produto);
    }

    public static Produto Getby(string codigo){
        return Produtos.FirstOrDefault(p => p.Codigo == codigo);
    }
    public static void Remove(Produto produto){
        Produtos.Remove(produto);
    }
}

public class Produto { 
    public string Codigo { get; set; }
    public string Nome { get; set; }
}
