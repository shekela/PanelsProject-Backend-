using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PanelsProject_Backend.Data;
using PanelsProject_Backend.DTO_s;
using PanelsProject_Backend.Entities;

namespace PanelsProject_Backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VideoCatalogController : ControllerBase
    {
        private readonly DataContext _context;

        public VideoCatalogController(DataContext context)
        {
            _context = context;
        }

        [HttpPost("CreateVideoCatalog")]
        public async Task<IActionResult> CreateMainProductSection([FromBody] VideoCatalogDto videoCatalog)
        {
            // Validate input
            if (videoCatalog == null)
            {
                return BadRequest("MarketingBanner cannot be null.");
            }

            try
            {
                var existingVideoCatalog = await _context.VideoCatalog.FirstOrDefaultAsync();

                // If an existing row is found, update it
                if (existingVideoCatalog != null)
                {
                    existingVideoCatalog.TitleEn = videoCatalog.TitleEn ?? videoCatalog.TitleEn;
                    existingVideoCatalog.DescriptionEn = videoCatalog.DescriptionEn ?? videoCatalog.DescriptionEn;
                    existingVideoCatalog.ButtonTextEn = videoCatalog.ButtonTextEn ?? videoCatalog.ButtonTextEn;
                    existingVideoCatalog.TitleKa = videoCatalog.TitleKa ?? videoCatalog.TitleKa;
                    existingVideoCatalog.DescriptionKa = videoCatalog.DescriptionKa ?? videoCatalog.DescriptionKa;
                    existingVideoCatalog.ButtonTextKa = videoCatalog.ButtonTextKa ?? videoCatalog.ButtonTextKa;
                    existingVideoCatalog.TitleRu = videoCatalog.TitleRu ?? videoCatalog.TitleRu;
                    existingVideoCatalog.DescriptionRu = videoCatalog.DescriptionRu ?? videoCatalog.DescriptionRu;
                    existingVideoCatalog.ButtonTextRu = videoCatalog.ButtonTextRu ?? videoCatalog.ButtonTextRu;
                    existingVideoCatalog.BackgroundUrl = videoCatalog.BackgroundUrl ?? videoCatalog.BackgroundUrl;

                    await _context.SaveChangesAsync();
                    return Ok(existingVideoCatalog);
                }
                else
                {
                    Console.WriteLine("No existing section, creating new...");
                    var newVideoCatalog = new VideoCatalog
                    {
                        TitleEn = videoCatalog.TitleEn,
                        DescriptionEn = videoCatalog.DescriptionEn,
                        ButtonTextEn = videoCatalog.ButtonTextEn,
                        TitleKa = videoCatalog.TitleKa,
                        DescriptionKa = videoCatalog.DescriptionKa,
                        ButtonTextKa = videoCatalog.ButtonTextKa,
                        TitleRu =   videoCatalog.TitleRu,
                        DescriptionRu = videoCatalog.DescriptionRu,
                        ButtonTextRu = videoCatalog.ButtonTextRu,
                        BackgroundUrl = videoCatalog.BackgroundUrl,
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
