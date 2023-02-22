namespace Hypnobox.App.Repositories.ArticlesRepositories.Dtos;

internal record TopArticlesApiDto(int page, int per_page, int total, int total_pages, List<ArticleDto> data);
internal record struct ArticleDto(string? title, string? store_title, int? num_comments);