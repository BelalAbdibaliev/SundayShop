using System.Text.Json.Serialization;
using SundayShop.DTOs.Review;
using SundayShop.Models.Entyties;

namespace SundayShop.DTOs.Product;

public class ProductDto
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public ProductType ClotheType { get; set; }
    public List<ReviewDto>? Reviews { get; set; }
}