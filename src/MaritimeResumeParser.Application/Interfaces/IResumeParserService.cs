using MaritimeResumeParser.Domain.Models;
using System.Threading;
using System.Threading.Tasks;

namespace MaritimeResumeParser.Application.Interfaces
{
    public interface IResumeParserService
    {
        Task<MaritimeCvExtractionResult> ParseResumeAsync(byte[][] normalizedImages, CancellationToken cancellationToken = default);
    }
}
