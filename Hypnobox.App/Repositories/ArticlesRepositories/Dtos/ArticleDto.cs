namespace Hypnobox.App.Repositories.ArticlesRepositories.Dtos;

#pragma warning disable IDE1006 // Naming Styles
internal record TopArticlesApiDto(int page, int per_page, int total, int total_pages, List<ArticleDto> data);
#pragma warning restore IDE1006 // Naming Styles
internal record struct ArticleDto(string? title, string? store_title, int? num_comments);