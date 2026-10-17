using System;
using System.Reflection;
using System.Collections.Generic;


class Program
{
    static void Main()
    {
        Assembly asembly = Assembly.GetExecutingAssembly();

        Type[] allTypes = asembly.GetTypes();
        List<Type> classes= new List<Type>();
        int n = 0;
        foreach (var type in allTypes)
        {

            if (type.IsClass && !type.Name.Contains("<") && typeof(Ihomework).IsAssignableFrom(type))
            {
                n++;
                classes.Add(type);
            }
        }
        while (true)
        {
            Console.WriteLine("---My C# Homeworks---");
            for (int i =0; i < classes.Count; i++)
            {
                Console.WriteLine($"{i+1}. {classes[i].Name}");
            }
            Console.WriteLine($"{n + 1}. Exit");

            Console.WriteLine("Enter choice---");
            int choice;
            while (!Int32.TryParse(Console.ReadLine(), out choice) || choice < 1 || choice > (n+1))
            {
                Console.WriteLine("Please enter valid choice...");
            }
            if (choice == n+1)
            {
                Console.WriteLine("Exiting...");
                return;
            }
            Console.WriteLine($"\n--- Running {classes[choice - 1].Name} ---");
            var homework = (Ihomework)Activator.CreateInstance(classes[choice - 1]);
            homework.Run();
        }
    }
}
