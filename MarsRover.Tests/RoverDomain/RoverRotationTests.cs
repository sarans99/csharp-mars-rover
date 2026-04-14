using MarsRover.App.RoverDomain;

namespace MarsRover.Tests.RoverDomain;

[TestFixture]
public class RoverRotationTests
{
    [TestCase(CompassDirection.N, Instruction.R, CompassDirection.E)]
    [TestCase(CompassDirection.E, Instruction.R, CompassDirection.S)]
    [TestCase(CompassDirection.S, Instruction.R, CompassDirection.W)]
    [TestCase(CompassDirection.W, Instruction.R, CompassDirection.N)]
    [TestCase(CompassDirection.N, Instruction.L, CompassDirection.W)]
    [TestCase(CompassDirection.W, Instruction.L, CompassDirection.S)]
    [TestCase(CompassDirection.S, Instruction.L, CompassDirection.E)]
    [TestCase(CompassDirection.E, Instruction.L, CompassDirection.N)]
    public void Rotate_ReturnsExpectedDirection_ForLeftAndRightTurns(
        CompassDirection startDirection,
        Instruction instruction,
        CompassDirection expectedDirection)
    {
        var result = RoverRotation.Rotate(startDirection, instruction);
        Assert.That(result, Is.EqualTo(expectedDirection));
    }

    [Test]
    public void Rotate_ThrowsArgumentException_WhenInstructionIsMove()
    {
        Assert.That(
            () => RoverRotation.Rotate(CompassDirection.N, Instruction.M),
            Throws.TypeOf<ArgumentException>());
    }
}
