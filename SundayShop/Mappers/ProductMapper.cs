using SundayShop.DTOs.Product;
using SundayShop.DTOs.Review;
using SundayShop.Models.Entyties;

namespace SundayShop.Mappers;

public static class ProductMapper
{
    public static ProductDto ToProductDto(this Product productModel)
    {
        return new ProductDto
        {
            Id = productModel.Id,
            Name = productModel.Name,
            Description = productModel.Description,
            ClotheType = productModel.ClotheType,
            Reviews = productModel.Reviews?.Select(x => x.ToReviewDto()).ToList()
        };
    }

    public static Product ToCreateProduct(this CreateProductRequestDto productDto)
    {
        return new Product
        {
            Name = productDto.Name,
            Description = productDto.Description,
            ClotheType = productDto.ClotheType
        };
    }

    public static void ToUpdateProduct(Product product, UpdateProductDto productDto)
    {
        if (!string.IsNullOrEmpty(productDto.Description))
            product.Description = productDto.Description;

        if (!string.IsNullOrEmpty(productDto.Name))
            product.Name = productDto.Name;
    }
}