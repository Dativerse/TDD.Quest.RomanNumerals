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
    public void GetRoman_WhenCall_ReturnsExpectedScore(int input, string expected)
    {
        var controller = new RomanTranslatorController();

        var result = controller.GetRoman(input);
        
        Assert.That(result, Is.EqualTo(expected));
    }
}