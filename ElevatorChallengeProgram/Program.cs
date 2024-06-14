using ElevatorChallengeProgram.Controllers;
using ElevatorChallengeProgram;
using ElevatorChallengeProgram.Presentation;
using ElevatorChallengeProgram.CustomExceptions;
using ElevatorChallengeProgram.Utilities;
using ElevatorChallengeProgram.Interfaces;
using Microsoft.Extensions.DependencyInjection;
using ElevatorChallengeProgram.Services;

try
{
    // Create a service provider to manage dependency injection
    // initialize number of elevators, floors, default capacity
    var serviceProvider = new ServiceCollection()
                  .AddSingleton<IElevatorService>(provider => new ElevatorService(ElevatorConstants.DEFAULT_NUMBER_OF_ELEVATORS, 
                  ElevatorConstants.DEFAULT_NUMBER_OF_FLOORS, ElevatorConstants.DEFAULT_ELEVATOR_CAPACITY)) // initialize number of elevators, floors, default capacity
                  .AddSingleton<IElevatorController, ElevatorController>()
                  .BuildServiceProvider();

    var elevatorController = serviceProvider.GetService<IElevatorController>();
    var elevatorSimulator = new ElevatorSimulator(elevatorController);

    // Start the elevator simulator
    elevatorSimulator.Run();
}
catch (Exception ex)
{
    // Log any exceptions that occur during execution
    Logger.LogToConsoleRed($"Error: {ex.Message}");
}