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
    public class ColorAndCoversController : ControllerBase
    {
        private readonly DataContext _context;
        private readonly IFileService _fileService;
        public ColorAndCoversController(DataContext context, IFileService fileService)
        {
            _context = context;
            _fileService = fileService;
        }

        [Authorize(Roles = "Admin")]
        [HttpPost("add-product")]
        public async Task<IActionResult> AddProduct([FromForm] ColorAndCovers product, IFormFile backgroundImage)
        {
            if (product == null)
            {
                return BadRequest("Product data is required.");
            }

            // Check the number of existing products
            int productCount = await _context.ColorAndCovers.CountAsync();
            if (productCount >= 2)
            {
                return BadRequest("Cannot add more than 2 products.");
            }

            // Handle image upload if provided
            if (backgroundImage != null)
            {
                string filePath = await _fileService.SaveFileAsync(backgroundImage);
                product.BackgroundUrl = filePath;
            }

            // Add the product to the database
            _context.ColorAndCovers.Add(product);
            await _context.SaveChangesAsync();

            return Ok(new { message = "Product added successfully." });
        }

        [Authorize(Roles = "Admin")]
        [HttpPut("update-product/{id}")]
        public async Task<IActionResult> UpdateProduct(int id, [FromForm] ColorAndCovers updatedProduct, IFormFile backgroundImage)
        {
            // Find the product by ID
            var existingProduct = await _context.ColorAndCovers.FindAsync(id);
            if (existingProduct == null)
            {
                return NotFound(new { message = "Product not found." });
            }

            if (backgroundImage != null)
            {
                // Construct file path for the old image to be deleted
                string fileName = Path.GetFileName(existingProduct.BackgroundUrl);
                string oldFilePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "uploads", fileName);
                Console.WriteLine($"File to be deleted: {oldFilePath}");

                // Check if the old file exists and delete it
                if (System.IO.File.Exists(oldFilePath))
                {
                    _fileService.DeleteFile(fileName);
                }
                else
                {
                    Console.WriteLine($"File not found: {oldFilePath}");
                }

                // Save the new uploaded file and update the product's BackgroundUrl
                string newFilePath = await _fileService.SaveFileAsync(backgroundImage);
                existingProduct.BackgroundUrl = newFilePath;
            }


            // Update properties if provided in the request
            if (!string.IsNullOrWhiteSpace(updatedProduct.TitleEn))
            {
                existingProduct.TitleEn = updatedProduct.TitleEn;
            }

            if (!string.IsNullOrWhiteSpace(updatedProduct.DescriptionEn))
            {
                existingProduct.DescriptionEn = updatedProduct.DescriptionEn;
            }

            if (!string.IsNullOrWhiteSpace(updatedProduct.ButtonTextEn))
            {
                existingProduct.ButtonTextEn = updatedProduct.ButtonTextEn;
            }

            if (!string.IsNullOrWhiteSpace(updatedProduct.TitleKa))
            {
                existingProduct.TitleKa = updatedProduct.TitleKa;
            }

            if (!string.IsNullOrWhiteSpace(updatedProduct.DescriptionKa))
            {
                existingProduct.DescriptionKa = updatedProduct.DescriptionKa;
            }

            if (!string.IsNullOrWhiteSpace(updatedProduct.ButtonTextKa))
            {
                existingProduct.ButtonTextKa = updatedProduct.ButtonTextKa;
            }

            if (!string.IsNullOrWhiteSpace(updatedProduct.TitleRu))
            {
                existingProduct.TitleRu = updatedProduct.TitleRu;
            }

            if (!string.IsNullOrWhiteSpace(updatedProduct.DescriptionRu))
            {
                existingProduct.DescriptionRu = updatedProduct.DescriptionRu;
            }

            if (!string.IsNullOrWhiteSpace(updatedProduct.ButtonTextRu))
            {
                existingProduct.ButtonTextRu = updatedProduct.ButtonTextRu;
            }

            // Save changes to the database
            _context.ColorAndCovers.Update(existingProduct);
            await _context.SaveChangesAsync();

            return Ok(new { message = "Product updated successfully." });
        }



        [HttpGet("get-ColorAndCovers")]
        public async Task<IActionResult> GetData()
        {
            var products = await _context.ColorAndCovers.ToListAsync();
            return Ok(products);
        }

        [Authorize(Roles = "Admin")]
        [HttpDelete("delete-color-and-covers/{id}")]
        public async Task<IActionResult> DeleteColorAndCovers(int id)
        {
            // Find the product by ID
            var existingProduct = await _context.ColorAndCovers.FindAsync(id);
            if (existingProduct == null)
            {
                return NotFound(new { message = "Product not found." });
            }

            // Check if the product has an associated picture
            if (!string.IsNullOrEmpty(existingProduct.BackgroundUrl))
            {
                try
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
                catch (Exception ex)
                {
                    // Handle error if file deletion fails
                    return StatusCode(500, new { message = "An error occurred while deleting the picture.", details = ex.Message });
                }
            }

            // Remove the product from the database
            _context.ColorAndCovers.Remove(existingProduct);
            await _context.SaveChangesAsync();

            return Ok(new { message = "Product and associated picture deleted successfully." });
        }



    }
}
