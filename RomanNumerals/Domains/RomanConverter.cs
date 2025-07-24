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
                return AppendRomanUnder10Result(baseNumber, result);
            case < 50:
            {
                return AppendRomanUnder50Result(baseNumber, result);
            }
            case < 100:
            {
                return AppendRomanUnder100Result(baseNumber, result);
            }
            case < 500:
            {
                return AppendRomanUnder500Result(baseNumber, result);
            }
            case < 1000:
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
            < 500 => AppendRomanUnder500Result(remainder, result),
            < 900 => AppendRomanUnder900Result(remainder, result),
            _ => result
        };
    }

    private string AppendRomanUnder900Result(int remainder, string result)
    {
        if (remainder < 900)
        {
            result += _romanDictionary[500];
        }
        else
        {
            result += _romanDictionary[100] + _romanDictionary[1000];
            return AppendRomanUnder100Result(remainder % 100, result);       
        }
        
        return AppendRomanUnder500Result(remainder - 500, result);
    }

    private string AppendRomanUnder500Result(int remainder, string result)
    {
        if (remainder < 400)
        {
            var hundredSize = remainder / 100;
            for (var i = 0; i < hundredSize; i++)
            {
                result += _romanDictionary[100];
            }
        }
        else
        {
            result += _romanDictionary[100] + _romanDictionary[500];
        }

        return  AppendRomanSummaryUnder90Result(remainder % 100, result);
    }

    private string AppendRomanSummaryUnder90Result(int remainder, string result)
    {
        return remainder switch
        {
            < 9 => AppendRomanUnder10Result(remainder, result),
            < 50 => AppendRomanUnder50Result(remainder, result),
            < 100 => AppendRomanUnder100Result(remainder, result),
            _ => result
        };
    }

    private string AppendRomanUnder100Result(int remainder, string result)
    {
        switch (remainder)
        {
            case <= 0:
                return result;
            case < 90:
                result += _romanDictionary[50];
                break;
            default:
                result += _romanDictionary[10] + _romanDictionary[100];
                return AppendRomanUnder10Result(remainder % 10, result);
        }

        return AppendRomanUnder50Result(remainder - 50, result);
    }

    private string AppendRomanUnder50Result(int remainder, string result)
    {
        switch (remainder)
        {
            case <= 0:
                return result;
            case < 40:
            {
                var tenSize = remainder / 10;
                for (var i = 0; i < tenSize; i++)
                {
                    result += _romanDictionary[10];
                }

                break;
            }
            default:
                result += _romanDictionary[10] + _romanDictionary[50];
                break;
        }

        var under10Remainder = baseNumber % 10;
        return AppendRomanUnder10Result(under10Remainder, result);
    }

    private string AppendRomanUnder10Result(int remainder, string result)
    {
        switch (remainder)
        {
            case < 5:
                return AppendRomanCharacter(remainder, result);
            case < 10:
                if (remainder == 9)
                {
                    result += _romanDictionary[1] + _romanDictionary[10];
                    return result;
                }
                
                result += _romanDictionary[5];
                return AppendRomanCharacter(remainder % 5, result);
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