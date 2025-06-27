using SubmarineDiagnostic.Core.Entities;
using SubmarineDiagnostic.Core.Interfaces;

namespace SubmarineDiagnostic.Infrastructure.Repositories;

public class ReportRepository : IReportRepository
{
    public async Task<IEnumerable<BinaryNumber>> LoadReportAsync(string filePath)
    {
        if (!File.Exists(filePath))
            throw new FileNotFoundException("Arquivo de relatório de diagnóstico não encontrado", filePath);

        var lines = await File.ReadAllLinesAsync(filePath);

        return lines
            .Where(line => !string.IsNullOrWhiteSpace(line))
            .Select(line => new BinaryNumber(line.Trim()))
            .ToList();
    }
}