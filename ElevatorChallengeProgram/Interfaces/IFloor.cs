using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElevatorChallengeProgram.Interfaces
{
    public interface IFloor
    {
        int FloorNumber { get; }
        Queue<int> PeopleWaitingQueue { get; }

        void AddPersonToQueue(int numberOfPeople);
        void RemovePersonFromQueue();
        int GetWaitingPeopleCount();
    }
}
