using MarsRover.App.Parsing;
using MarsRover.App.RoverDomain;

var parser = new InputParser();

var plateauInput = "5 5";
var rover1PositionInput = "1 2 N";
var rover1InstructionsInput = "LMLMLMLMM";
var rover2PositionInput = "3 3 E";
var rover2InstructionsInput = "MMRMMRMRRM";

var plateauSize = parser.ParsePlateauSize(plateauInput);
var rover1Position = parser.ParsePosition(rover1PositionInput);
var rover1Instructions = parser.ParseInstructions(rover1InstructionsInput);
var rover2Position = parser.ParsePosition(rover2PositionInput);
var rover2Instructions = parser.ParseInstructions(rover2InstructionsInput);

Console.WriteLine($"Plateau: {plateauSize}");
Console.WriteLine($"Rover 1 Position: {rover1Position}");
Console.WriteLine($"Rover 1 Instructions: {string.Join(", ", rover1Instructions)}");
Console.WriteLine($"Rover 2 Position: {rover2Position}");
Console.WriteLine($"Rover 2 Instructions: {string.Join(", ", rover2Instructions)}");
