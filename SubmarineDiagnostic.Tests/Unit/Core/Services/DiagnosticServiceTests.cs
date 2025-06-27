using Moq;
using SubmarineDiagnostic.Core.Entities;
using SubmarineDiagnostic.Core.Interfaces;
using SubmarineDiagnostic.Core.Services;

namespace SubmarineDiagnostic.Tests.Unit.Core.Services;

public class DiagnosticServiceTests
{
    private readonly Mock<IReportRepository> _mockRepo;
    private readonly DiagnosticService _service;

    public DiagnosticServiceTests()
    {
        _mockRepo = new Mock<IReportRepository>();
        _service = new DiagnosticService(_mockRepo.Object);
    }

    [Fact]
    public void CalculatePowerConsumption_WithValidReport_ReturnsCorrectResult()
    {
        // Arrange
        var report = new List<BinaryNumber>
        {
            new("00100"),
            new("11110"),
            new("10110")
        };

        // Act
        var result = _service.CalculatePowerConsumption(report);

        // Assert
        Assert.Equal("10110", result.GammaRate.Value);
        Assert.Equal("01001", result.EpsilonRate.Value);
        Assert.Equal(22, result.GammaRate.ToDecimal());
        Assert.Equal(9, result.EpsilonRate.ToDecimal());
        Assert.Equal(198, result.Consumption);
    }

    [Fact]
    public async Task CalculatePowerConsumptionFromFileAsync_WithValidFile_ReturnsResult()
    {
        // Arrange
        var testData = new List<BinaryNumber>
        {
            new("00100"),
            new("11110")
        };

        _mockRepo.Setup(r => r.LoadReportAsync(It.IsAny<string>()))
                .ReturnsAsync(testData);

        // Act
        var result = await _service.CalculatePowerConsumptionFromFileAsync("any_path.txt");

        // Assert
        Assert.NotNull(result);
        _mockRepo.Verify(r => r.LoadReportAsync("any_path.txt"), Times.Once);
    }
}