using ElevatorChallengeProgram.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElevatorChallengeProgram.Models
{
    public class Floor : IFloor
    {
        public int FloorNumber { get; private set; }

        // Queue to store the number of people waiting on the floor
        public Queue<int> PeopleWaitingQueue { get; private set; }


        // Constructor to initialize the floor with the given floor number
        public Floor(int floorNumber)
        {
            FloorNumber = floorNumber;
            PeopleWaitingQueue = new Queue<int>();
        }

        // Method to add a specified number of people to the waiting queue
        public void AddPersonToQueue(int numberOfPeople)
        {
            for (int i = 0; i < numberOfPeople; i++)
            {
                PeopleWaitingQueue.Enqueue(1); // Each person represented by a value of 1
            }
        }

        // Method to remove one person from the waiting queue
        public void RemovePersonFromQueue()
        {
            if (PeopleWaitingQueue.Any())
            {
                PeopleWaitingQueue.Dequeue();
            }
        }

        // Method to get the count of people currently waiting on the floor
        public int GetWaitingPeopleCount()
        {
            return PeopleWaitingQueue.Count;
        }
    }
}
