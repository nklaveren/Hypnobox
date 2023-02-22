namespace Hypnobox.App.Domain;

public class Article
{
    public string? Title { get; set; }
    public string? StoreTitle { get; set; }
    public int Comments { get; set; }
    private bool HasTitle => !string.IsNullOrEmpty(Title);
    private bool HasStoreTitle => !string.IsNullOrEmpty(StoreTitle);
    public bool IsValid => HasTitle || HasStoreTitle;
    public string? ValidTitle => Title ?? StoreTitle;

}
