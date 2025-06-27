using SubmarineDiagnostic.Core.Entities;
using SubmarineDiagnostic.Core.Interfaces;

namespace SubmarineDiagnostic.Core.Services;

public class DiagnosticService : IDiagnosticService
{
    private readonly IReportRepository _reportRepository;

    public DiagnosticService(IReportRepository reportRepository)
    {
        _reportRepository = reportRepository;
    }

    public PowerConsumptionResult CalculatePowerConsumption(IEnumerable<BinaryNumber> diagnosticReport)
    {
        if (diagnosticReport == null)
            throw new ArgumentNullException(nameof(diagnosticReport));

        if (!diagnosticReport.Any())
            throw new ArgumentException("Diagnostic report cannot be empty", nameof(diagnosticReport));

        var firstNumberLength = diagnosticReport.First().Value.Length;
        if (diagnosticReport.Any(num => num.Value.Length != firstNumberLength))
            throw new ArgumentException("All binary numbers must have the same length", nameof(diagnosticReport));

        var gammaBits = new char[firstNumberLength];
        var epsilonBits = new char[firstNumberLength];

        Parallel.For(0, firstNumberLength, i =>
        {
            var (zeros, ones) = CountBitsAtPosition(diagnosticReport, i);

            gammaBits[i] = zeros > ones ? '0' : '1';
            epsilonBits[i] = zeros > ones ? '1' : '0';
        });

        return new PowerConsumptionResult(
            new BinaryNumber(new string(gammaBits)),
            new BinaryNumber(new string(epsilonBits)));
    }

    public async Task<PowerConsumptionResult> CalculatePowerConsumptionFromFileAsync(string filePath)
    {
        var report = await _reportRepository.LoadReportAsync(filePath);
        return CalculatePowerConsumption(report);
    }

    private (int zeros, int ones) CountBitsAtPosition(IEnumerable<BinaryNumber> report, int position)
    {
        int zeros = 0, ones = 0;

        foreach (var binaryNumber in report)
        {
            if (binaryNumber.GetBitAtPosition(position) == '0')
                zeros++;
            else
                ones++;
        }

        return (zeros, ones);
    }
}