using ElevatorChallengeProgram.Controllers;
using ElevatorChallengeProgram.Interfaces;
using ElevatorChallengeProgram.Models;
using ElevatorChallengeProgram.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElevatorChallengeMsTests
{
    [TestClass]
    public class ElevatorServiceCallingElevatorTests
    {
        private ElevatorService service;

        [TestInitialize]
        public void Setup()
        {
            service = new ElevatorService(3, 10, 5);
        }

        /// <summary>
        /// Test method to verify that FindNearestAvailableElevator returns the nearest available elevator when no elevators are moving.
        /// </summary>
        [TestMethod]
        public void FindNearestAvailableElevator_ElevatorsNotMoving_ReturnsNearestAvailableElevator()
        {
            // Set some people waiting on floor 3
            service.SetNumberOfPeopleWaiting(3, 2);

            // Act
            Elevator nearestElevator = service.FindNearestAvailableElevator(3);

            // Check that the nearest available elevator is returned (elevator 1, as all elevators start at floor 1)
            var elevator = service.GetElevators().First();
            Assert.AreEqual(elevator, nearestElevator);
        }

        /// <summary>
        /// Test method to ensure that ElevatorService logs an error when attempting to call an elevator to a floor where no one is waiting.
        /// </summary>
        [TestMethod]
        public void ElevatorService_LogsErrorWhenNoOneIsWaiting()
        {
            var ex = Assert.ThrowsException<InvalidOperationException>(() => service.CallElevator(4));

            Assert.AreEqual("No one is waiting on Floor 4. Please set the number of people waiting first.", ex.Message, "Error message should be logged when no one is waiting.");
        }
    }
}
