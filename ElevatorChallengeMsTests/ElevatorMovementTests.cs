using ElevatorChallengeProgram.Enums;
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
    public class ElevatorMovementTests
    {
        private Elevator elevator;

        [TestInitialize]
        public void Setup()
        {
            elevator = new Elevator(10);
        }

        /// <summary>
        /// Test method to verify that the Elevator moves to the correct floor.
        /// </summary>
        [TestMethod]
        public void Elevator_MovesToCorrectFloor()
        {
            elevator.MoveToFloor(5);

            Assert.AreEqual(5, elevator.CurrentFloor, "Elevator should move to floor 5.");
        }

        /// <summary>
        /// Test method to ensure that the Elevator stops at the correct floor and updates its state correctly.
        /// </summary>
        [TestMethod]
        public void Elevator_StopsAtCorrectFloor()
        {
            elevator.MoveToFloor(5);
            Assert.AreEqual(5, elevator.CurrentFloor, "Elevator should stop at floor 5.");
            Assert.AreEqual(Direction.Stationary, elevator.CurrentDirection, "Elevator should be stationary after reaching the floor.");
            Assert.IsFalse(elevator.IsMoving, "Elevator should not be moving after reaching the floor.");
        }
    }
}
