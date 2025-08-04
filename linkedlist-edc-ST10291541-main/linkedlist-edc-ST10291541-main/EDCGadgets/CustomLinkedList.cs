public class CustomLinkedList<T>
{
    private Node<T> head;
    public int Count { get; private set; }

    public CustomLinkedList()
    {
        head = null;
        Count = 0;
    }

    public void Append(T item)
    {
        var newNode = new Node<T>(item);
        if (head == null)
        {
            head = newNode;
        }
        else
        {
            var current = head;
            while (current.Next != null)
                current = current.Next;
            current.Next = newNode;
        }
        Count++;
    }

    public void Prepend(T item)
    {
        var newNode = new Node<T>(item)
        {
            Next = head
        };
        head = newNode;
        Count++;
    }

    public void InsertAt(T item, int position)
    {
        if (position < 0 || position > Count)
            throw new ArgumentOutOfRangeException(nameof(position), "Position out of range");

        if (position == 0)
        {
            Prepend(item);
        }
        else if (position == Count)
        {
            Append(item);
        }
        else
        {
            var newNode = new Node<T>(item);
            var current = head;
            for (int i = 0; i < position - 1; i++)
                current = current.Next;

            newNode.Next = current.Next;
            current.Next = newNode;
            Count++;
        }
    }

    public bool RemoveFirst()
    {
        if (head == null) return false;

        head = head.Next;
        Count--;
        return true;
    }

    public bool RemoveLast()
    {
        if (head == null) return false;

        if (head.Next == null)
        {
            head = null;
        }
        else
        {
            var current = head;
            while (current.Next.Next != null)
                current = current.Next;
            current.Next = null;
        }

        Count--;
        return true;
    }

    public bool Remove(Predicate<T> match)
    {
        if (head == null) return false;

        if (match(head.Data))
        {
            head = head.Next;
            Count--;
            return true;
        }

        var current = head;
        while (current.Next != null && !match(current.Next.Data))
            current = current.Next;

        if (current.Next != null)
        {
            current.Next = current.Next.Next;
            Count--;
            return true;
        }

        return false;
    }

    public T Find(Predicate<T> match)
    {
        var current = head;
        while (current != null)
        {
            if (match(current.Data))
                return current.Data;
            current = current.Next;
        }
        return default;
    }


    public void Reverse()
    {
        Node<T> prev = null, current = head, next = null;
        while (current != null)
        {
            next = current.Next;
            current.Next = prev;
            prev = current;
            current = next;
        }
        head = prev;
    }

    public void Clear()
    {
        head = null;
        Count = 0;
    }

    public void Display()
    {
        var current = head;
        if (current == null)
        {
            Console.WriteLine("List is empty.");
            return;
        }

        while (current != null)
        {
            Console.WriteLine(current.Data);
            current = current.Next;
        }
    }

    public void DisplayByDay(DayOfWeek day)
    {
        var current = head;
        bool found = false;

        Console.WriteLine($"Gadgets carried on {day}:");
        while (current != null)
        {
            if (current.Data is Gadget gadget && gadget.CarryDays.Contains(day))
            {
                Console.WriteLine(gadget);
                found = true;
            }
            current = current.Next;
        }

        if (!found)
            Console.WriteLine("No gadgets for this day.");
    }
}
