using Microsoft.EntityFrameworkCore;
using SundayShop.Data;
using SundayShop.DTOs.Review;
using SundayShop.Interfaces;
using SundayShop.Mappers;
using SundayShop.Models.Entyties;

namespace SundayShop.Repositories;

public class ReviewService : IReviewService
{
    private readonly ApplicationDbContext _dbContext;

    public ReviewService(ApplicationDbContext dbContext)
    {
        _dbContext = dbContext;
    }
    
    public async Task<List<Review>> GetAllAsync()
    {
        return await _dbContext.Reviews.ToListAsync();
    }

    public async Task<Review?> GetByIdAsync(int id)
    {
        return await _dbContext.Reviews.FirstOrDefaultAsync(x => x.Id == id);
    }

    public async Task<Review> CreateAsync(Review review)
    {
        await _dbContext.Reviews.AddAsync(review);
        await _dbContext.SaveChangesAsync();

        return review;
    }

    public async Task<Review?> UpdateAsync(int reviewId, UpdateReviewDto reviewDto)
    {
        var review = await _dbContext.Reviews.FirstOrDefaultAsync(x => x.Id == reviewId);

        if (review == null) return null;
        
        ReviewMapper.ToUpdateReviewDto(review, reviewDto);
        await _dbContext.SaveChangesAsync();

        return review;
    }

    public async Task<Review?> DeleteAsync(int id)
    {
        var review = await _dbContext.Reviews.FirstOrDefaultAsync(x => x.Id == id);

        if (review == null) return null;
        
        _dbContext.Reviews.Remove(review);
        await _dbContext.SaveChangesAsync();

        return review;
    }
}