using System;

public class Program
{
    static void Main()
    {
        Patient joe;

        joe = new Patient();

        joe.SetName("joe");

        Console.WriteLine($"The patient name is {joe.GetName()}");
        Console.ReadKey();  
    }
}