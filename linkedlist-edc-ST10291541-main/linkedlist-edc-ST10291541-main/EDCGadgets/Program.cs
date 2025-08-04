using System;
using System.Collections.Generic;


class Program
{
    static void Main()
    {
        CustomLinkedList<Gadget> gadgets = new CustomLinkedList<Gadget>();

        // Add gadgets using Append (to the end)
        gadgets.Append(new Gadget("Smartphone", new List<DayOfWeek> {
            DayOfWeek.Monday, DayOfWeek.Tuesday, DayOfWeek.Wednesday,
            DayOfWeek.Thursday, DayOfWeek.Friday, DayOfWeek.Saturday, DayOfWeek.Sunday
        }));

        gadgets.Append(new Gadget("Laptop", new List<DayOfWeek> {
            DayOfWeek.Monday, DayOfWeek.Tuesday, DayOfWeek.Wednesday,
            DayOfWeek.Thursday, DayOfWeek.Friday
        }));

        gadgets.Append(new Gadget("Gym Bag", new List<DayOfWeek> {
            DayOfWeek.Monday, DayOfWeek.Wednesday, DayOfWeek.Friday
        }));

        // Add to beginning using Prepend
        gadgets.Prepend(new Gadget("Wallet", new List<DayOfWeek> {
            DayOfWeek.Sunday, DayOfWeek.Monday, DayOfWeek.Tuesday,
            DayOfWeek.Wednesday, DayOfWeek.Thursday, DayOfWeek.Friday, DayOfWeek.Saturday
        }));

        Console.WriteLine("All Gadgets:");
        gadgets.Display();

        Console.WriteLine($"\nTotal Count: {gadgets.Count}");

        Console.WriteLine("\nGadgets for Wednesday:");
        gadgets.DisplayByDay(DayOfWeek.Wednesday);

        Console.WriteLine("\nInserting 'Keys' at position 2...");
        gadgets.InsertAt(new Gadget("Keys", new List<DayOfWeek> {
            DayOfWeek.Saturday, DayOfWeek.Sunday
        }), 2);
        gadgets.Display();

        Console.WriteLine("\nRemoving first gadget...");
        gadgets.RemoveFirst();
        gadgets.Display();

        Console.WriteLine("\nRemoving last gadget...");
        gadgets.RemoveLast();
        gadgets.Display();

        Console.WriteLine("\nRemoving 'Laptop' by match...");
        bool removed = gadgets.Remove(g => g.Name == "Laptop");
        Console.WriteLine($"Laptop removed: {removed}");
        gadgets.Display();

        Console.WriteLine("\nReversing List...");
        gadgets.Reverse();
        gadgets.Display();

        Console.WriteLine("\nClearing all gadgets...");
        gadgets.Clear();
        Console.WriteLine($"Count after clear: {gadgets.Count}");
        gadgets.Display();
    }
}
