using ElevatorChallengeProgram.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElevatorChallengeProgram.Interfaces
{
    public interface IElevatorController
    {
        List<Floor> Floors { get; }
        List<Elevator> Elevators { get; }

        void CallElevator(int floorNumber);
        void SetNumberOfPeopleWaiting(int floorNumber, int numberOfPeopleWaiting);
        void DisplayElevatorStatus();
        void DisplayFloorStatus();
    }
}
