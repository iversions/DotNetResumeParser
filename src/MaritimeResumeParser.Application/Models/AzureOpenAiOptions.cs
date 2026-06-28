namespace MaritimeResumeParser.Application.Models
{
    public class AzureOpenAiOptions
    {
        public string? Endpoint { get; set; }
        public string? ApiKey { get; set; }
        public string? DeploymentName { get; set; }
        public string? VisionModel { get; set; }
    }
}
