using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using SundayShop.Models.Entyties;

namespace SundayShop.DTOs.Product;

public class CreateProductRequestDto
{
    public string Name { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    
    [Required]
    [Range((int)ProductType.Shoe, (int)ProductType.Bag, ErrorMessage = "Invalid product type")]
    public ProductType ClotheType { get; set; }
}