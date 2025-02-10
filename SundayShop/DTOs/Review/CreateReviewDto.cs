namespace SundayShop.DTOs.Review;

public class CreateReviewDto
{
    public int Rate { get; set; }
    public string Comment { get; set; } = string.Empty;
}