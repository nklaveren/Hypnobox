
using Hypnobox.App;
using Hypnobox.App.Repositories.ArticlesRepositories;

Console.WriteLine("Iniciando execução exercicio 1");
FootballScores.Run();
Console.WriteLine("FIM exercicio 1\n\n");

Console.WriteLine("Iniciando execução exercicio 2");
var httpClient = new HttpClient();
IArticlesRepository repository = new ArticlesRepository(httpClient);
var service = new TopArticlesService(repository);
await service.Execute();
Console.WriteLine("Finalizando execução exercicio 2");

Console.ReadKey();