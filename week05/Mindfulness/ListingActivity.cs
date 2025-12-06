using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Threading;
public class ListingActivity : Activity
{
    private List<string> _prompts = new List<string>()
        {
            "Who are people that you appreciate?",
            "What are personal strengths of yours?",
            "Who are people that you have helped this week?",
            "Who are some of your personal heroes?"
        };

    private Random _rng = new Random();

    public ListingActivity(ActivityLogger logger)
        : base("Listing Activity",
              "This activity will help you reflect by having you list as many things as you can in a certain area.",
              logger)
    { }

    public override void Run()
    {
        DisplayStartingMessage();
        Console.WriteLine();

        string prompt = _prompts[_rng.Next(_prompts.Count)];
        Console.WriteLine("Prompt:");
        Console.WriteLine($"-> {prompt}");
        Console.WriteLine();
        Console.WriteLine("You will have a few seconds to prepare...");
        ShowCountDown(5);
        Console.WriteLine();
        Console.WriteLine("Start listing items. Press Enter after each item.");

        List<string> items = new List<string>();
        Stopwatch sw = Stopwatch.StartNew();

        // read lines until duration elapsed
        while (sw.Elapsed.TotalSeconds < _duration)
        {
            // If there's less than one second left, stop
            if (_duration - sw.Elapsed.TotalSeconds < 0.15) break;

            // non-blocking read: we will wait up to 1 second for input
            if (Console.KeyAvailable)
            {
                string line = Console.ReadLine();
                if (!string.IsNullOrWhiteSpace(line))
                    items.Add(line.Trim());
            }
            else
            {
                // wait a bit to avoid busy loop
                Thread.Sleep(100);
            }
        }

        Console.WriteLine();
        Console.WriteLine($"You listed {items.Count} items:");
        foreach (var it in items)
            Console.WriteLine($"- {it}");

        DisplayEndingMessage();
    }
}