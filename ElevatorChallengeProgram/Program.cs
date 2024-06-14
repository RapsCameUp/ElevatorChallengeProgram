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
    var serviceProvider = new ServiceCollection()
                  .AddSingleton<IElevatorService>(provider => new ElevatorService(3, 10, 5))
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