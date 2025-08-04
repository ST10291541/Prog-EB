public class Gadget
{
    public string Name { get; set; }
    public List<DayOfWeek> CarryDays { get; set; }

    public Gadget(string name, List<DayOfWeek> carryDays)
    {
        Name = name;
        CarryDays = carryDays;
    }

    public override string ToString()
    {
        string days = string.Join(", ", CarryDays);
        return $"{Name} (Carried on: {days})";
    }
}