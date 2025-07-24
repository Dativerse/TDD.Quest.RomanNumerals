using System.Text;

namespace RomanNumerals.Domains;

public class RomanConverter
{
    private readonly int _number;

    // Roman numeral symbols and their values
    private static readonly (int Value, string Symbol)[] RomanNumerals =
    {
        (1000, "M"),
        (900, "CM"),
        (500, "D"),
        (400, "CD"),
        (100, "C"),
        (90, "XC"),
        (50, "L"),
        (40, "XL"),
        (10, "X"),
        (9, "IX"),
        (5, "V"),
        (4, "IV"),
        (1, "I")
    };

    public RomanConverter(int number)
    {
        _number = number;
    }

    public string ConvertToRomanCharacter()
    {
        if (_number <= 0 || _number > 3999)
        {
            throw new ArgumentOutOfRangeException(nameof(_number), "Number must be between 1 and 3999");
        }

        var result = new StringBuilder();
        var remaining = _number;

        foreach (var (value, symbol) in RomanNumerals)
        {
            while (remaining >= value)
            {
                result.Append(symbol);
                remaining -= value;
            }
        }

        return result.ToString();
    }
}