namespace API.DTOs;

public class ArticleDto
{
    public string Title { get; set; }
    public string Description { get; set; }
    public DateTime CreatedAt { get; set; } = DateTime.Now;
    public CategoryDto Category { get; set; }
}
