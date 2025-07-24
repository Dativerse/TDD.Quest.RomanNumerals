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
            for (int i = 0; i < baseNumber; i++)
            {
                result += _romanDictionary[1];
            }
            
            return result;
        }
        
        if (baseNumber < 9)
        {
            result += _romanDictionary[5];
            
            for (int i = 0; i < baseNumber - 5; i++)
            {
                result += _romanDictionary[1];
            }
            
            return result;
        }
        
        return _romanDictionary[baseNumber];
    }
}