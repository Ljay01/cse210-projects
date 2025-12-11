using System;
using System.Collections.Generic;
using System.IO;

class Program
{
    static void Main(string[] args)
    {
        var manager = new GoalManager();

        manager.Start();
        Console.WriteLine("Goodbye!");
    }
}