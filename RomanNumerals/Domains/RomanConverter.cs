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
        if (baseNumber < 4)
        {
            result = AppendRomanCharacter(baseNumber, result);
            
            return result;
        }
        
        if (baseNumber < 9)
        {
            result += _romanDictionary[5];
            result = AppendRomanCharacter(baseNumber - 5, result);
            
            return result;
        }
        
        return _romanDictionary[baseNumber];
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