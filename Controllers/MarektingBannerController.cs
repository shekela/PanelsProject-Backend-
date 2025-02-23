using Microsoft.AspNetCore.Authorization;
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
    public class MarektingBannerController : ControllerBase
    {
        private readonly DataContext _context;
        private readonly IFileService _fileService;


        public MarektingBannerController(DataContext context, IFileService fileService)
        {
            _context = context;
            _fileService = fileService;
        }

        [HttpGet("get-marketingBanner")]
        public async Task<IActionResult> GetProducts()
        {
            var products = await _context.MarketingBanners.ToListAsync();
            return Ok(products);
        }

        [Authorize(Roles = "Admin")]
        [HttpPost("CreateMarketingBanner")]
        public async Task<IActionResult> CreateMarketingBanner(
         [FromForm] MarketingBannerDto marketingBanner,
         IFormFile imageFile)  // No need for [FromForm] here
        {
            // Validate the input
            if (marketingBanner == null)
            {
                return BadRequest("MarketingBanner cannot be null.");
            }

            try
            {
                string imagePath = null;

                // Handle file upload if there is an image file
                if (imageFile != null && imageFile.Length > 0)
                {
                    // Use the IFileService to save the file
                    imagePath = await _fileService.SaveFileAsync(imageFile);
                }

                // Check if a MarketingBanner exists in the database
                var existingMarketingBanner = await _context.MarketingBanners.FirstOrDefaultAsync();

                if (existingMarketingBanner != null)
                {
                    // Update the existing MarketingBanner
                    existingMarketingBanner.TitleEn = marketingBanner.TitleEn ?? existingMarketingBanner.TitleEn;
                    existingMarketingBanner.DescriptionEn = marketingBanner.DescriptionEn ?? existingMarketingBanner.DescriptionEn;
                    existingMarketingBanner.AimEn = marketingBanner.AimEn ?? existingMarketingBanner.AimEn;

                    existingMarketingBanner.TitleKa = marketingBanner.TitleKa ?? existingMarketingBanner.TitleKa;
                    existingMarketingBanner.DescriptionKa = marketingBanner.DescriptionKa ?? existingMarketingBanner.DescriptionKa;
                    existingMarketingBanner.AimKa = marketingBanner.AimKa ?? existingMarketingBanner.AimKa;

                    existingMarketingBanner.TitleRu = marketingBanner.TitleRu ?? existingMarketingBanner.TitleRu;
                    existingMarketingBanner.DescriptionRu = marketingBanner.DescriptionRu ?? existingMarketingBanner.DescriptionRu;
                    existingMarketingBanner.AimRu = marketingBanner.AimRu ?? existingMarketingBanner.AimRu;

                    // If an image was uploaded, update the image URL
                    if (!string.IsNullOrEmpty(imagePath))
                    {
                        try
                        {
                            if (!string.IsNullOrEmpty(existingMarketingBanner.ImgUrl))
                            {
                                string fileName = Path.GetFileName(existingMarketingBanner.ImgUrl);
                                string filePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "uploads", fileName);

                                // Check if file exists before attempting to delete it
                                if (System.IO.File.Exists(filePath))
                                {
                                    Console.WriteLine($"File to be deleted: {filePath}");
                                    _fileService.DeleteFile(fileName);  // Delete the old image
                                }
                                else
                                {
                                    Console.WriteLine($"File not found: {filePath}");
                                }
                            }

                            // Update the ImgUrl with the new image
                            existingMarketingBanner.ImgUrl = imagePath;
                        }
                        catch (Exception ex)
                        {
                            return StatusCode(500, new { message = "An error occurred while deleting the picture.", details = ex.Message });
                        }
                    }

                    await _context.SaveChangesAsync();
                    return Ok(existingMarketingBanner);
                }
                else
                {
                    // If no existing MarketingBanner is found, create a new one
                    var newMarketingBanner = new MarketingBanner
                    {
                        TitleEn = marketingBanner.TitleEn,
                        DescriptionEn = marketingBanner.DescriptionEn,
                        AimEn = marketingBanner.AimEn,
                        TitleKa = marketingBanner.TitleKa,
                        DescriptionKa = marketingBanner.DescriptionKa,
                        AimKa = marketingBanner.AimKa,
                        TitleRu = marketingBanner.TitleRu,
                        DescriptionRu = marketingBanner.DescriptionRu,
                        AimRu = marketingBanner.AimRu,
                        ImgUrl = imagePath // Include image URL if an image was uploaded
                    };

                    _context.MarketingBanners.Add(newMarketingBanner);
                    await _context.SaveChangesAsync();
                    return Ok(newMarketingBanner);
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }
    }
}

