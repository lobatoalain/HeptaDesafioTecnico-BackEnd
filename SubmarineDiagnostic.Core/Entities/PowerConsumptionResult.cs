namespace SubmarineDiagnostic.Core.Entities;

public record PowerConsumptionResult
{
    public BinaryNumber GammaRate { get; }
    public BinaryNumber EpsilonRate { get; }
    public int Consumption => GammaRate.ToDecimal() * EpsilonRate.ToDecimal();

    public PowerConsumptionResult(BinaryNumber gammaRate, BinaryNumber epsilonRate)
    {
        GammaRate = gammaRate;
        EpsilonRate = epsilonRate;
    }
}