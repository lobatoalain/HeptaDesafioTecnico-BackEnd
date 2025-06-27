using SubmarineDiagnostic.Core.Entities;

namespace SubmarineDiagnostic.Core.Interfaces;

public interface IDiagnosticService
{
    PowerConsumptionResult CalculatePowerConsumption(IEnumerable<BinaryNumber> diagnosticReport);
    Task<PowerConsumptionResult> CalculatePowerConsumptionFromFileAsync(string filePath);
}