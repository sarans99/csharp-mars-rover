using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarsRover.App.RoverDomain
{
    public record Position(int X, int Y, CompassDirection Facing);
}
