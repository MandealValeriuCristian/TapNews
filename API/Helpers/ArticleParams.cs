namespace API.Helpers;

public class ArticleParams : PaginationParams
{
    public string? OrderByDate { get; set; }
    public string? SearchTerm { get; set; }
}
