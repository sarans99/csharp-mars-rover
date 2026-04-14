using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using MarsRover.App.RoverDomain;

namespace MarsRover.App.Parsing
{
    public class InputParser
    {
        public PlateauSize ParsePlateauSize(string input)
        {
            var parts = input.Trim().Split(' ');
            if (parts.Length != 2)
                throw new ArgumentException($"Invalid plateau size input: '{input}'");

            if (!int.TryParse(parts[0], out int width) || !int.TryParse(parts[1], out int height))
                throw new ArgumentException($"Plateau dimensions must be integers: '{input}'");

            if (width < 0 || height < 0)
                throw new ArgumentException($"Plateau dimensions must be positive: '{input}'");

            return new PlateauSize(width, height);
        }

        public Position ParsePosition(string input)
        {
            var parts = input.Trim().Split(' ');
            if (parts.Length != 3)
                throw new ArgumentException($"Invalid position input: '{input}'");

            if (!int.TryParse(parts[0], out int x) || !int.TryParse(parts[1], out int y))
                throw new ArgumentException($"Position coordinates must be integers: '{input}'");

            if (!Enum.TryParse(parts[2], out CompassDirection facing))
                throw new ArgumentException($"Invalid compass direction: '{parts[2]}'");

            return new Position(x, y, facing);
        }

        public List<Instruction> ParseInstructions(string input)
        {
            if (string.IsNullOrWhiteSpace(input))
                throw new ArgumentException("Instruction string cannot be empty");

            return input.Trim().Select(c =>
            {
                if (!Enum.TryParse(c.ToString(), out Instruction instruction))
                    throw new ArgumentException($"Invalid instruction character: '{c}'");
                return instruction;
            }).ToList();
        }
    }
}
