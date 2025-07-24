using RomanNumerals.Domains;

namespace RomanNumerals.Controllers;

public class RomanTranslatorController
{
    public string GetRoman(int input)
    {
        var romanConverter = new RomanConverter(input);

        return romanConverter.ConvertToRomanCharacter();
    }
}