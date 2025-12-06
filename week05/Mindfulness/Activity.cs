using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Threading;
public abstract class Activity
{
    protected string _name;
    protected string _description;
    protected int _duration; // seconds

    protected ActivityLogger _logger;
    public Activity(string name, string description, ActivityLogger logger)
    {
        _name = name;
        _description = description;
        _duration = 0;
        _logger = logger;
    }
    public void DisplayStartingMessage()
    {
        Console.Clear();
        Console.WriteLine($"*** {_name} ***");
        Console.WriteLine();
        Console.WriteLine(_description);
        Console.WriteLine();
        Console.Write("Enter duration in seconds (e.g. 30): ");
        if (int.TryParse(Console.ReadLine(), out int seconds) && seconds > 0)
        {
            _duration = seconds;
        }
        else
        {
            Console.WriteLine("Invalid duration. Using default 30 seconds.");
            _duration = 30;
        }
        Console.WriteLine();
        Console.WriteLine("Get ready...");
        ShowSpinner(3);
    }

    public void DisplayEndingMessage()
    {
        Console.WriteLine();
        Console.WriteLine("Well done!");
        Console.WriteLine($"You completed {_name} for {_duration} seconds.");
        ShowSpinner(3);
        // Log this completion
        _logger?.Increment(_name);
    }

    // spinner (visual pause)
    protected void ShowSpinner(int seconds)
    {
        string[] spinner = { "/", "-", "\\", "|" };
        Stopwatch sw = Stopwatch.StartNew();
        int i = 0;
        while (sw.Elapsed.TotalSeconds < seconds)
        {
            Console.Write(spinner[i % spinner.Length]);
            Thread.Sleep(250);
            Console.Write("\b");
            i++;
        }
        Console.WriteLine();
    }

    // countdown display for seconds
    protected void ShowCountDown(int seconds)
    {
        for (int i = seconds; i >= 1; i--)
        {
            Console.Write(i);
            Thread.Sleep(1000);
            Console.Write("\b \b");
        }
    }

    // each activity must implement Run
    public abstract void Run();
}

