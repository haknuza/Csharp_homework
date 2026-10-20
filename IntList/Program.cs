using System;

namespace IntList
{
    class IntList
    {
        public int[] Items;
        private int count;
        private int capacity;

        public int Count
        {
            get { return count; }
        }

        public IntList(int capacity = 4, int[]? items = null)
        {
            if (items == null)
            {
                this.Items = new int[capacity];
                count = 0;
                this.capacity = capacity;
            }
            else
            {
                this.Items = items;
                count = this.Items.Length;
                this.capacity = Math.Max(count, capacity);
            }
        }
        private void Resize()
        {
            capacity *= 2;
            int[] temp = this.Items;
            this.Items = new int[capacity];
            for (int i = 0; i < count; i++)
            {
                this.Items[i] = temp[i];
            }
        }
        public void Add(int item)
        {
            while (count >= capacity)
            {
                Resize();
            }
            Items[count++] = item;
        }
        public void Insert(int item, int index)
        {
            if (index < 0)
            {
                return;
            }

            if (index < capacity)
            {
                if (count+1 >= capacity)
                {
                    Resize();
                }
                for (int i = count; i > index; i--)
                {
                    this.Items[i] = this.Items[i - 1];
                }
                this.Items[index] = item;
                count++;
                return;
            }
            while (index >= count)
            {
                Resize();
            }
            this.Items[index] = item;
            count = index + 1;
        }
        public void RemoveAt(int index)
        {
            if (index < 0 || index >= count)
            {
                return;
            }
            for (int i = index; i < count - 1; i++)
            {
                this.Items[i] = this.Items[i + 1];
            }
            count--;
        }
        public int Get(int index)
        {
            if (index < 0 || index >= count)
            {
                return -1;
            }
            return this.Items[index];
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            var list = new IntList();

            list.Add(4);
            list.Add(8);
            list.Add(15);
            Console.WriteLine($"Count: {list.Count}");
            Console.WriteLine($"Get(0): {list.Get(0)}");
            Console.WriteLine($"Get(2): {list.Get(2)}");

            list.Insert(6, 1);
            Console.WriteLine($"Get(1): {list.Get(1)}");
            Console.WriteLine($"Count: {list.Count}");
            list.Insert(1, 0);
            Console.WriteLine($"Get(0): {list.Get(0)}");
            Console.WriteLine($"Count: {list.Count}");
            list.Insert(9, 5);
            Console.WriteLine($"Get(5): {list.Get(5)}");
            Console.WriteLine($"Count: {list.Count}");
            list.RemoveAt(2);
            Console.WriteLine($"Get(2): {list.Get(2)}");
            Console.WriteLine($"Count: {list.Count}");
            list.RemoveAt(0);
            Console.WriteLine($"Get(0): {list.Get(0)}");
            Console.WriteLine($"Count: {list.Count}");


        }
    }
}
