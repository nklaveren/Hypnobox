using System.Net.Http.Json;

using Hypnobox.App.Repositories.ArticlesRepositories.Dtos;

namespace Hypnobox.App.Repositories.ArticlesRepositories;

internal class ArticlesRepository : IArticlesRepository
{
    private string URL = "http://mock-api.hypnobox.com.br:4011/teste/api/articles?page={0}";

    private readonly HttpClient _httpClient;
    public ArticlesRepository(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public Task<TopArticlesApiDto?> GetPagedAsync(int page)
        => _httpClient.GetFromJsonAsync<TopArticlesApiDto>(string.Format(URL, page));

}
