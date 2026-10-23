using System;

namespace IntStack
{
    public class IntStack
    {
        private int[] array;
        public int Count { get; private set; }
        private int capacity;
        public IntStack(int capacity = 4)
        {
            this.array = new int[capacity];
            this.Count = 0;
            this.capacity = capacity;
        }
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
        public void Push(int value)
        {
            if (this.Count == this.capacity)
            {
                Resize();
            }
            this.array[this.Count] = value;
            this.Count++;
        }

        public int Pop()
        {
            if (this.Count == 0)
            {
                throw new InvalidOperationException("Stack is empty");
            }
            int value = this.array[this.Count - 1];
            this.Count--;
            return value;
        }

        public int Peek()
        {
            if (this.Count == 0)
            {
                throw new InvalidOperationException("Stack is empty");
            }
            int value = this.array[this.Count - 1];
            return value;
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            IntStack stack = new IntStack();
            stack.Push(1);
            stack.Push(2);
            stack.Push(3);
            Console.WriteLine(stack.Peek());
            Console.WriteLine(stack.Pop());
            Console.WriteLine(stack.Peek());
            Console.WriteLine(stack.Pop());
            Console.WriteLine(stack.Pop());
        }
    }
}
