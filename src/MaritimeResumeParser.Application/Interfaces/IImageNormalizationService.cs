using System.IO;
using System.Threading;
using System.Threading.Tasks;

namespace MaritimeResumeParser.Application.Interfaces
{
    public interface IImageNormalizationService
    {
        Task<byte[][]> NormalizeAsync(Stream fileStream, string fileExtension, CancellationToken cancellationToken = default);
    }
}
