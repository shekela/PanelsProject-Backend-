using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PanelsProject_Backend.Data;
using PanelsProject_Backend.Entities;
using PanelsProject_Backend.Interfaces;

namespace PanelsProject_Backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsSliderCatalogController : ControllerBase
    {
        private readonly DataContext _context;
        private readonly IFileService _fileService;  // Inject the file service

        public ProductsSliderCatalogController(DataContext context, IFileService fileService)
        {
            _context = context;
            _fileService = fileService;
        }

        [HttpPost("add-product")]
        public async Task<IActionResult> AddProduct([FromForm] ProductsSliderCatalog product, IFormFile imageFile)
        {
            if (product == null)
            {
                return BadRequest("Product data is required.");
            }

            string imagePath = null;

            if (imageFile != null && imageFile.Length > 0)
            {
                // Use the _fileService to save the image and get the relative path
                imagePath = await _fileService.SaveFileAsync(imageFile);
            }

            // Set the image URL
            product.BackgroundUrl = imagePath;

            // Add the product to the database
            _context.ProductsSliderCatalog.Add(product);
            await _context.SaveChangesAsync();

            return Ok(new { message = "Product added successfully." });
        }


        [HttpGet("get-ProductsCatalogSlider")] 
        public async Task<IActionResult> GetProducts()
        {
            var products = await _context.ProductsSliderCatalog.ToListAsync();
            return Ok(products);
        }


        [HttpDelete("delete-product/{id}")]
        public async Task<IActionResult> DeleteProduct(int id)
        {
            // Find the product by ID
            var existingProduct = await _context.ProductsSliderCatalog.FindAsync(id);
            if (existingProduct == null)
            {
                return NotFound(new { message = "Product not found." });
            }

            // Remove the product from the database
            _context.ProductsSliderCatalog.Remove(existingProduct);
            await _context.SaveChangesAsync();

            return Ok(new { message = "Product deleted successfully." });
        }

    }
}
