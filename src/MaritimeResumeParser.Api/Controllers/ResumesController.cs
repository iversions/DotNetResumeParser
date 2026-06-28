using MaritimeResumeParser.Application.Interfaces;
using MaritimeResumeParser.Application.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.IO;
using System.Threading.Channels;
using System.Threading.Tasks;

namespace MaritimeResumeParser.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ResumesController : ControllerBase
    {
        private readonly Channel<ResumeProcessingTask> _channel;

        public ResumesController(Channel<ResumeProcessingTask> channel)
        {
            _channel = channel;
        }

        [HttpPost("upload")]
        public async Task<IActionResult> UploadAsync([
            FromForm] IFormFile file)
        {
            if (file == null || file.Length == 0)
            {
                return BadRequest("A resume file must be provided.");
            }

            var extension = Path.GetExtension(file.FileName);
            using var memoryStream = new MemoryStream();
            await file.CopyToAsync(memoryStream);

            var task = new ResumeProcessingTask
            {
                ExecutionId = Guid.NewGuid(),
                FileName = file.FileName,
                FileExtension = extension,
                FileContents = memoryStream.ToArray()
            };

            await _channel.Writer.WriteAsync(task);

            return Accepted(new { task.ExecutionId, task.FileName });
        }
    }
}
