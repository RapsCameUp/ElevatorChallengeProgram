using ElevatorChallengeProgram.CustomExceptions;
using ElevatorChallengeProgram.Interfaces;
using ElevatorChallengeProgram.Models;
using ElevatorChallengeProgram.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElevatorChallengeProgram.Presentation
{
    /// <summary>
    /// The ElevatorSimulator class simulates the operation of an elevator system.
    /// It interacts with the user to control the elevators and display their status.
    /// </summary>
    public class ElevatorSimulator
    {
        private readonly IElevatorController elevatorController;
        private bool runSimulation = true;

        public ElevatorSimulator(IElevatorController elevatorController)
        {
            this.elevatorController = elevatorController;
        }

        /// <summary>
        /// Runs the elevator simulation.
        /// Continuously displays the status of elevators and floors and handles user input.
        /// </summary>
        public void Run()
        {
            while (runSimulation)
            {
                Console.WriteLine();

                // Show the status of elevators and floors
                elevatorController.DisplayElevatorStatus();
                elevatorController.DisplayFloorStatus();

                // Display the main menu and handle user input
                ShowMainMenu();
                var key = Console.ReadKey(true).Key;
                HandleUserInput(key);
            }
        }

        /// <summary>
        /// Displays the main menu options for the elevator control system.
        /// </summary>
        public void ShowMainMenu()
        {
            Console.WriteLine("Elevator Control System Menu");
            Console.WriteLine("1. Call Elevator");
            Console.WriteLine("2. Set the number of people waiting on a floor.");
            Console.WriteLine("3. Quit the application");
            Console.Write("Select an option: ");
            Console.WriteLine();
        }


        /// <summary>
        /// Handles the user input based on the selected menu option.
        /// </summary>
        /// <param name="key">The console key pressed by the user.</param>
        private void HandleUserInput(ConsoleKey key)
        {
            switch (key)
            {
                case ConsoleKey.D1:
                case ConsoleKey.NumPad1:
                    CallElevator();
                    break;

                case ConsoleKey.D2:
                case ConsoleKey.NumPad2:
                    SetPeopleWaiting();
                    break;

                case ConsoleKey.D3:
                case ConsoleKey.NumPad3:
                    runSimulation = false;
                    break;

                default:
                    Console.Clear();
                    Logger.LogToConsoleRed("Invalid option. Please select a valid option from the menu.");
                    break;
            }
        }

        /// <summary>
        /// Prompts the user to enter a floor number and calls the elevator to that floor.
        /// </summary>
        private void CallElevator()
        {
            int floorNumber;
            bool validInput = false;

            do
            {
                Console.Write("Enter the floor number to call the elevator: ");
                if (int.TryParse(Console.ReadLine(), out floorNumber) && floorNumber >= 1 && floorNumber <= elevatorController.Floors.Count)
                {
                    Console.Clear();
                    elevatorController.CallElevator(floorNumber);
                    validInput = true;
                }
                else
                {
                    Console.Clear();
                    Logger.LogToConsoleRed($"Invalid floor number. Floor number must be within the valid range {ElevatorConstants.MINFLOOR} - {elevatorController.Floors.Count}. Please try again.");
                }

            } while (!validInput);
        }

        /// <summary>
        /// Prompts the user to enter a floor number and sets the number of people waiting on that floor.
        /// </summary>
        private void SetPeopleWaiting()
        {
            int floorNumber;
            bool validInput = false;

            do
            {
                Console.Write("Enter the floor number to set the number of people waiting: ");
                if (int.TryParse(Console.ReadLine(), out floorNumber) && floorNumber >= 1 && floorNumber <= elevatorController.Floors.Count)
                {
                    Console.Write("Enter the number of people waiting: ");
                    if (int.TryParse(Console.ReadLine(), out int numberOfPeopleWaiting) && numberOfPeopleWaiting >= 0)
                    {
                        elevatorController.SetNumberOfPeopleWaiting(floorNumber, numberOfPeopleWaiting);
                        validInput = true;
                        Console.Clear(); // Clear the console to show updated status

                        Logger.LogToConsoleGreen($"Number of people waiting successfully set for floor: {floorNumber}");
                    }
                    else
                    {
                        Console.Clear();
                        Logger.LogToConsoleRed("Invalid number of people. Please try again.");
                    }
                }
                else
                {
                    Console.Clear();
                    Logger.LogToConsoleRed($"Invalid floor number. Floor number must be within the valid range {ElevatorConstants.MINFLOOR} - {elevatorController.Floors.Count}. Please try again.");
                }
            } while (!validInput);
        }
    }
}