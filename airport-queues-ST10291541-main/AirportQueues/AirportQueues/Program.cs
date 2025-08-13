namespace AirportQueues
{
    public class Program
    {
        static void Main(string[] args)
        {
            // Simulation parameters
            int economyPassengers = 100;
            int businessPassengers = 20;
            int economyCounters = 5;
            int businessCounters = 5;
            int economyTimePerPassenger = 10;
            int businessTimePerPassenger = 7;

            // Create passenger queues
            var economyQueue = new CustomQueue<Passenger>();
            var businessQueue = new CustomQueue<Passenger>();

            for (int i = 1; i <= economyPassengers; i++)
                economyQueue.Enqueue(new Passenger($"Economy Passenger {i}", "Economy", economyTimePerPassenger));

            for (int i = 1; i <= businessPassengers; i++)
                businessQueue.Enqueue(new Passenger($"Business Passenger {i}", "Business", businessTimePerPassenger));

            // Create simulation instance
            var simulation = new CheckInSimulation();

            // Level 1
            int level1Time = simulation.SimulateLevel1(economyQueue.Clone(), businessQueue.Clone(), economyCounters, businessCounters);
            Console.WriteLine($"Level 1 Total Time: {level1Time} minutes");

            // Level 2
            int level2Time = simulation.SimulateLevel2(economyQueue.Clone(), businessQueue.Clone(), economyCounters, businessCounters);
            Console.WriteLine($"Level 2 Total Time: {level2Time} minutes");
        }
    }
}
