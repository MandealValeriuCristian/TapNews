namespace API.Entities;

public class Category
{
    public int Id { get; set; }
    public string Name { get; set; }
    public DateTime CreatedAt { get; set; }
    public List<Article> Articles { get; set; }

}