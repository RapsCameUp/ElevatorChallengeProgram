
using ElevatorChallengeProgram.CustomExceptions;
using ElevatorChallengeProgram.Enums;
using ElevatorChallengeProgram.Interfaces;
using ElevatorChallengeProgram.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElevatorChallengeProgram.Models
{
    /// <summary>
    /// Represents an elevator with movement and load management functionalities.
    /// Implements IElevatorMovement and IElevatorLoad interfaces.
    /// </summary>
    public class Elevator : IElevatorMovement, IElevatorLoad
    {

        // Properties to hold the current state of the elevator
        public int CurrentFloor { get; private set; }
        public bool IsMoving { get; private set; }
        public Direction CurrentDirection { get; private set; }
        public int Capacity { get; private set; }
        public int NumberOfPeople { get; private set; }
        public bool DoorsOpen { get; private set; }

        public Elevator(int capacity)
        {
            CurrentFloor = 1;
            IsMoving = false;
            CurrentDirection = Direction.Stationary;
            Capacity = capacity;
            NumberOfPeople = 0;
            DoorsOpen = false;
        }


        /// <summary>
        /// Moves the elevator to the specified floor
        /// </summary>
        /// <param name="floor">The target floor to move to.</param>
        /// <param name="logAction">Optional action to log messages.</param>
        public void MoveToFloor(int floor, Action<string> logAction = null)
        {
            if (floor == CurrentFloor)
            {
                //log message - displays in the console
                logAction?.Invoke($"Elevator is already on floor {floor}.");

                OpenDoors(Logger.LogToConsoleYellow);
                return;
            }

            CurrentDirection = floor > CurrentFloor ? Direction.Up : Direction.Down;
            IsMoving = true;
            CloseDoors(Logger.LogToConsoleYellow);

            while (CurrentFloor != floor)
            {
                CurrentFloor += CurrentDirection == Direction.Up ? 1 : -1;

                // Simulate the time it takes to move between floors
                Thread.Sleep(1000); // Wait for 1 second to simulate movement

                //log message - displays in the console
                logAction?.Invoke($"Elevator is moving {CurrentDirection.ToString().ToLower()} and is now on floor {CurrentFloor}.");
            }

            CurrentDirection = Direction.Stationary;
            IsMoving = false;

            //log message - displays in the console
            logAction?.Invoke($"Elevator has arrived at floor {CurrentFloor}.");

            OpenDoors(Logger.LogToConsoleYellow);
        }

        /// <summary>
        /// Adds a person to the elevator if there is capacity and the doors are open.
        /// </summary>
        /// <returns>True if the person was added, otherwise throws an exception.</returns>

        public bool AddPerson()
        {
            if (NumberOfPeople < Capacity && DoorsOpen)
            {
                NumberOfPeople++;
                return true;
            }

            throw new CapacityExceededException("Elevator is at maximum capacity.");
        }


        /// <summary>
        /// Offloads all people from the elevator at the current floor
        /// </summary>
        /// <param name="logAction">Optional action to log messages.</param>
        public void OffloadPeople(Action<string> logAction = null)
        {
            if (DoorsOpen && NumberOfPeople > 0)
            {
                logAction?.Invoke($"Elevator is offloading {NumberOfPeople} people at floor {CurrentFloor}.");
                NumberOfPeople = 0;
            }

            CloseDoors(Logger.LogToConsoleYellow);
        }

        /// <summary>
        /// Opens the elevator doors
        /// </summary>
        /// <param name="logAction">Optional action to log messages.</param>
        public void OpenDoors(Action<string> logAction = null)
        {
            if (!DoorsOpen)
            {
                logAction?.Invoke("Doors opening.");
                DoorsOpen = true;
            }
        }

        /// <summary>
        /// Closes the elevator doors
        /// </summary>
        /// <param name="logAction">Optional action to log messages.</param>
        public void CloseDoors(Action<string> logAction = null)
        {
            if (DoorsOpen)
            {
                logAction?.Invoke("Doors closing.");
                DoorsOpen = false;
            }
        }
    }
}
