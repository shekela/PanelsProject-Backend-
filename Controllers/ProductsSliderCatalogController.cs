using Microsoft.AspNetCore.Authorization;
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

        [Authorize(Roles = "Admin")]
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

        [Authorize(Roles = "Admin")]
        [HttpDelete("delete-product/{id}")]
        public async Task<IActionResult> DeleteProduct(int id)
        {
            // Find the product by ID
            var existingProduct = await _context.ProductsSliderCatalog.FindAsync(id);
            if (existingProduct == null)
            {
                return NotFound(new { message = "Product not found." });
            }

            if (!string.IsNullOrEmpty(existingProduct.BackgroundUrl))
            {
                string fileName = Path.GetFileName(existingProduct.BackgroundUrl);
                string filePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "uploads", fileName);
                Console.WriteLine($"File to be deleted: {filePath}");

                if (System.IO.File.Exists(filePath))
                {
                    _fileService.DeleteFile(fileName);
                }
                else
                {
                    Console.WriteLine($"File not found: {filePath}");
                }
            }

            _context.ProductsSliderCatalog.Remove(existingProduct);
            await _context.SaveChangesAsync();

            return Ok(new { message = "Product deleted successfully." });
        }

    }
}
