using ElevatorChallengeProgram.CustomExceptions;
using ElevatorChallengeProgram.Interfaces;
using ElevatorChallengeProgram.Models;
using ElevatorChallengeProgram.Utilities;

namespace ElevatorChallengeProgram.Controllers
{
    /// <summary>
    /// The ElevatorController class handles the operations related to elevator management,
    /// such as calling elevators and setting the number of people waiting on a floor.
    /// It interacts with the elevator service to perform these operations.
    /// </summary>
    public class ElevatorController : IElevatorController
    {
        private readonly IElevatorService _elevatorService;

        public ElevatorController(IElevatorService elevatorService)
        {
            _elevatorService = elevatorService;
        }


        // Gets the list of floors from the elevator service.
        public List<Floor> Floors => _elevatorService.Floors;

        // Gets the list of elevators from the elevator service.
        public List<Elevator> Elevators => _elevatorService.GetElevators();

        /// <summary>
        /// Calls an elevator to the specified floor.
        /// </summary>
        /// <param name="floorNumber">The floor number where the elevator is called.</param>
        public void CallElevator(int floorNumber)
        {
            try
            {
                _elevatorService.CallElevator(floorNumber);
            }
            catch (Exception ex) when (ex is InvalidFloorException
                                           || ex is CapacityExceededException
                                           || ex is ArgumentOutOfRangeException
                                           || ex is InvalidOperationException
                                           || ex is ArgumentException)
            {
                Logger.LogToConsoleRed(ex.Message);
            }
            catch (Exception ex)
            {
                Logger.LogToConsoleRed($"Unexpected error: {ex.Message}");
            }
        }

        /// <summary>
        /// Sets the number of people waiting on the specified floor.
        /// </summary>
        /// <param name="floorNumber">The floor number where people are waiting.</param>
        /// <param name="numberOfPeopleWaiting">The number of people waiting on the floor.</param>

        public void SetNumberOfPeopleWaiting(int floorNumber, int numberOfPeopleWaiting)
        {
            try
            {
                _elevatorService.SetNumberOfPeopleWaiting(floorNumber, numberOfPeopleWaiting);
            }
            catch (Exception ex) when (ex is InvalidFloorException
                                                       || ex is CapacityExceededException
                                                       || ex is ArgumentOutOfRangeException
                                                       || ex is InvalidOperationException
                                                       || ex is ArgumentException)
            {
                Logger.LogToConsoleRed(ex.Message);
            }
            catch (Exception ex)
            {
                Logger.LogToConsoleRed($"Unexpected error: {ex.Message}");
            }
        }

        /// <summary>
        /// Displays the status of all elevators.
        /// </summary>

        public void DisplayElevatorStatus()
        {
            Console.WriteLine("Elevator Status:");

            foreach (var elevator in Elevators)
            {
                int index = _elevatorService.GetElevatorIndex(elevator) + 1;
                Logger.LogToConsole($"Elevator {index}: Floor {elevator.CurrentFloor}, Direction: {elevator.CurrentDirection}, In Motion: {elevator.IsMoving}, Passengers: {elevator.NumberOfPeople}");
            }

            Logger.LogToConsole(string.Empty); // Log an empty line for spacing
        }

        /// <summary>
        /// Displays the status of all floors.
        /// </summary>
        public void DisplayFloorStatus()
        {
            Logger.LogToConsole("Floor Status:");

            foreach (var floor in Floors)
            {
                Logger.LogToConsole($"Floor {floor.FloorNumber}: People waiting: {floor.GetWaitingPeopleCount()}");
            }

            Logger.LogToConsole(string.Empty); // Log an empty line for spacing
        }
    }
}
