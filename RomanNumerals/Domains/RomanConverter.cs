using System.Text;

namespace RomanNumerals.Domains;

public class RomanConverter(int baseNumber)
{
    private readonly Dictionary<int, string> _romanDictionary = new()
    {
        {
            1, "I"
        },
        {
            5, "V"
        },
        {
            10, "X"
        },
        {
            50, "L"
        },
        {
            100, "C"
        },
        {
            500, "D"
        },
        {
            1000, "M"
        }
    };

    public string ConvertToRomanCharacter()
    {
        var result = string.Empty;
        switch (baseNumber)
        {
            case < 9:
                return AppendRomanUnder9Result(baseNumber, result);
            case < 40:
            {
                return AppendRomanUnder40Result(baseNumber, result);
            }
            case < 90:
            {
                return AppendRomanUnder90Result(baseNumber, result);
            }

            case < 400:
            {
                var hundredSize = baseNumber / 100;
                for (var i = 0; i < hundredSize; i++)
                {
                    result += _romanDictionary[100];
                }

                return  Append(baseNumber % 100, result);
            }
            default: return _romanDictionary[baseNumber];
        }
    }

    private string Append(int remainder, string result)
    {
        switch (remainder)
        {
            case < 9:
                return AppendRomanUnder9Result(remainder, result);
            case < 40:
            {
                return AppendRomanUnder40Result(remainder, result);
            }
            case < 90:
            {
                return AppendRomanUnder90Result(remainder, result);
            }
        }
        return result;
    }

    private string AppendRomanUnder90Result(int remainder, string result)
    {
        result += _romanDictionary[50];
        return AppendRomanUnder40Result(remainder - 50, result);
    }

    private string AppendRomanUnder40Result(int remainder, string result)
    {
        var tenSize = remainder / 10;
        for (var i = 0; i < tenSize; i++)
        {
            result += _romanDictionary[10];
        }
            
        var under10Remainder = baseNumber % 10;
        return AppendRomanUnder9Result(under10Remainder, result);
    }

    private string AppendRomanUnder9Result(int remainder, string result)
    {
        switch (remainder)
        {
            case < 4:
                return AppendRomanCharacter(remainder, result);
            case < 9:
                result += _romanDictionary[5];
                return AppendRomanCharacter(remainder - 5, result);
        }

        return string.Empty;
    }

    private string AppendRomanCharacter(int size, string result)
    {
        for (var i = 0; i < size; i++)
        {
            result += _romanDictionary[1];
        }

        return result;
    }
}