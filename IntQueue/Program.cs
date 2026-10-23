using System;

public class IntQueue
{
    private int[] array;
    private int pointer;
    public int Count { get; private set; }
    private int capacity;

    private void Resize()
    {
        capacity *= 2;
        int[] temp = this.array;
        this.array = new int[capacity];
        for (int i = 0; i < this.Count; i++)
        {
            this.array[i] = temp[i];
        }
    }
    public IntQueue(int capacity = 4)
    {
        this.array = new int[capacity];
        this.pointer = 0;
        this.Count = 0;
        this.capacity = capacity;
    }
    public void Enqueue(int value)
    {
        if (this.Count == this.capacity)
        {
            Resize();
        }
        this.array[this.Count++] = value;
    }

    public int Dequeue()
    {
        if (this.Count == 0 || this.pointer == this.Count)
        {
            throw new InvalidOperationException("Queue is empty");
        }
        int value = this.array[this.pointer];
        this.pointer++;
        this.Count--;
        return value;
    }
}

namespace intQueue
{
    class Program
    {
        static void Main(string[] args)
        {
            var queue = new IntQueue();
            queue.Enqueue(1);
            queue.Enqueue(2);
            queue.Enqueue(34);
            queue.Enqueue(43);
            queue.Enqueue(6);
            Console.WriteLine(queue.Dequeue());
            Console.WriteLine(queue.Dequeue());

            Console.WriteLine(queue.Dequeue());
            Console.WriteLine(queue.Dequeue());
            Console.WriteLine(queue.Dequeue());
        }
    }
}
