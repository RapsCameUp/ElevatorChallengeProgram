using ElevatorChallengeProgram.Enums;
using ElevatorChallengeProgram.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElevatorChallengeMsTests
{
    [TestClass]
    public class ElevatorInitializationTests
    {

        /// <summary>
        /// Test method to verify that an Elevator instance initializes with the correct default values.
        /// </summary>
        [TestMethod]
        public void Elevator_InitializesWithCorrectValues()
        {
            var elevator = new Elevator(10);

            Assert.AreEqual(1, elevator.CurrentFloor, "Elevator should initialize at floor 1.");
            Assert.IsFalse(elevator.IsMoving, "Elevator should not be moving initially.");
            Assert.AreEqual(Direction.Stationary, elevator.CurrentDirection, "Elevator should initialize with direction stationary.");
            Assert.AreEqual(10, elevator.Capacity, "Elevator should initialize with given capacity.");
            Assert.AreEqual(0, elevator.NumberOfPeople, "Elevator should initialize with no people.");
            Assert.IsFalse(elevator.DoorsOpen, "Elevator doors should be closed initially.");
        }
    }

}
