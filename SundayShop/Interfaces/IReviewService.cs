using SundayShop.DTOs.Review;
using SundayShop.Models.Entyties;

namespace SundayShop.Interfaces;

public interface IReviewService
{
    Task<List<Review>> GetAllAsync();
    Task<Review?> GetByIdAsync(int id);
    Task<Review> CreateAsync(Review review);
    Task<Review?> UpdateAsync(int productId, UpdateReviewDto reviewDto);
    Task<Review?> DeleteAsync(int id);
}