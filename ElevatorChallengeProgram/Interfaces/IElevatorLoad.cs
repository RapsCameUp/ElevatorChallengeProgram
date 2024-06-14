using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElevatorChallengeProgram.Interfaces
{
    public interface IElevatorLoad
    {
        int Capacity { get; }
        int NumberOfPeople { get; }
        bool AddPerson();
        void OffloadPeople(Action<string> logAction);

        void OpenDoors(Action<string> logAction);
        void CloseDoors(Action<string> logAction);
    }
}
