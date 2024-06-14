using ElevatorChallengeProgram.Controllers;
using ElevatorChallengeProgram.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElevatorChallengeMsTests
{
    [TestClass]
    public class ElevatorServiceSettingPeopleWaitingTests
    {
        private ElevatorService service;

        [TestInitialize]
        public void Setup()
        {
            service = new ElevatorService(3, 10, 5);
        }

        /// <summary>
        /// Test method to verify that SetNumberOfPeopleWaiting correctly sets the number of people waiting on a specified floor.
        /// </summary>
        [TestMethod]
        public void ElevatorService_SetsPeopleWaitingCorrectly()
        {
            service.SetNumberOfPeopleWaiting(1, 3);

            Assert.AreEqual(3, service.Floors[0].GetWaitingPeopleCount(), "Floor 1 should have 3 people waiting.");
        }

        /// <summary>
        /// Test method to ensure that ElevatorService throws an exception when attempting to set a negative number of people waiting.
        /// </summary>
        [TestMethod]
        public void ElevatorService_ThrowsExceptionWhenSettingNegativePeople()
        {
            var ex = Assert.ThrowsException<ArgumentOutOfRangeException>(() => service.SetNumberOfPeopleWaiting(1, -1));

            Assert.AreEqual("Number of people waiting cannot be negative. (Parameter 'numberOfPeopleWaiting')", ex.Message, "Exception should be thrown when setting a negative number of people.");
        }

        /// <summary>
        /// Test method to validate that SetNumberOfPeopleWaiting throws an exception when given an invalid floor number.
        /// </summary>
        [TestMethod]
        public void SetNumberOfPeopleWaiting_InvalidFloorNumber()
        {
            Assert.ThrowsException<ArgumentOutOfRangeException>(() => service.SetNumberOfPeopleWaiting(11, 1), "Invalid floor number should throw an exception.");
        }
    }
}
