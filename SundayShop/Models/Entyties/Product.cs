using System.ComponentModel.DataAnnotations;

namespace SundayShop.Models.Entyties;

public class Product
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    
    [Required]
    [Range((int)ProductType.Shoe, (int)ProductType.Bag, ErrorMessage = "Invalid product type")]
    public ProductType ClotheType { get; set; }
    
    public List<Review>? Reviews { get; set; }
}