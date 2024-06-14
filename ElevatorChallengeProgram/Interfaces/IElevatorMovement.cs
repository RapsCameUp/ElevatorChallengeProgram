using ElevatorChallengeProgram.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElevatorChallengeProgram.Interfaces
{
    public interface IElevatorMovement
    {
        int CurrentFloor { get; }
        bool IsMoving { get; }
        Direction CurrentDirection { get; }
        void MoveToFloor(int floor, Action<string> logAction = null);
    }
}
