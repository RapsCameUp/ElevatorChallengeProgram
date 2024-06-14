#Elevator Challenge Program

The Elevator Challenge program is a console application in C# that simulates the movement of elevators, aiming to move people as efficiently as possible. It utilizes Object-Oriented Programming (OOP) principles to manage multiple elevators, multiple floors, and user interactions.

Features:

* Elevator Status: The program displays the status of each elevator, including its current floor, movement direction, and the number of people it is carrying.

* Floor Status: The program also shows the status of each floor, including the number of people waiting on that floor.

* Interacting with Elevators: Users can interact with the elevators in two ways:

* Call an Elevator: Users can call an elevator to a specific floor. The program automatically sends the nearest available elevator to the requested floor.
Set the Number of People Waiting: Users can set the number of people waiting on a specific floor. This helps simulate people waiting for elevators.
Weight Limit: Each elevator has a weight limit expressed as the number of people it can carry. The program ensures that elevators do not exceed their capacity.

#Usage

Users can run the console application and interact with the elevators by calling them to specific floors and setting the number of people waiting on each floor. The program efficiently manages elevator movement and passenger pickup based on proximity and capacity.

Build the Project: dotnet build
Run the Tests: dotnet test (This will execute all MSTests and verify the functionality of the elevator simulation.)
Run the Simulation Program: dotnet run --project ElevatorChallengeProgram

#Project Structure
Controllers: Contains classes that control elevator operations.
Models: Defines the core models used in the program, such as Elevator and Floor.
Services: Includes the main service (ElevatorService) responsible for coordinating elevator actions.
Utilities: Utility classes for logging and other helper functions.
MsTests: Contains MSTest unit tests to verify the functionality of the elevator simulation program.