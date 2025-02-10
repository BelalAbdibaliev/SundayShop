namespace SundayShop.DTOs.Review;

public class ReviewDto
{
    public int Id { get; set; }
    public int Rate { get; set; }
    public string Comment { get; set; } = string.Empty;
    public DateTime CreatedIn { get; set; } = DateTime.Now;
    
    public int? ProductId { get; set; }
}