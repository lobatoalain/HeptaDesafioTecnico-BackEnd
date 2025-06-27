using SubmarineDiagnostic.Core.Entities;

namespace SubmarineDiagnostic.Core.Interfaces;

public interface IReportRepository
{
    Task<IEnumerable<BinaryNumber>> LoadReportAsync(string filePath);
}