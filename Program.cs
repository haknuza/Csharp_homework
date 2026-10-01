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

        int n = 1;
        foreach (var type in allTypes)
        {
        
            if (type.IsClass && !type.Name.Contains("<") && typeof(Ihomework).IsAssignableFrom(type))
            {
                classes.Add(type);
                Console.WriteLine($"{n}. {type.FullName}");
            }
            n++;
        }
        int choice;
        while (!Int32.TryParse(Console.ReadLine(), out choice))
        {
            Console.WriteLine("Please enter valid choice...");
        }
        var homework = (Ihomework)Activator.CreateInstance(classes[choice - 1]);
        homework.Run();

    }
}