using ElevatorChallengeProgram.CustomExceptions;
using ElevatorChallengeProgram.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElevatorChallengeMsTests
{
    [TestClass]
    public class ElevatorLoadHandlingTests
    {
        /// <summary>
        /// Test method to verify that the Elevator correctly adds people.
        /// </summary>
        /// 
        [TestMethod]
        public void Elevator_AddsPeopleCorrectly()
        {
            var elevator = new Elevator(10);
            elevator.OpenDoors();
            Assert.IsTrue(elevator.AddPerson(), "Person should be added successfully.");
            Assert.AreEqual(1, elevator.NumberOfPeople, "Elevator should have 1 person.");
        }

        /// <summary>
        /// Test method to ensure that an exception is thrown when adding people beyond the elevator's capacity.
        /// </summary>
        [TestMethod]
        public void Elevator_ThrowsExceptionWhenOverCapacity()
        {
            var elevator = new Elevator(1);
            elevator.OpenDoors();
            elevator.AddPerson();
            Assert.ThrowsException<CapacityExceededException>(() => elevator.AddPerson(), "Adding person beyond capacity should throw an exception.");
        }

        /// <summary>
        /// Test method to verify that the Elevator correctly offloads people.
        /// </summary>
        [TestMethod]
        public void Elevator_OffloadsPeopleCorrectly()
        {
            var elevator = new Elevator(10);
            elevator.OpenDoors();
            elevator.AddPerson();
            elevator.OpenDoors();
            elevator.OffloadPeople();

            Assert.AreEqual(0, elevator.NumberOfPeople, "Elevator should have no people after offloading.");
        }
    }
}
