using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AirportQueues
{
    public class CheckInSimulation
    {
        // Level 1: No counter reallocation
        public int SimulateLevel1(CustomQueue<Passenger> economy, CustomQueue<Passenger> business, int economyCounters, int businessCounters)
        {
            int economyTime = (int)Math.Ceiling((double)economy.Count / economyCounters) * economy.Peek().CheckInTime;
            int businessTime = (int)Math.Ceiling((double)business.Count / businessCounters) * business.Peek().CheckInTime;
            return Math.Max(economyTime, businessTime);
        }

        // Level 2: Business counters can serve economy
        public int SimulateLevel2(CustomQueue<Passenger> economy, CustomQueue<Passenger> business, int economyCounters, int businessCounters)
        {
            int timeElapsed = 0;

            // First phase: both queues active
            while (!business.IsEmpty())
            {
                timeElapsed += business.Peek().CheckInTime;

                // Process business passengers
                for (int i = 0; i < businessCounters; i++)
                    if (!business.IsEmpty()) business.Dequeue();

                // Process economy passengers in parallel
                for (int i = 0; i < economyCounters; i++)
                    if (!economy.IsEmpty()) economy.Dequeue();
            }

            // Second phase: all counters for economy
            economyCounters += businessCounters;
            while (!economy.IsEmpty())
            {
                timeElapsed += economy.Peek().CheckInTime;
                for (int i = 0; i < economyCounters; i++)
                    if (!economy.IsEmpty()) economy.Dequeue();
            }

            return timeElapsed;
        }
    }
}
