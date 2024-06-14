using ElevatorChallengeProgram.Interfaces;
using ElevatorChallengeProgram.Models;
using ElevatorChallengeProgram.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElevatorChallengeProgram.Services
{
    public class ElevatorService : IElevatorService
    {
        private readonly List<Elevator> allElevators;

        public List<Floor> Floors { get; private set; }

        public ElevatorService(int numberOfElevators, int numberOfFloors, int elevatorCapacity)
        {
            // Validate that the number of elevators, floors, and capacity are greater than zero
            if (numberOfElevators <= 0 || numberOfFloors <= 0 || elevatorCapacity <= 0)
            {
                throw new ArgumentException("Number of elevators, floors, and capacity must be greater than zero.");
            }

            // Initialize the list of elevators
            allElevators = new List<Elevator>();
            for (int i = 0; i < numberOfElevators; i++)
            {
                allElevators.Add(new Elevator(elevatorCapacity));
            }

            // Initialize the list of floors
            Floors = Enumerable.Range(1, numberOfFloors).Select(floorNumber => new Floor(floorNumber)).ToList();
        }


        // Get the list of all elevators
        public List<Elevator> GetElevators() => allElevators;

        // Call an elevator to a specific floor
        public void CallElevator(int floorNumber)
        {
            Floor floor = Floors[floorNumber - 1];

            // Check if there are people waiting on the floor
            if (floor.GetWaitingPeopleCount() == 0)
            {
                throw new InvalidOperationException($"No one is waiting on Floor {floorNumber}. Please set the number of people waiting first.");
            }

            // Find the nearest available elevator
            Elevator nearestAvailableElevator = FindNearestAvailableElevator(floorNumber);
            if (nearestAvailableElevator == null)
            {
                Logger.LogToConsoleRed("All elevators are currently busy or at maximum capacity. Please wait.");
                return;
            }

            // Move the elevator to the specified floor
            nearestAvailableElevator.MoveToFloor(floorNumber, Logger.LogToConsoleGreen);

            // Load people into the elevator
            int capacity = 0;
            while (floor.GetWaitingPeopleCount() > 0 && nearestAvailableElevator.NumberOfPeople < nearestAvailableElevator.Capacity)
            {
                if (nearestAvailableElevator.AddPerson())
                {
                    floor.RemovePersonFromQueue();
                    capacity++;
                }
                else
                {
                    Logger.LogToConsoleRed("Elevator is at maximum capacity. Cannot add more people.");
                    break;
                }
            }

            // Log the number of people picked up
            if (capacity > 0)
            {
                Logger.LogToConsoleGreen($"Elevator {GetElevatorIndex(nearestAvailableElevator) + 1} picked up {capacity} people from Floor {floorNumber}.");
            }

            // Prompt for a valid destination floor
            int destinationFloor;
            bool validInput = false;

            do
            {
                if (TryGetValidDestinationFloor(out destinationFloor))
                {
                    nearestAvailableElevator.MoveToFloor(destinationFloor, Logger.LogToConsoleGreen);
                    nearestAvailableElevator.OffloadPeople(Logger.LogToConsoleYellow);
                    validInput = true;
                }
            } while (!validInput);
        }

        public void SetNumberOfPeopleWaiting(int floorNumber, int numberOfPeopleWaiting)
        {
            // Validate that the number of people waiting is not negative
            if (numberOfPeopleWaiting < 0)
            {
                throw new ArgumentOutOfRangeException(nameof(numberOfPeopleWaiting), "Number of people waiting cannot be negative.");
            }

            // Add the specified number of people to the queue on the specified floor
            Floors[floorNumber - 1].AddPersonToQueue(numberOfPeopleWaiting);
        }

        // Get the index of a specific elevator in the list
        public int GetElevatorIndex(Elevator elevator) => allElevators.IndexOf(elevator);


        // Find the nearest available elevator to the specified floor
        public Elevator FindNearestAvailableElevator(int floorNumber)
        {
            return allElevators
                .Where(elevator => !elevator.IsMoving && elevator.NumberOfPeople < elevator.Capacity)
                .OrderBy(elevator => Math.Abs(elevator.CurrentFloor - floorNumber))
                .FirstOrDefault();
        }

        // Try to get a valid destination floor from the user input
        private bool TryGetValidDestinationFloor(out int destinationFloor)
        {
            Console.Write("Enter the destination floor: ");
            if (int.TryParse(Console.ReadLine(), out destinationFloor) && destinationFloor >= 1 && destinationFloor <= Floors.Count)
            {
                return true;
            }

            // Log an error message if the input is invalid
            Logger.LogToConsoleRed($"Invalid floor number. Floor number must be within the valid range {ElevatorConstants.MINFLOOR} - {Floors.Count}. Please try again.");
            return false;
        }
    }
}
