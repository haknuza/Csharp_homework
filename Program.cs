using System;
using System.Reflection;
using System.Collections.Generic;


class Program
{
    static void Main()
    {
        Console.WriteLine("---My C# Homeworks---");
        Assembly asembly = Assembly.GetExecutingAssembly();

        Type[] allTypes = asembly.GetTypes();
        List<Type> classes= new List<Type>();

        while (true)
        {
            int n = 0; 
            foreach (var type in allTypes)
            {
            
                if (type.IsClass && !type.Name.Contains("<") && typeof(Ihomework).IsAssignableFrom(type))
                {
                    n++;
                    classes.Add(type);
                    Console.WriteLine($"{n}.{type.FullName}");
                }
            }
            Console.WriteLine($"{n+1}.Exit");
            int choice;
            while (!Int32.TryParse(Console.ReadLine(), out choice))
            {
                Console.WriteLine("Please enter valid choice...");
            }
            if (choice == n+1)
            {
                return;
            }
            var homework = (Ihomework)Activator.CreateInstance(classes[choice - 1]);
            homework.Run();
        }   
    }
}