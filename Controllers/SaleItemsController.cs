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
    public class SaleItemsController : ControllerBase
    {
        private readonly DataContext _context;
        private readonly IFileService _fileService;  // Inject the file service

        public SaleItemsController(DataContext context, IFileService fileService)
        {
            _context = context;
            _fileService = fileService;
        }

        [Authorize(Roles = "Admin")]
        [HttpPost("add-saleitem")]
        public async Task<ActionResult<SaleItem>> AddSaleItem([FromForm]SaleItem saleItem, IFormFile picture)
        {
            if (saleItem == null)
            {
                return BadRequest("Sale item cannot be null.");
            }
            if (picture != null) 
            { 
                saleItem.Picture = await _fileService.SaveFileAsync(picture);
            }

            _context.SaleItems.Add(saleItem);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetSaleItems), new { id = saleItem.Id }, saleItem);
        }

        [HttpGet("get-saleitems")]
        public async Task<ActionResult<IEnumerable<SaleItem>>> GetSaleItems()
        {
            var saleItems = await _context.SaleItems.ToListAsync();
            return Ok(saleItems);
        }

        [Authorize(Roles = "Admin")]
        [HttpDelete("delete-item/{id}")]
        public async Task<IActionResult> DeleteSaleItem(int id)
        {
            var saleItem = await _context.SaleItems.FindAsync(id);

            if (saleItem == null)
            {
                return NotFound(new { message = $"Sale item with Id {id} not found." });
            }

            if (!string.IsNullOrEmpty(saleItem.Picture))
            {
                try
                {
                    string fileName = Path.GetFileName(saleItem.Picture);
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
                catch (Exception ex)
                {
                    // Handle error if file deletion fails
                    return StatusCode(500, new { message = "An error occurred while deleting the picture.", details = ex.Message });
                }
            }

            _context.SaleItems.Remove(saleItem);
            await _context.SaveChangesAsync();

            return Ok(new { message = "Deleted Successfully!" });
        }

    }


}
