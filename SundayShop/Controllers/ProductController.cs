using System.Diagnostics.Contracts;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SundayShop.Data;
using SundayShop.DTOs.Product;
using SundayShop.Interfaces;
using SundayShop.Mappers;

namespace SundayShop.Controllers;

[Route("sundayshop/product")]
[ApiController]
public class ProductController : ControllerBase
{
    private readonly IProductService _productRepo;
    
    public ProductController(IProductService productRepo)
    {
        _productRepo = productRepo;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
         var products = await _productRepo.GetAllAsync();

         return Ok(products.Select(x => x.ToProductDto()));
    }

    [HttpGet("{id:int}")]
    public async Task<IActionResult> GetById([FromRoute] int id)
    {
        var productModel = await _productRepo.GetByIdAsync(id);

        return productModel != null ? Ok(productModel.ToProductDto()) : BadRequest();
    }

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] CreateProductRequestDto productDto)
    {
        if (!ModelState.IsValid) return BadRequest(ModelState);
        
        if (productDto == null) return BadRequest();
        
        var productModel = productDto.ToCreateProduct();
        await _productRepo.CreateAsync(productModel);

        return CreatedAtAction(nameof(GetById), new { id = productModel.Id }, productModel.ToProductDto());
    }

    [HttpDelete]
    [Route("{id:int}")]
    public async Task<IActionResult> Delete([FromRoute] int id)
    {
        var productModel = await _productRepo.DeleteAsync(id);

        return productModel != null ? NoContent() : BadRequest();

    }

    [HttpPatch]
    [Route("{id:int}")]
    public async Task<IActionResult> Update([FromRoute] int id, [FromBody] UpdateProductDto productDto)
    {
        var productModel = await _productRepo.UpdateAsync(id, productDto);

        return productModel != null ? Ok(productModel.ToProductDto()) : NotFound();
    }
}