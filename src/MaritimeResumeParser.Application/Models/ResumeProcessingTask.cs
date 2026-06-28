using System;

namespace MaritimeResumeParser.Application.Models
{
    public sealed class ResumeProcessingTask
    {
        public Guid ExecutionId { get; set; }
        public string FileName { get; set; } = string.Empty;
        public string FileExtension { get; set; } = string.Empty;
        public byte[] FileContents { get; set; } = Array.Empty<byte>();
    }
}
