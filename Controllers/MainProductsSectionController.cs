
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PanelsProject_Backend.Data;
using PanelsProject_Backend.Entities;


namespace PanelsProject_Backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MainProductsSectionController : ControllerBase
    {
        private readonly DataContext _context;

        public MainProductsSectionController(DataContext context)
        {
            _context = context;
        }

        [HttpPost("createMainProductSectionText")]
        public async Task<IActionResult> CreateMainProductSection([FromBody] MainProductSectionDto mainProductSectionDto)
        {
            // Validate input
            if (mainProductSectionDto == null)
            {
                return BadRequest("MainProductSectionDto cannot be null.");
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
                // Handle unexpected errors
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }

        }

        [HttpPost("add-product")]
        public async Task<IActionResult> AddProduct([FromBody] Product product)
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

            // Add the product to the database
            _context.Products.Add(product);
            await _context.SaveChangesAsync();

            return Ok(new { message = "Product added successfully." });
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




    }
}
