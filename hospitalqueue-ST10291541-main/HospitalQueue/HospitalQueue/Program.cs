namespace HospitalQueue
{
    public class Program
    {
        static void Main(string[] args)
        {
            PriorityQueue<Patient> erQueue = new PriorityQueue<Patient>();

            // Add patients (name, severity)
            erQueue.Enqueue(new Patient("John Doe", 2), 2);
            erQueue.Enqueue(new Patient("Jane Smith", 5), 5);
            erQueue.Enqueue(new Patient("Mike Johnson", 1), 1);
            erQueue.Enqueue(new Patient("Emily Davis", 4), 4);

            Console.WriteLine("Treating patients in order of severity:\n");

            while (!erQueue.IsEmpty())
            {
                Patient nextPatient = erQueue.Dequeue();
                Console.WriteLine($"Now treating: {nextPatient}");
            }
        }
    }
}
