using MaritimeResumeParser.Application.Interfaces;
using MaritimeResumeParser.Application.Models;
using MaritimeResumeParser.Domain.Models;
using Microsoft.AspNetCore.Mvc;
using System.IO;
using System.Threading.Tasks;

namespace MaritimeResumeParser.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ResumeViewerController : ControllerBase
    {
        private readonly IImageNormalizationService _imageNormalizationService;
        private readonly IResumeParserService _resumeParserService;

        public ResumeViewerController(
            IImageNormalizationService imageNormalizationService,
            IResumeParserService resumeParserService)
        {
            _imageNormalizationService = imageNormalizationService;
            _resumeParserService = resumeParserService;
        }

        [HttpPost("parse")]
        public async Task<IActionResult> ParseAsync([FromForm] IFormFile file)
        {
            if (file == null || file.Length == 0)
                return BadRequest("A resume file must be provided.");

            using var stream = file.OpenReadStream();
            var normalizedImages = await _imageNormalizationService.NormalizeAsync(stream, Path.GetExtension(file.FileName), HttpContext.RequestAborted);
            var result = await _resumeParserService.ParseResumeAsync(normalizedImages, HttpContext.RequestAborted);

            return Ok(result);
        }
    }
}
