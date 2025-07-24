using NUnit.Framework.Constraints;

namespace RomanNumerals.Tests;

public class RomanTranslatorControllerTest
{
    [SetUp]
    public void Setup()
    {
    }

    [Test]
    public void should_be_I_when_given_1()
    {
        var controller = new RomanTranslatorController();

        var result = controller.GetRoman(1);
        
        Assert.That(result, Is.EqualTo("I"));
    }
}

public class RomanTranslatorController
{
    public string GetRoman(int i)
    {
        throw new NotImplementedException();
    }
}