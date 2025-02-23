using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PanelsProject_Backend.Data;
using PanelsProject_Backend.DTO_s;
using PanelsProject_Backend.Entities;
using PanelsProject_Backend.Interfaces;
using PanelsProject_BackRud.Rutities;

namespace PanelsProject_Backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AboutUsController : ControllerBase
    {
        private readonly DataContext _context;
        private readonly IFileService _fileService;

        public AboutUsController(DataContext context, IFileService fileService)
        {
            _context = context;
            _fileService = fileService;
        }

        
        [HttpPost("create-greeting")]
        public async Task<IActionResult> CreateMainProductSection([FromForm] AboutUsDto aboutUsDto, IFormFile backgroundImage)
        {
            // Validate input
            if (aboutUsDto == null)
            {
                return BadRequest("About Us cannot be null.");
            }
          
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState); // Return validation errors in the response
            }


            try
            {
                var existingAboutUsPage = await _context.AboutUs.FirstOrDefaultAsync();

                if (backgroundImage != null)
                {
                    try
                    {
                        string fileName = Path.GetFileName(existingAboutUsPage.BackgroundImage);
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
                        return StatusCode(500, new { message = "An error occurred while deleting the picture.", details = ex.Message });
                    }

                    var imageFilePath = await _fileService.SaveFileAsync(backgroundImage);
                    aboutUsDto.BackgroundImage = imageFilePath; 
                }

                if (existingAboutUsPage != null)
                {
                    Console.WriteLine("Found existing section, updating...");
                    existingAboutUsPage.GreetingTextEn = aboutUsDto.GreetingTextEn ?? existingAboutUsPage.GreetingTextEn;
                    existingAboutUsPage.GreetingTextKa = aboutUsDto.GreetingTextKa ?? existingAboutUsPage.GreetingTextKa;
                    existingAboutUsPage.GreetingTextRu = aboutUsDto.GreetingTextRu ?? existingAboutUsPage.GreetingTextRu;
                    existingAboutUsPage.TextBoxOneTitleEn = aboutUsDto.TextBoxOneTitleEn ?? existingAboutUsPage.TextBoxOneTitleEn;
                    existingAboutUsPage.TextBoxOneTitleRu = aboutUsDto.TextBoxOneTitleRu ?? existingAboutUsPage.TextBoxOneTitleRu;
                    existingAboutUsPage.TextBoxOneTitleKa = aboutUsDto.TextBoxOneTitleKa ?? existingAboutUsPage.TextBoxOneTitleKa;
                    existingAboutUsPage.TextBoxOneDescriptionEn = aboutUsDto.TextBoxOneDescriptionEn ?? existingAboutUsPage.TextBoxOneDescriptionEn;
                    existingAboutUsPage.TextBoxOneDescriptionRu = aboutUsDto.TextBoxOneDescriptionRu ?? existingAboutUsPage.TextBoxOneDescriptionRu;
                    existingAboutUsPage.TextBoxOneDescriptionKa = aboutUsDto.TextBoxOneDescriptionKa ?? existingAboutUsPage.TextBoxOneDescriptionKa;
                    existingAboutUsPage.TextBoxTwoTitleEn = aboutUsDto.TextBoxTwoTitleEn ?? existingAboutUsPage.TextBoxTwoTitleEn;
                    existingAboutUsPage.TextBoxTwoTitleRu = aboutUsDto.TextBoxTwoTitleRu ?? existingAboutUsPage.TextBoxTwoTitleRu;
                    existingAboutUsPage.TextBoxTwoTitleKa = aboutUsDto.TextBoxTwoTitleKa ?? existingAboutUsPage.TextBoxTwoTitleKa;
                    existingAboutUsPage.TextBoxTwoDescriptionEn = aboutUsDto.TextBoxTwoDescriptionEn ?? existingAboutUsPage.TextBoxTwoDescriptionEn;
                    existingAboutUsPage.TextBoxTwoDescriptionRu = aboutUsDto.TextBoxTwoDescriptionRu ?? existingAboutUsPage.TextBoxTwoDescriptionRu;
                    existingAboutUsPage.TextBoxTwoDescriptionKa = aboutUsDto.TextBoxTwoDescriptionKa ?? existingAboutUsPage.TextBoxTwoDescriptionKa;
                    existingAboutUsPage.BackgroundImage = aboutUsDto.BackgroundImage ?? existingAboutUsPage.BackgroundImage;
                    // Save changes to the existing entry
                    await _context.SaveChangesAsync();
                    return Ok(existingAboutUsPage); // Return the updated section
                }
                else
                {
                    // If no existing section is found, create a new one
                    Console.WriteLine("No existing section, creating new...");
                    var newAboutUsPage = new AboutUs
                    {
                        GreetingTextEn = aboutUsDto.GreetingTextEn,
                        GreetingTextKa = aboutUsDto.GreetingTextKa,
                        GreetingTextRu = aboutUsDto.GreetingTextRu,
                        TextBoxOneTitleEn = aboutUsDto.TextBoxOneTitleEn,
                        TextBoxOneDescriptionEn = aboutUsDto.TextBoxOneDescriptionEn,
                        TextBoxOneTitleKa = aboutUsDto.TextBoxOneTitleKa,
                        TextBoxOneDescriptionKa = aboutUsDto.TextBoxOneDescriptionKa,
                        TextBoxOneTitleRu = aboutUsDto.TextBoxOneTitleRu,
                        TextBoxOneDescriptionRu = aboutUsDto.TextBoxOneDescriptionRu,
                        TextBoxTwoTitleEn = aboutUsDto.TextBoxTwoTitleEn,
                        TextBoxTwoDescriptionEn = aboutUsDto.TextBoxTwoDescriptionEn,
                        TextBoxTwoTitleKa = aboutUsDto.TextBoxTwoTitleKa,
                        TextBoxTwoDescriptionKa = aboutUsDto.TextBoxTwoDescriptionKa,
                        TextBoxTwoTitleRu = aboutUsDto.TextBoxTwoTitleRu,
                        TextBoxTwoDescriptionRu = aboutUsDto.TextBoxTwoDescriptionRu,
                        BackgroundImage = aboutUsDto.BackgroundImage,
                    };

                    // Add the new section to the context
                    _context.AboutUs.Add(newAboutUsPage);

                    // Save the new section to the database
                    await _context.SaveChangesAsync();
                    return Ok(newAboutUsPage); // Return the new section
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.InnerException?.Message);
                Console.WriteLine(ex.StackTrace);
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }

        }

        [HttpGet("get-aboutUsPage")]
        public async Task<IActionResult> GeProductsData()
        {
            var products = await _context.AboutUs.ToListAsync();
            return Ok(products);
        }


    }
}

