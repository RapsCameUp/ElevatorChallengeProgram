using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElevatorChallengeProgram.CustomExceptions
{
    public class InvalidFloorException : Exception
    {
        public InvalidFloorException(string message) : base(message) { }
    }
}
