using Hypnobox.App.Repositories.ArticlesRepositories.Dtos;

namespace Hypnobox.App.Repositories.ArticlesRepositories
{
    internal interface IArticlesRepository
    {
        Task<TopArticlesApiDto> GetPagedAsync(int page);
    }
}