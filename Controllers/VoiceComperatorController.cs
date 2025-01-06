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
    public class VoiceComperatorController : ControllerBase
    {
        private readonly DataContext _context;
        private readonly IFileService _fileService;
        public VoiceComperatorController(DataContext context, IFileService fileService)
        {
            _context = context;
            _fileService = fileService;
        }


        [HttpGet("get-VoiceExamples")]
        public async Task<IActionResult> GetVoices()
        {
            var voices = await _context.VoiceComperator.ToListAsync();
            return Ok(voices);
        }

        [HttpPost("AddVoices")]
        public async Task<IActionResult> AddVoices(IFormFile voiceAcupanelFile, IFormFile voiceWOAcupanelFile)
        {
            try
            {
                if (voiceAcupanelFile == null || voiceWOAcupanelFile == null)
                {
                    return BadRequest("Both files are required.");
                }

                // Save the files using _fileService and get the paths
                var voiceAcupanelPath = await _fileService.SaveFileAsync(voiceAcupanelFile);
                var voiceWOAcupanelPath = await _fileService.SaveFileAsync(voiceWOAcupanelFile);

                // Create a new VoiceComperator object
                var newVoice = new VoiceComperator
                {
                    VoiceAcupanel = voiceAcupanelPath,
                    VoiceWOAcupanel = voiceWOAcupanelPath
                };

                // Add the new VoiceComperator entry to the database
                _context.VoiceComperator.Add(newVoice);
                await _context.SaveChangesAsync();

                return Ok(newVoice); // Return the newly added voice
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }


        [HttpPut("update-voice/{id}")]
        public async Task<IActionResult> UpdateVoice(int id, IFormFile voiceAcupanelFile, IFormFile voiceWOAcupanelFile)
        {
            try
            {
                var existingVoice = await _context.VoiceComperator.FindAsync(id);
                if (existingVoice == null)
                {
                    return NotFound(new { message = "Voice entry not found." });
                }

                // If new files are provided, save them using _fileService
                if (voiceAcupanelFile != null)
                {
                    existingVoice.VoiceAcupanel = await _fileService.SaveFileAsync(voiceAcupanelFile);
                }

                if (voiceWOAcupanelFile != null)
                {
                    existingVoice.VoiceWOAcupanel = await _fileService.SaveFileAsync(voiceWOAcupanelFile);
                }

                _context.VoiceComperator.Update(existingVoice);
                await _context.SaveChangesAsync();

                return Ok(new { message = "Voice updated successfully." });
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }


        [HttpDelete("delete-voice/{id}")]
        public async Task<IActionResult> DeleteVoice(int id)
        {
            // Find the voice entry by ID
            var existingVoice = await _context.VoiceComperator.FindAsync(id);
            if (existingVoice == null)
            {
                return NotFound(new { message = "Voice entry not found." });
            }

            // Remove the voice entry from the database
            _context.VoiceComperator.Remove(existingVoice);
            await _context.SaveChangesAsync();

            return Ok(new { message = "Voice entry deleted successfully." });
        }
    }
}
