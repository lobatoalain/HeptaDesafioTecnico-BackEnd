using SubmarineDiagnostic.Core.Entities;

namespace SubmarineDiagnostic.Tests.Unit.Core.Entities;

public class BinaryNumberTests
{
    [Theory]
    [InlineData("1010", 10)]
    [InlineData("0001", 1)]
    public void ToDecimal_ValidBinary_ReturnsCorrectDecimal(string binary, int expected)
    {
        var number = new BinaryNumber(binary);
        Assert.Equal(expected, number.ToDecimal());
    }

    [Theory]
    [InlineData(null)]
    [InlineData("")]
    [InlineData("102")]
    public void Constructor_InvalidBinary_ThrowsException(string invalidBinary)
    {
        Assert.Throws<ArgumentException>(() => new BinaryNumber(invalidBinary));
    }
}