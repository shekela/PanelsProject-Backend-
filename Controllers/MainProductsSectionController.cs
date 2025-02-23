
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PanelsProject_Backend.Data;
using PanelsProject_Backend.Entities;
using PanelsProject_Backend.Interfaces;


namespace PanelsProject_Backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MainProductsSectionController : ControllerBase
    {
        private readonly DataContext _context;
        private readonly IFileService _fileService;

        public MainProductsSectionController(DataContext context, IFileService fileService)
        {
            _context = context;
            _fileService = fileService;
        }

        [Authorize(Roles = "Admin")]
        [HttpPost("createMainProductSectionText")]
        public async Task<IActionResult> CreateMainProductSection([FromBody] MainProductSectionDto mainProductSectionDto)
        {
            // Validate input
            if (mainProductSectionDto == null)
            {
                return BadRequest("MainProductSectionDto cannot be null.");
            }
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState); // Return validation errors in the response
            }

            try
            {
                // Debugging: Log incoming DTO
                Console.WriteLine($"Received DTO: {mainProductSectionDto.TitleEn}, {mainProductSectionDto.TitleTextEn}, {mainProductSectionDto.TitleKa}, {mainProductSectionDto.TitleTextKa}, {mainProductSectionDto.TitleRu}, {mainProductSectionDto.TitleTextRu}");

                // Check for any existing MainProductSection (doesn't matter which one) in the database
                var existingMainProductSection = await _context.MainProductSections.FirstOrDefaultAsync();

                // If an existing row is found, update it
                if (existingMainProductSection != null)
                {
                    Console.WriteLine("Found existing section, updating...");

                    // Update the values from the DTO
                    existingMainProductSection.TitleEn = mainProductSectionDto.TitleEn ?? existingMainProductSection.TitleEn;
                    existingMainProductSection.TitleTextEn = mainProductSectionDto.TitleTextEn ?? existingMainProductSection.TitleTextEn;
                    existingMainProductSection.TitleKa = mainProductSectionDto.TitleKa ?? existingMainProductSection.TitleKa;
                    existingMainProductSection.TitleTextKa = mainProductSectionDto.TitleTextKa ?? existingMainProductSection.TitleTextKa;
                    existingMainProductSection.TitleRu = mainProductSectionDto.TitleRu ?? existingMainProductSection.TitleRu;
                    existingMainProductSection.TitleTextRu = mainProductSectionDto.TitleTextRu ?? existingMainProductSection.TitleTextRu;

                    // Save changes to the existing entry
                    await _context.SaveChangesAsync();
                    return Ok(existingMainProductSection); // Return the updated section
                }
                else
                {
                    // If no existing section is found, create a new one
                    Console.WriteLine("No existing section, creating new...");
                    var newMainProductSection = new MainProductSection
                    {
                        TitleEn = mainProductSectionDto.TitleEn,
                        TitleTextEn = mainProductSectionDto.TitleTextEn,
                        TitleKa = mainProductSectionDto.TitleKa,
                        TitleTextKa = mainProductSectionDto.TitleTextKa,
                        TitleRu = mainProductSectionDto.TitleRu,
                        TitleTextRu = mainProductSectionDto.TitleTextRu
                    };

                    // Add the new section to the context
                    _context.MainProductSections.Add(newMainProductSection);

                    // Save the new section to the database
                    await _context.SaveChangesAsync();
                    return Ok(newMainProductSection); // Return the new section
                }
            }
            catch (Exception ex)
            {
                // Log the full exception to get more detailed information
                Console.WriteLine(ex.InnerException?.Message);
                Console.WriteLine(ex.StackTrace);
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }

        }

        [Authorize(Roles = "Admin")]
        [HttpPost("add-product")]
        public async Task<IActionResult> AddProduct([FromForm] Product product, IFormFile imageFile)
        {
            if (product == null)
            {
                return BadRequest("Product data is required.");
            }

            // Check the number of existing products
            int productCount = await _context.Products.CountAsync();
            if (productCount >= 4)
            {
                return BadRequest("Cannot add more than 4 products.");
            }

            // Handle the file upload
            if (imageFile != null)
            {
                var imageUrl = await _fileService.SaveFileAsync(imageFile); // Save the file and get its URL
                product.BackgroundUrl = imageUrl;
            }

            // Add the product to the database
            _context.Products.Add(product);
            await _context.SaveChangesAsync();

            return Ok(new { message = "Product added successfully.", id = product.Id });
        }


        [Authorize(Roles = "Admin")]
        [HttpPut("update-product/{id}")]
        public async Task<IActionResult> UpdateProduct(int id, [FromForm] Product updatedProduct, IFormFile imageFile)
        {
            if (updatedProduct == null)
            {
                return BadRequest("Updated product data is required.");
            }

            // Find the product by ID
            var existingProduct = await _context.Products.FindAsync(id);
            if (existingProduct == null)
            {
                return NotFound(new { message = "Product not found." });
            }

            // Update the product properties
            existingProduct.TitleEn = updatedProduct.TitleEn;
            existingProduct.DescriptionEn = updatedProduct.DescriptionEn;
            existingProduct.ButtonTextEn = updatedProduct.ButtonTextEn;
            existingProduct.TitleKa = updatedProduct.TitleKa;
            existingProduct.DescriptionKa = updatedProduct.DescriptionKa;
            existingProduct.ButtonTextKa = updatedProduct.ButtonTextKa;
            existingProduct.TitleRu = updatedProduct.TitleRu;
            existingProduct.DescriptionRu = updatedProduct.DescriptionRu;
            existingProduct.ButtonTextRu = updatedProduct.ButtonTextRu;

            // Handle the file upload
            if (imageFile != null && imageFile.Length > 0)
            {
                try
                {
                    // Check if the current product has a background image URL
                    if (!string.IsNullOrEmpty(existingProduct.BackgroundUrl))
                    {
                        // Extract the file name from the URL and construct the file path
                        string fileName = Path.GetFileName(existingProduct.BackgroundUrl);
                        string filePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "uploads", fileName);

                        // Check if the file exists in the uploads folder
                        if (System.IO.File.Exists(filePath))
                        {
                            Console.WriteLine($"File to be deleted: {filePath}");
                            _fileService.DeleteFile(fileName);  // Delete the old file
                        }
                        else
                        {
                            Console.WriteLine($"File not found: {filePath}");
                        }
                    }

                    // Save the new uploaded image and get the URL
                    var imageUrl = await _fileService.SaveFileAsync(imageFile);
                    existingProduct.BackgroundUrl = imageUrl;  // Update the BackgroundUrl with the new image URL
                }
                catch (Exception ex)
                {
                    return StatusCode(500, new { message = "An error occurred while deleting the old image or saving the new one.", details = ex.Message });
                }
            }

            // Save changes to the database
            _context.Products.Update(existingProduct);
            await _context.SaveChangesAsync();

            return Ok(new { message = "Product updated successfully." });
        }

        [Authorize(Roles = "Admin")]
        [HttpDelete("delete-product/{id}")]
        public async Task<IActionResult> DeleteProduct(int id)
        {
            // Find the product by ID
            var existingProduct = await _context.Products.FindAsync(id);
            if (existingProduct == null)
            {
                return NotFound(new { message = "Product not found." });
            }

            // Check if the BackgroundUrl exists and is not null or empty
            if (!string.IsNullOrEmpty(existingProduct.BackgroundUrl))
            {
                try
                {
                    string fileName = Path.GetFileName(existingProduct.BackgroundUrl);
                    string filePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "uploads", fileName);

                    // Check if the file exists before attempting to delete it
                    if (System.IO.File.Exists(filePath))
                    {
                        Console.WriteLine($"File to be deleted: {filePath}");
                        _fileService.DeleteFile(fileName);  // Call your custom DeleteFile method
                    }
                    else
                    {
                        Console.WriteLine($"File not found: {filePath}");
                    }
                }
                catch (Exception ex)
                {
                    return StatusCode(500, new { message = "An error occurred while deleting the picture.", details = ex.Message });
                }
            }

            // Remove the product from the database
            _context.Products.Remove(existingProduct);
            await _context.SaveChangesAsync();

            return Ok(new { message = "Product deleted successfully." });
        }

        [HttpGet("Combined")]
        public async Task<IActionResult> GetCombinedData()
        {
            var mainProductSections = await _context.MainProductSections.ToListAsync();
            var products = await _context.Products.ToListAsync();

            var result = new
            {
                MainProductSections = mainProductSections,
                Products = products
            };

            return Ok(result);
        }

        [HttpGet("get-Products")]
        public async Task<IActionResult> GeProductsData()
        {  
            var products = await _context.Products.ToListAsync();
            return Ok(products);
        }




    }
}
