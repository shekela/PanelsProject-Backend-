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

        // HTTP POST: Add a new sale item
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

        [HttpDelete("delete-item/{id}")]
        public async Task<IActionResult> DeleteSaleItem(int id)
        {
            var saleItem = await _context.SaleItems.FindAsync(id);

            if (saleItem == null)
            {
                return NotFound(new { message = $"Sale item with Id {id} not found." });
            }

            _context.SaleItems.Remove(saleItem);
            await _context.SaveChangesAsync();

            return Ok(new { message = "Deleted Successfully!" });
        }

    }


}
