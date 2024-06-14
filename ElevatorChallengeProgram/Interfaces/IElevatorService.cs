using ElevatorChallengeProgram.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElevatorChallengeProgram.Interfaces
{
    public interface IElevatorService
    {
        List<Floor> Floors { get; }
        List<Elevator> GetElevators();
        void CallElevator(int floorNumber);
        void SetNumberOfPeopleWaiting(int floorNumber, int numberOfPeopleWaiting);
        int GetElevatorIndex(Elevator elevator);
        Elevator FindNearestAvailableElevator(int floorNumber);
    }
}
