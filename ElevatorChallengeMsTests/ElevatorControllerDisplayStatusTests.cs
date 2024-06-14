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
    public class ElevatorControllerDisplayStatusTests
    {
        private ElevatorService service;
        private ElevatorController controller; 

        [TestInitialize]
        public void Setup()
        {
            service = new ElevatorService(3, 10, 5);
            controller = new ElevatorController(service);
        }


        /// <summary>
        /// Test method to verify if the elevator status is displayed correctly.
        /// </summary>
        [TestMethod]
        public void ElevatorController_DisplaysElevatorStatusCorrectly()
        {
            using (var sw = new StringWriter())
            {
                Console.SetOut(sw);
                controller.DisplayElevatorStatus();

                var output = sw.ToString().Trim();
                Assert.IsTrue(output.Contains("Elevator Status:"), "Elevator status should be displayed.");
            }
        }

        /// <summary>
        /// Test method to verify if the floor status is displayed correctly.
        /// </summary>
        [TestMethod]
        public void ElevatorController_DisplaysFloorStatusCorrectly()
        {
            using (var sw = new StringWriter())
            {
                Console.SetOut(sw);
                controller.DisplayFloorStatus();

                var output = sw.ToString().Trim();
                Assert.IsTrue(output.Contains("Floor Status:"), "Floor status should be displayed.");
            }
        }
    }

}
