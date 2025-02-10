using Microsoft.EntityFrameworkCore;
using SundayShop.Data;
using SundayShop.DTOs.Product;
using SundayShop.Interfaces;
using SundayShop.Mappers;
using SundayShop.Models.Entyties;

namespace SundayShop.Repositories;

public class ProductService : IProductService
{
    private readonly ApplicationDbContext _dbContext;
    
    public ProductService(ApplicationDbContext dbContext)
    {
        _dbContext = dbContext;
    }
    
    public async Task<List<Product>> GetAllAsync()
    {
       var products = await _dbContext.Products
            .Include(c => c.Reviews)
            .ToListAsync();
    
        return products;
    }
    
    

    public async Task<Product?> GetByIdAsync(int id)
    {
        if (id == null)
            return null;

        var product = await _dbContext.Products
            .Include(r => r.Reviews)
            .FirstOrDefaultAsync(x => x.Id == id);

        return product;
    }

    public async Task<Product> CreateAsync(Product product)
    {
        if (product == null)
            return null;
        
        await _dbContext.Products.AddAsync(product);
        await _dbContext.SaveChangesAsync();

        return product;
    }

    public async Task<Product?> DeleteAsync(int id)
    {
        var product = await _dbContext.Products.FirstOrDefaultAsync(x => x.Id == id);

        if (product == null) return null;

        _dbContext.Products.Remove(product);
        await _dbContext.SaveChangesAsync();

        return product;
    }

    public async Task<Product?> UpdateAsync(int id, UpdateProductDto productDto)
    {
        var product = await _dbContext.Products.FirstOrDefaultAsync(x => x.Id == id);

        if (product == null) return null;
        
        ProductMapper.ToUpdateProduct(product, productDto);
        await _dbContext.SaveChangesAsync();

        return product;
    }

    public async Task<bool> ProductExistsAsync(int productId)
    {
        return await _dbContext.Products.AnyAsync(x => x.Id == productId);
    }
}