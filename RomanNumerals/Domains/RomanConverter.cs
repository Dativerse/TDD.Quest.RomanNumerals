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
            case < 10:
                return AppendRomanUnder10Character(baseNumber, result);
            case < 40:
            {
                return AppendTensToRomanUnder40Result(result);
            }
            case < 90:
            {
                result += _romanDictionary[50];
                return AppendRomanCharacter(baseNumber - 50, result);
            }
            default: return _romanDictionary[baseNumber];
        }
    }

    private string AppendTensToRomanUnder40Result(string result)
    {
        var tenSize = baseNumber / 10;
        for (var i = 0; i < tenSize; i++)
        {
            result += _romanDictionary[10];
        }
            
        var remainder = baseNumber % 10;
        return AppendRomanUnder10Character(remainder, result);
    }

    private string AppendRomanUnder10Character(int remainder, string result)
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