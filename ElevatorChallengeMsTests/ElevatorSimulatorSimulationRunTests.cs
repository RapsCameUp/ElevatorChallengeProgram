using ElevatorChallengeProgram.Interfaces;
using ElevatorChallengeProgram.Presentation;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElevatorChallengeMsTests
{
    [TestClass]
    public class ElevatorSimulatorSimulationRunTests
    {
        /// <summary>
        /// Test method to verify that the similator displays menu correctly.
        /// </summary>
        [TestMethod]
        public void ElevatorSimulator_DisplaysMainMenuCorrectly()
        {
            var controller = new Mock<IElevatorController>();
            var simulator = new ElevatorSimulator(controller.Object);

            using (var sw = new StringWriter())
            {
                Console.SetOut(sw);
                simulator.ShowMainMenu();

                var output = sw.ToString().Trim();
                Assert.IsTrue(output.Contains("Elevator Control System Menu"), "Main menu should be displayed.");
            }
        }
    }
}
