namespace RomanNumerals.Controllers;

public class RomanTranslatorController
{
    public string GetRoman(int i)
    {
        var romanDictionary = new Dictionary<int, string> { {1, "I"}};
        
        var result = romanDictionary[i];
        
        return result;
    }
}