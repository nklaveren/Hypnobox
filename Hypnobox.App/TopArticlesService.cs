using Hypnobox.App.Domain;
using Hypnobox.App.Repositories.ArticlesRepositories;
using Hypnobox.App.Repositories.ArticlesRepositories.Dtos;

namespace Hypnobox.App;

internal class TopArticlesService
{
    private readonly IArticlesRepository articlesRepository;

    public TopArticlesService(IArticlesRepository articlesRepository)
    {
        this.articlesRepository = articlesRepository;
    }

    public async Task Execute()
    {
        var articles = await GetAllArticles();

        var validArticles = articles.Where(x => x.IsValid)
            .OrderByDescending(x => x.Comments)
            .ThenByDescending(x => x.Title)
            .ToList();

        validArticles.ForEach(article =>
        {
            Console.WriteLine($"Article: {article.ValidTitle}, Comments:{article.Comments}");
        });

        Console.ReadKey();
    }

    private async Task<List<Article>> GetAllArticles()
    {
        List<Article> articles = new();

        var firstRequest = await articlesRepository.GetPagedAsync(1);
        if (firstRequest == null) return articles;
        var totalPages = firstRequest.total_pages;

        articles.AddRange(ArticleMapper.From(firstRequest.data));

        if (totalPages > 1)
        {
            var tasks = Enumerable.Range(2, totalPages).Select(async x => await articlesRepository.GetPagedAsync(x));
            var results = await Task.WhenAll(tasks);
            articles.AddRange(results.Where(x => x != null).SelectMany(x => ArticleMapper.From(x!.data)));
        }

        return articles;
    }
}