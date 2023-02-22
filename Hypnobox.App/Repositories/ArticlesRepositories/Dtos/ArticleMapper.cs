using Hypnobox.App.Domain;

namespace Hypnobox.App.Repositories.ArticlesRepositories.Dtos;

internal static class ArticleMapper
{
    internal static IEnumerable<Article> From(List<ArticleDto> data)
    {
        foreach (var article in data)
        {
            yield return From(article);
        }
    }

    internal static Article From(ArticleDto dto) => new()
    {
        Title = dto.title,
        StoreTitle = dto.store_title,
        Comments = dto.num_comments ?? 0,
    };
}