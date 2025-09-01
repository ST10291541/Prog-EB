namespace FractionCalculator
{
    public class Program
    {
        static void Main(string[] args)
        {
            Fraction f1 = new Fraction(1, 2);  // 1/2
            Fraction f2 = new Fraction(3, 4);  // 3/4

            Console.WriteLine($"f1 = {f1}");
            Console.WriteLine($"f2 = {f2}");

            Console.WriteLine("\n--- Arithmetic Operations ---");
            Console.WriteLine($"f1 + f2 = {f1 + f2}");
            Console.WriteLine($"f1 - f2 = {f1 - f2}");
            Console.WriteLine($"f1 * f2 = {f1 * f2}");
            Console.WriteLine($"f1 / f2 = {f1 / f2}");
            Console.WriteLine($"++f1 = {++f1}");
            Console.WriteLine($"--f2 = {--f2}");

            Console.WriteLine("\n--- Comparisons ---");
            Console.WriteLine($"f1 == f2 ? {f1 == f2}");
            Console.WriteLine($"f1 != f2 ? {f1 != f2}");
            Console.WriteLine($"f1 < f2 ? {f1 < f2}");
            Console.WriteLine($"f1 > f2 ? {f1 > f2}");
        }
    }
}
