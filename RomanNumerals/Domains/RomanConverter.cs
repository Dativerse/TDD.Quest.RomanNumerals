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
                return AppendRomanUnder400Result(baseNumber, result);
            }
            case < 900:
            {
                return AppendRomanUnder900Result(baseNumber, result);
            }
            case < 4000:
            {
                var thousandSize = baseNumber / 1000;
                for (var i = 0; i < thousandSize; i++)
                {
                    result += _romanDictionary[1000];
                }
                
                return AppendRomanSummaryUnder900Result(baseNumber % 1000, result);
            }
            default: return _romanDictionary[baseNumber];
        }
    }

    private string AppendRomanSummaryUnder900Result(int remainder, string result)
    {
        return remainder switch
        {
            < 400 => AppendRomanUnder400Result(remainder, result),
            < 900 => AppendRomanUnder900Result(remainder, result),
            _ => result
        };
    }

    private string AppendRomanUnder900Result(int remainder, string result)
    {
        result += _romanDictionary[500];

        return AppendRomanUnder400Result(remainder % 500, result);
    }

    private string AppendRomanUnder400Result(int remainder, string result)
    {
        var hundredSize = remainder / 100;
        for (var i = 0; i < hundredSize; i++)
        {
            result += _romanDictionary[100];
        }

        return  AppendRomanSummaryUnder90Result(remainder % 100, result);
    }

    private string AppendRomanSummaryUnder90Result(int remainder, string result)
    {
        return remainder switch
        {
            < 9 => AppendRomanUnder9Result(remainder, result),
            < 40 => AppendRomanUnder40Result(remainder, result),
            < 90 => AppendRomanUnder90Result(remainder, result),
            _ => result
        };
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
            case < 5:
                return AppendRomanCharacter(remainder, result);
            case < 9:
                result += _romanDictionary[5];
                return AppendRomanCharacter(remainder - 5, result);
        }

        return string.Empty;
    }

    private string AppendRomanCharacter(int size, string result)
    {
        if (size == 4)
        {
            result += _romanDictionary[1] + _romanDictionary[5];
            return result;
        }
        
        for (var i = 0; i < size; i++)
        {
            result += _romanDictionary[1];
        }

        return result;
    }
}