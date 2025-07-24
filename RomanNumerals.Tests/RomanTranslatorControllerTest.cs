using RomanNumerals.Controllers;

namespace RomanNumerals.Tests;

public class RomanTranslatorControllerTest
{
    [SetUp]
    public void Setup()
    {
    }

    [Test]
    [TestCase(1, "I", Description = "Basic case I when given 1")]
    [TestCase(5, "V", Description = "Basic case V when given 5")]
    [TestCase(10, "X", Description = "Basic case X when given 10")]
    [TestCase(50, "L", Description = "Basic case L when given 50")]
    [TestCase(100, "C", Description = "Basic case C when given 100")]
    [TestCase(500, "D", Description = "Basic case D when given 500")]
    [TestCase(1000, "M", Description = "Basic case M when given 1000")]
    [TestCase(2, "II", Description = "Addition case II when given 2")]
    [TestCase(8, "VIII", Description = "Addition case VIII when given 8")]
    [TestCase(15, "XV", Description = "Addition case XV when given 15")]
    [TestCase(51, "LI", Description = "Addition case LI when given 51")]
    [TestCase(88, "LXXXVIII", Description = "Addition case LXXXVIII when given 88")]
    [TestCase(121, "CXXI", Description = "Addition case CXXI when given 121")]
    [TestCase(300, "CCC", Description = "Addition case CCC when given 300")]
    [TestCase(321, "CCCXXI", Description = "Addition case CCCXXI when given 321")]
    [TestCase(511, "DXI", Description = "Addition case DXI when given 521")]
    [TestCase(1322 , "MCCCXXII", Description = "Addition case MCCCXXII when given 1322")]
    [TestCase(2222 , "MMCCXXII", Description = "Addition case MMCCXXII when given 2222")]
    [TestCase(4 , "IV", Description = "Subtraction case IV when given 4")]
    [TestCase(9 , "IX", Description = "Subtraction case IX when given 9")]
    [TestCase(40 , "XL", Description = "Subtraction case XL when given 40")]
    [TestCase(90 , "XC", Description = "Subtraction case XC when given 90")]
    [TestCase(400 , "CD", Description = "Subtraction case CD when given 400")]
    [TestCase(900 , "CM", Description = "Subtraction case CM when given 900")]
    
    [TestCase(14 , "XIV", Description = "Subtraction case XIV when given 14")]
    [TestCase(19 , "XIX", Description = "Subtraction case XIX when given 19")]
    [TestCase(44 , "XLIV", Description = "Subtraction case XLIV when given 44")]
    [TestCase(49 , "XLIX", Description = "Subtraction case XLIX when given 49")]
    [TestCase(99 , "XCIX", Description = "Subtraction case XCIX when given 99")]
    [TestCase(135 , "CXXXV", Description = "Standard case CXXXV when given 135")]
    [TestCase(498 , "CDXCVIII", Description = "Subtraction case CDXCVIII when given 498")]
    [TestCase(952 , "CMLII", Description = "Subtraction case CMLII when given 952")]
    [TestCase(1345 , "MCCCXLV", Description = "Standard case MCCCXLV when given 1345")]
    [TestCase(2457 , "MMCDLVII", Description = "Standard case MMCDLVII when given 2457")]
    [TestCase(2986 , "MMCMLXXXVI", Description = "Subtraction case MMCMLXXXVI when given 2986")]
    public void GetRoman_WhenCall_ReturnsExpectedScore(int input, string expected)
    {
        var controller = new RomanTranslatorController();

        var result = controller.GetRoman(input);
        
        Assert.That(result, Is.EqualTo(expected));
    }
}