using Microsoft.AspNetCore.Mvc;
using SundayShop.DTOs.Review;
using SundayShop.Interfaces;
using SundayShop.Mappers;

namespace SundayShop.Controllers;

[Route("sundayshop/review")]
[ApiController]
public class ReviewController : ControllerBase
{
    private readonly IReviewService _reviewRepo;
    private readonly IProductService _productRepo;

    public ReviewController(IReviewService reviewRepo, IProductService productRepo)
    {
        _reviewRepo = reviewRepo;
        _productRepo = productRepo;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var reviews = await _reviewRepo.GetAllAsync();
        return Ok(reviews.Select(x => x.ToReviewDto()));
    }

    [HttpGet("{id:int}")]
    public async Task<IActionResult> GetById(int id)
    {
        var reviewModel = await _reviewRepo.GetByIdAsync(id);

        return reviewModel != null ? Ok(reviewModel.ToReviewDto()) : NotFound();
    }

    [HttpPost("{productId:int}")]
    public async Task<IActionResult> Create([FromRoute] int productId, CreateReviewDto reviewDto)
    {
        if (!await _productRepo.ProductExistsAsync(productId))
            return NotFound();

        var reviewModel = reviewDto.ToCreateDto(productId);

        await _reviewRepo.CreateAsync(reviewModel);

        return CreatedAtAction(nameof(GetById), new { id = reviewModel.Id }, reviewModel.ToReviewDto());
    }

    [HttpPatch("{reviewId:int}")]
    public async Task<IActionResult> Update([FromRoute] int reviewId, UpdateReviewDto reviewDto)
    {
        var reviewModel = await _reviewRepo.UpdateAsync(reviewId, reviewDto);

        return reviewModel != null ? Ok(reviewModel.ToReviewDto()) : BadRequest();
    }

    [HttpDelete("{id:int}")]
    public async Task<IActionResult> Delete([FromRoute] int id)
    {
        var review = await _reviewRepo.DeleteAsync(id);

        return review != null ? Ok() : NotFound();
    }
}