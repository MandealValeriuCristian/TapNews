using API.Entities;

namespace API.Extensions;

public static class ArticleExtentions
{
    public static IQueryable<Article> Search(this IQueryable<Article> query, string searchTerm)
    {
        if (string.IsNullOrEmpty(searchTerm)) return query;

        var lowerCaseSearchTerm = searchTerm.Trim().ToLower();
        return query.Where(a => a.Title.ToLower().Contains(lowerCaseSearchTerm) 
        ||  a.Description.ToLower().Contains(lowerCaseSearchTerm));
    }
    public static IQueryable<Article> Sort(this IQueryable<Article> query, string orderBy)
    {
        if (string.IsNullOrEmpty(orderBy)) return query.OrderBy(a => a.Title);
        var lowerCaseOrderBy = orderBy.Trim().ToLower();
        query = lowerCaseOrderBy switch
        {
            "asc" => query.OrderBy(a => a.CreatedAt),
            "desc" => query.OrderByDescending(a => a.CreatedAt),
            _ => query.OrderBy(a => a.Title)
        };
        return query;

    }
}
