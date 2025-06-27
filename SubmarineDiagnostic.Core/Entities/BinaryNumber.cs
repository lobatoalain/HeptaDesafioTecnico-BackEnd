namespace SubmarineDiagnostic.Core.Entities;

public record BinaryNumber
{
    public string Value { get; }

    public BinaryNumber(string value)
    {
        if (string.IsNullOrWhiteSpace(value))
            throw new ArgumentException("Binary number cannot be null or empty", nameof(value));

        if (value.Any(c => c != '0' && c != '1'))
            throw new ArgumentException($"Invalid binary number: '{value}'", nameof(value));

        Value = value;
    }

    public int ToDecimal() => Convert.ToInt32(Value, 2);

    public char GetBitAtPosition(int position)
    {
        if (position < 0 || position >= Value.Length)
            throw new ArgumentOutOfRangeException(nameof(position));

        return Value[position];
    }
}