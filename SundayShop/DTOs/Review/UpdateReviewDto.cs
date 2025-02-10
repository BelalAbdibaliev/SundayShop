namespace SundayShop.DTOs.Review;

public class UpdateReviewDto
{
    public int Rate { get; set; }
    public string Comment { get; set; } = string.Empty;
}