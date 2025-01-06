using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PanelsProject_Backend.Data;
using PanelsProject_Backend.DTO_s;
using PanelsProject_Backend.Entities;
using PanelsProject_Backend.Interfaces;

namespace PanelsProject_Backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GalleryController : ControllerBase
    {
        private readonly DataContext _context;
        private readonly IFileService _fileService;
        public GalleryController(DataContext context, IFileService fileService)
        {
            _context = context;
            _fileService = fileService;
        }


        [HttpPost("add-picture")]
        public async Task<IActionResult> AddProduct([FromForm] GalleryPictures picture, IFormFile backgroundImage)
        {
            if (picture == null)
            {
                return BadRequest("Product data is required.");
            }
            if (backgroundImage != null)
            {
                string filePath = await _fileService.SaveFileAsync(backgroundImage);
                picture.Picture = filePath;
            }
            _context.GalleryPictures.Add(picture);
            await _context.SaveChangesAsync();

            return Ok(new { message = "Product added successfully." });
        }


        [HttpDelete("delete-picture/{id}")]
        public async Task<IActionResult> DeletePicture(int id)
        {
            // Find the picture by ID
            var existingPicture = await _context.GalleryPictures.FindAsync(id);
            if (existingPicture == null)
            {
                return NotFound(new { message = "Picture not found." });
            }

            // Remove the picture from the database
            _context.GalleryPictures.Remove(existingPicture);
            await _context.SaveChangesAsync();

            return Ok(new { message = "Picture deleted successfully." });
        }


        [HttpPost("createGalleryTexts")]
        public async Task<IActionResult> CreateGalleryTexts([FromBody] GallerySectionTexts galleryTextsDto)
        {
            // Validate input
            if (galleryTextsDto == null)
            {
                return BadRequest("GallerySectionTexts DTO cannot be null.");
            }

            try
            {
                // Debugging: Log incoming DTO
                Console.WriteLine($"Received DTO: {galleryTextsDto.TitleEn}, {galleryTextsDto.TitleTextEn}, {galleryTextsDto.TitleKa}, {galleryTextsDto.TitleTextKa}, {galleryTextsDto.TitleRu}, {galleryTextsDto.TitleTextRu}");

                // Check for any existing GallerySectionTexts (doesn't matter which one) in the database
                var existingGalleryTexts = await _context.GallerySectionTexts.FirstOrDefaultAsync();

                // If an existing row is found, update it
                if (existingGalleryTexts != null)
                {
                    Console.WriteLine("Found existing gallery texts, updating...");

                    // Update the values from the DTO
                    existingGalleryTexts.TitleEn = galleryTextsDto.TitleEn ?? existingGalleryTexts.TitleEn;
                    existingGalleryTexts.TitleTextEn = galleryTextsDto.TitleTextEn ?? existingGalleryTexts.TitleTextEn;
                    existingGalleryTexts.TitleKa = galleryTextsDto.TitleKa ?? existingGalleryTexts.TitleKa;
                    existingGalleryTexts.TitleTextKa = galleryTextsDto.TitleTextKa ?? existingGalleryTexts.TitleTextKa;
                    existingGalleryTexts.TitleRu = galleryTextsDto.TitleRu ?? existingGalleryTexts.TitleRu;
                    existingGalleryTexts.TitleTextRu = galleryTextsDto.TitleTextRu ?? existingGalleryTexts.TitleTextRu;

                    // Save changes to the existing entry
                    await _context.SaveChangesAsync();
                    return Ok(existingGalleryTexts); // Return the updated texts
                }
                else
                {
                    // If no existing gallery texts are found, create new ones
                    Console.WriteLine("No existing gallery texts, creating new...");
                    var newGalleryTexts = new GallerySectionTexts
                    {
                        TitleEn = galleryTextsDto.TitleEn,
                        TitleTextEn = galleryTextsDto.TitleTextEn,
                        TitleKa = galleryTextsDto.TitleKa,
                        TitleTextKa = galleryTextsDto.TitleTextKa,
                        TitleRu = galleryTextsDto.TitleRu,
                        TitleTextRu = galleryTextsDto.TitleTextRu
                    };

                    // Add the new texts to the context
                    _context.GallerySectionTexts.Add(newGalleryTexts);

                    // Save the new texts to the database
                    await _context.SaveChangesAsync();
                    return Ok(newGalleryTexts); // Return the new texts
                }
            }
            catch (Exception ex)
            {
                // Handle unexpected errors
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }


        [HttpGet("get-gallery")]
        public async Task<IActionResult> GetPictures()
        {
            var gallery = await _context.GalleryPictures.ToListAsync();
            return Ok(gallery);
        }


        [HttpGet("get-galleryTexts")]
        public async Task<IActionResult> GetGalleryTexts()
        {
            var galleryTexts = await _context.GallerySectionTexts.ToListAsync();
            return Ok(galleryTexts);
        }
    }
}
