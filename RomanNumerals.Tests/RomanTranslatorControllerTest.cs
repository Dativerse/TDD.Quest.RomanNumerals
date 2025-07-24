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
    public void GetRoman_WhenCall_ReturnsExpectedScore(int input, string expected)
    {
        var controller = new RomanTranslatorController();

        var result = controller.GetRoman(input);
        
        Assert.That(result, Is.EqualTo(expected));
    }
}