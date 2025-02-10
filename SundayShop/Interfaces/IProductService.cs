using SundayShop.DTOs.Product;
using SundayShop.DTOs.Review;
using SundayShop.Models.Entyties;

namespace SundayShop.Interfaces;

public interface IProductService
{
    Task<List<Product>> GetAllAsync();
    Task<Product?> GetByIdAsync(int id);
    Task<Product> CreateAsync(Product product);
    Task<Product?> DeleteAsync(int id);
    Task<Product?> UpdateAsync(int id, UpdateProductDto productDto);
    Task<bool> ProductExistsAsync(int id);
}