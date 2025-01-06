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
    public class VideoCatalogController : ControllerBase
    {
        private readonly DataContext _context;
        private readonly IFileService _fileService;

        public VideoCatalogController(DataContext context, IFileService fileService)
        {
            _context = context;
            _fileService = fileService;
        }


        [HttpPost("CreateVideoCatalog")]
        public async Task<IActionResult> CreateVideoCatalog(
    [FromForm] VideoCatalogDto videoCatalog,   // Accept the DTO from the form data
    IFormFile backgroundFile)      // Accept the background image file
        {
            // Validate input
            if (videoCatalog == null)
            {
                return BadRequest("VideoCatalog cannot be null.");
            }

            try
            {
                string backgroundPath = null;

                // Handle file upload for background image if provided
                if (backgroundFile != null && backgroundFile.Length > 0)
                {
                    // Use the IFileService to save the file
                    backgroundPath = await _fileService.SaveFileAsync(backgroundFile);
                }

                // Check if an existing VideoCatalog is found in the database
                var existingVideoCatalog = await _context.VideoCatalog.FirstOrDefaultAsync();

                if (existingVideoCatalog != null)
                {
                    // Update only the fields that are provided (not null)
                    existingVideoCatalog.TitleEn = videoCatalog.TitleEn ?? existingVideoCatalog.TitleEn;
                    existingVideoCatalog.DescriptionEn = videoCatalog.DescriptionEn ?? existingVideoCatalog.DescriptionEn;
                    existingVideoCatalog.ButtonTextEn = videoCatalog.ButtonTextEn ?? existingVideoCatalog.ButtonTextEn;

                    existingVideoCatalog.TitleKa = videoCatalog.TitleKa ?? existingVideoCatalog.TitleKa;
                    existingVideoCatalog.DescriptionKa = videoCatalog.DescriptionKa ?? existingVideoCatalog.DescriptionKa;
                    existingVideoCatalog.ButtonTextKa = videoCatalog.ButtonTextKa ?? existingVideoCatalog.ButtonTextKa;

                    existingVideoCatalog.TitleRu = videoCatalog.TitleRu ?? existingVideoCatalog.TitleRu;
                    existingVideoCatalog.DescriptionRu = videoCatalog.DescriptionRu ?? existingVideoCatalog.DescriptionRu;
                    existingVideoCatalog.ButtonTextRu = videoCatalog.ButtonTextRu ?? existingVideoCatalog.ButtonTextRu;

                    // If a background image file was uploaded, update the background URL
                    if (!string.IsNullOrEmpty(backgroundPath))
                    {
                        existingVideoCatalog.BackgroundUrl = backgroundPath;
                    }

                    await _context.SaveChangesAsync();
                    return Ok(existingVideoCatalog);
                }
                else
                {
                    // If no existing VideoCatalog, create a new one
                    var newVideoCatalog = new VideoCatalog
                    {
                        TitleEn = videoCatalog.TitleEn ?? "",
                        DescriptionEn = videoCatalog.DescriptionEn ?? "",
                        ButtonTextEn = videoCatalog.ButtonTextEn ?? "",
                        TitleKa = videoCatalog.TitleKa ?? "",
                        DescriptionKa = videoCatalog.DescriptionKa ?? "",
                        ButtonTextKa = videoCatalog.ButtonTextKa ?? "",
                        TitleRu = videoCatalog.TitleRu ?? "",
                        DescriptionRu = videoCatalog.DescriptionRu ?? "",
                        ButtonTextRu = videoCatalog.ButtonTextRu ?? "",
                        BackgroundUrl = backgroundPath ?? "" // Include the image URL if uploaded
                    };

                    _context.VideoCatalog.Add(newVideoCatalog);
                    await _context.SaveChangesAsync();
                    return Ok(newVideoCatalog);
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }




        [HttpGet("get-videoCatalog")]
        public async Task<IActionResult> GetProducts()
        {
            var catalog = await _context.VideoCatalog.ToListAsync();
            return Ok(catalog);
        }
    }
}
