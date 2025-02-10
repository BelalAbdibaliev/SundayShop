using Microsoft.AspNetCore.Mvc;
using SundayShop.DTOs.Review;
using SundayShop.Interfaces;
using SundayShop.Mappers;

namespace SundayShop.Controllers;

[Route("review")]
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

    [HttpGet("getall")]
    public async Task<IActionResult> GetAll()
    {
        var reviews = await _reviewRepo.GetAllAsync();
        return Ok(reviews.Select(x => x.ToReviewDto()));
    }

    [HttpGet("getbyid")]
    public async Task<IActionResult> GetById([FromQuery]int id)
    {
        var reviewModel = await _reviewRepo.GetByIdAsync(id);

        return reviewModel != null ? Ok(reviewModel.ToReviewDto()) : NotFound();
    }

    [HttpPost("create")]
    public async Task<IActionResult> Create([FromQuery] int productId, CreateReviewDto reviewDto)
    {
        if (!await _productRepo.ProductExistsAsync(productId))
            return NotFound();

        var reviewModel = reviewDto.ToCreateDto(productId);

        await _reviewRepo.CreateAsync(reviewModel);

        return CreatedAtAction(nameof(GetById), new { id = reviewModel.Id }, reviewModel.ToReviewDto());
    }

    [HttpPatch("update")]
    public async Task<IActionResult> Update([FromQuery] int reviewId, UpdateReviewDto reviewDto)
    {
        var reviewModel = await _reviewRepo.UpdateAsync(reviewId, reviewDto);

        return reviewModel != null ? Ok(reviewModel.ToReviewDto()) : BadRequest();
    }

    [HttpDelete("delete")]
    public async Task<IActionResult> Delete([FromQuery] int id)
    {
        var review = await _reviewRepo.DeleteAsync(id);

        return review != null ? Ok() : NotFound();
    }
}