
using Hypnobox.App;
using Hypnobox.App.Repositories.ArticlesRepositories;

//FootballScores.Run();
var httpClient = new HttpClient();
IArticlesRepository repository = new ArticlesRepository(httpClient);
var service = new TopArticlesService(repository);
await service.Execute();