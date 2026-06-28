using MaritimeResumeParser.Domain.Models;
using System.Threading;
using System.Threading.Tasks;

namespace MaritimeResumeParser.Application.Interfaces
{
    public interface IResumeRepository
    {
        Task<int> SaveResumeAsync(MaritimeCvExtractionResult resume, CancellationToken cancellationToken = default);
    }
}
