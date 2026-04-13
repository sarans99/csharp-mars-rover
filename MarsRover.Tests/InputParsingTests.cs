using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using MarsRover.App.RoverDomain;
using MarsRover.App.Parsing;

namespace MarsRover.Tests.Parsing;

[TestFixture]
public class InputParserTests
{

    [Test]
    public void ParsePlateauSize_ReturnsCorrectSize_WhenGivenValidInput()
    {
        var parser = new InputParser();
        var result = parser.ParsePlateauSize("5 5");
        Assert.That(result, Is.EqualTo(new PlateauSize(5, 5)));
    }

    [Test]
    public void ParsePlateauSize_ReturnsCorrectSize_WhenGivenDifferentDimensions()
    {
        var parser = new InputParser();
        var result = parser.ParsePlateauSize("10 3");
        Assert.That(result, Is.EqualTo(new PlateauSize(10, 3)));
    }

    [Test]
    public void ParsePlateauSize_Throws_WhenGivenNonInts()
    {
        var parser = new InputParser();
        Assert.That(() => parser.ParsePlateauSize("abc def"),
            Throws.TypeOf<ArgumentException>());
    }

    [Test]
    public void ParsePlateauSize_Throws_WhenGivenWrongNumberOfParts()
    {
        var parser = new InputParser();
        Assert.That(() => parser.ParsePlateauSize("5"),
            Throws.TypeOf<ArgumentException>());
    }

    [Test]
    public void ParsePlateauSize_Throws_WhenGivenNegativeInts()
    {
        var parser = new InputParser();
        Assert.That(() => parser.ParsePlateauSize("-1 5"),
            Throws.TypeOf<ArgumentException>());
    }

    // ParsePosition tests

    [Test]
    public void ParsePosition_ReturnsCorrectPosition_WhenGivenValidInput()
    {
        var parser = new InputParser();
        var result = parser.ParsePosition("1 2 N");
        Assert.That(result, Is.EqualTo(new Position(1, 2, CompassDirection.N)));
    }

    [Test]
    public void ParsePosition_ReturnsCorrectPosition_ForEachCompassDirection()
    {
        var parser = new InputParser();
        Assert.Multiple(() =>
        {
            Assert.That(parser.ParsePosition("0 0 N"), Is.EqualTo(new Position(0, 0, CompassDirection.N)));
            Assert.That(parser.ParsePosition("0 0 S"), Is.EqualTo(new Position(0, 0, CompassDirection.S)));
            Assert.That(parser.ParsePosition("0 0 E"), Is.EqualTo(new Position(0, 0, CompassDirection.E)));
            Assert.That(parser.ParsePosition("0 0 W"), Is.EqualTo(new Position(0, 0, CompassDirection.W)));
        });
    }

    [Test]
    public void ParsePosition_Throws_WhenGivenInvalidDirection()
    {
        var parser = new InputParser();
        Assert.That(() => parser.ParsePosition("1 2 X"),
            Throws.TypeOf<ArgumentException>());
    }

    [Test]
    public void ParsePosition_Throws_WhenGivenNonIntsCoords()
    {
        var parser = new InputParser();
        Assert.That(() => parser.ParsePosition("a b N"),
            Throws.TypeOf<ArgumentException>());
    }

    [Test]
    public void ParsePosition_Throws_WhenGivenWrongNumberOfParts()
    {
        var parser = new InputParser();
        Assert.That(() => parser.ParsePosition("1 2"),
            Throws.TypeOf<ArgumentException>());
    }

    // ParseInstructions tests

    [Test]
    public void ParseInstructions_ReturnsCorrectInstructions_WhenGivenValidInput()
    {
        var parser = new InputParser();
        var result = parser.ParseInstructions("LMRM");
        Assert.That(result, Is.EqualTo(new List<Instruction> { Instruction.L, Instruction.M, Instruction.R, Instruction.M }));
    }

    [Test]
    public void ParseInstructions_ReturnsSingleInstruction_WhenGivenSingleCharacter()
    {
        var parser = new InputParser();
        var result = parser.ParseInstructions("M");
        Assert.That(result, Is.EqualTo(new List<Instruction> { Instruction.M }));
    }

    [Test]
    public void ParseInstructions_Throws_WhenGivenInvalidCharacter()
    {
        var parser = new InputParser();
        Assert.That(() => parser.ParseInstructions("LMXR"),
            Throws.TypeOf<ArgumentException>());
    }

    [Test]
    public void ParseInstructions_Throws_WhenGivenEmptyString()
    {
        var parser = new InputParser();
        Assert.That(() => parser.ParseInstructions(""),
            Throws.TypeOf<ArgumentException>());
    }

    [Test]
    public void ParseInstructions_Throws_WhenGivenBlankSpace()
    {
        var parser = new InputParser();
        Assert.That(() => parser.ParseInstructions("   "),
            Throws.TypeOf<ArgumentException>());
    }
}
