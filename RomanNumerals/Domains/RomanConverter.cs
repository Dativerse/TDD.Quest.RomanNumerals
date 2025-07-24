namespace RomanNumerals.Domains;

public class RomanConverter(int numberConstruct)
{
    private readonly Dictionary<int, string> _romanDictionary = new() { { 1, "I" } };

    public string ConvertToRomanCharacter()
    {
        var result = _romanDictionary[numberConstruct];
        return result;
    }
}