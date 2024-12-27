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
    public class MarektingBannerController : ControllerBase
    {
        private readonly DataContext _context;

        public MarektingBannerController(DataContext context)
        {
            _context = context;
        }

        [HttpPost("CreateMarketingBanner")]
        public async Task<IActionResult> CreateMainProductSection([FromBody] MarketingBannerDto marketingBanner)
        {
            // Validate input
            if (marketingBanner == null)
            {
                return BadRequest("MarketingBanner cannot be null.");
            }

            try
            {
                var existingMarketingBanner = await _context.MarketingBanners.FirstOrDefaultAsync();

                // If an existing row is found, update it
                if (existingMarketingBanner != null)
                {
                    existingMarketingBanner.TitleEn = marketingBanner.TitleEn ?? marketingBanner.TitleEn;
                    existingMarketingBanner.DescriptionEn = marketingBanner.DescriptionEn ?? marketingBanner.DescriptionEn;
                    existingMarketingBanner.AimEn = marketingBanner.AimEn ?? marketingBanner.AimEn;
                    existingMarketingBanner.TitleKa = marketingBanner.TitleKa ?? marketingBanner.TitleKa;
                    existingMarketingBanner.DescriptionKa = marketingBanner.DescriptionKa ?? marketingBanner.DescriptionKa;
                    existingMarketingBanner.AimKa = marketingBanner.AimKa ?? marketingBanner.AimKa;
                    existingMarketingBanner.TitleRu = marketingBanner.TitleRu ?? marketingBanner.TitleRu;
                    existingMarketingBanner.DescriptionRu = marketingBanner.DescriptionRu ?? marketingBanner.DescriptionRu;
                    existingMarketingBanner.AimRu = marketingBanner.AimRu ?? marketingBanner.AimRu;
                    existingMarketingBanner.ImgUrl = marketingBanner.ImgUrl ?? marketingBanner.ImgUrl;

                    await _context.SaveChangesAsync();
                    return Ok(existingMarketingBanner); 
                }
                else
                {
                    Console.WriteLine("No existing section, creating new...");
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
                        ImgUrl = marketingBanner.ImgUrl,
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


        [HttpGet("get-marketingBanner")]
        public async Task<IActionResult> GetProducts()
        {
            var products = await _context.MarketingBanners.ToListAsync();
            return Ok(products);
        }



    }
}
