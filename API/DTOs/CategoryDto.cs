namespace API.DTOs;

public class CategoryDto
{
    public string Name { get; set; }
    public DateTime CreatedAt { get; set; } = DateTime.Now;
}
