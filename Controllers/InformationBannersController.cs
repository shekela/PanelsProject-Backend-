using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PanelsProject_Backend.Data;
using PanelsProject_Backend.Entities;

namespace PanelsProject_Backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InformationBannersController : ControllerBase
    {
        private readonly DataContext _context;
        public InformationBannersController(DataContext context)
        {
            _context = context;
        }


        [HttpPost("add-banner")]
        public async Task<IActionResult> AddBanner([FromBody] InformationBanner banner)
        {
            if (banner == null)
            {
                return BadRequest("Product data is required.");
            }

            // Add the product to the database
            _context.InformationBanners.Add(banner);
            await _context.SaveChangesAsync();

            return Ok(new { message = "Product added successfully." });
        }

        [HttpPut("update-banner/{id}")]
        public async Task<IActionResult> UpdateBanner(int id, [FromBody] InformationBanner updatedBanner)
        {
            if (updatedBanner == null)
            {
                return BadRequest("Updated banner data is required.");
            }

            // Find the banner by ID
            var existingBanner = await _context.InformationBanners.FindAsync(id);
            if (existingBanner == null)
            {
                return NotFound(new { message = "Banner not found." });
            }

            // Update the banner properties
            existingBanner.TitleEn = updatedBanner.TitleEn;
            existingBanner.DescriptionEn = updatedBanner.DescriptionEn;
            existingBanner.ButtonTextEn = updatedBanner.ButtonTextEn;
            existingBanner.TitleKa = updatedBanner.TitleKa;
            existingBanner.DescriptionKa = updatedBanner.DescriptionKa;
            existingBanner.ButtonTextKa = updatedBanner.ButtonTextKa;
            existingBanner.TitleRu = updatedBanner.TitleRu;
            existingBanner.DescriptionRu = updatedBanner.DescriptionRu;
            existingBanner.ButtonTextRu = updatedBanner.ButtonTextRu;
            existingBanner.BackgroundUrl = updatedBanner.BackgroundUrl;

            // Save changes to the database
            _context.InformationBanners.Update(existingBanner);
            await _context.SaveChangesAsync();

            return Ok(new { message = "Banner updated successfully." });
        }

        [HttpDelete("delete-banner/{id}")]
        public async Task<IActionResult> DeleteBanner(int id)
        {
            // Find the banner by ID
            var existingBanner = await _context.InformationBanners.FindAsync(id);
            if (existingBanner == null)
            {
                return NotFound(new { message = "Banner not found." });
            }

            // Remove the banner from the database
            _context.InformationBanners.Remove(existingBanner);
            await _context.SaveChangesAsync();

            return Ok(new { message = "Banner deleted successfully." });
        }



        [HttpGet("get-banners")]
        public async Task<IActionResult> GetBanners()
        {
            var banners = await _context.InformationBanners.ToListAsync();
            return Ok(banners);
        }



    }
}
