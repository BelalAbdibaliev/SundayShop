using SundayShop.DTOs.Review;
using SundayShop.Models.Entyties;

namespace SundayShop.Mappers;

public static class ReviewMapper
{
    public static ReviewDto ToReviewDto(this Review reviewModel)
    {
        return new ReviewDto
        {
            Comment = reviewModel.Comment,
            CreatedIn = reviewModel.CreatedIn,
            Rate = reviewModel.Rate,
            Id = reviewModel.Id,
            ProductId = reviewModel.ProductId
        };
    }

    public static Review ToCreateDto(this CreateReviewDto createDto, int productId)
    {
        return new Review
        {
            Comment = createDto.Comment,
            Rate = createDto.Rate,
            CreatedIn = DateTime.Now,
            ProductId = productId
        };
    }

    public static void ToUpdateReviewDto(Review reviewModel, UpdateReviewDto reviewDto)
    {
        if (!string.IsNullOrEmpty(reviewDto.Comment))
            reviewModel.Comment = reviewDto.Comment;
        if (reviewDto.Rate != reviewModel.Rate)
            reviewModel.Rate = reviewDto.Rate;
    }
}