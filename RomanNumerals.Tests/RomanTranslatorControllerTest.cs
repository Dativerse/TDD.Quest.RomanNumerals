using NUnit.Framework.Constraints;
using RomanNumerals.Controllers;

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