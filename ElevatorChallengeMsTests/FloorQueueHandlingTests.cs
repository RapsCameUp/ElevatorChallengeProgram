using ElevatorChallengeProgram.Controllers;
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
    public class FloorQueueHandlingTests
    {
        private Floor floor;

        [TestInitialize]
        public void Setup()
        {
            floor = new Floor(1);
        }

        /// <summary>
        /// Test method to verify that AddPersonToQueue correctly adds people to the waiting queue on a floor.
        /// </summary>
        [TestMethod]
        public void Floor_AddsPeopleToQueueCorrectly()
        {
            floor.AddPersonToQueue(3);

            Assert.AreEqual(3, floor.GetWaitingPeopleCount(), "Floor should have 3 people waiting.");
        }

        /// <summary>
        /// Test method to ensure that RemovePersonFromQueue correctly removes people from the waiting queue on a floor.
        /// </summary>
        [TestMethod]
        public void Floor_RemovesPeopleFromQueueCorrectly()
        {
            floor.AddPersonToQueue(3);
            floor.RemovePersonFromQueue();

            Assert.AreEqual(2, floor.GetWaitingPeopleCount(), "Floor should have 2 people waiting after removal.");
        }

        /// <summary>
        /// Test method to validate that GetWaitingPeopleCount accurately counts the number of people waiting on a floor.
        /// </summary>
        [TestMethod]
        public void Floor_CountsWaitingPeopleCorrectly()
        {
            floor.AddPersonToQueue(3);

            Assert.AreEqual(3, floor.GetWaitingPeopleCount(), "Floor should count 3 people waiting correctly.");
        }
    }
}
