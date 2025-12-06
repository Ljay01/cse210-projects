using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Threading;
public class ReflectingActivity : Activity
{
    private List<string> _prompts = new List<string>()
        {
            "Think of a time when you stood up for someone else.",
            "Think of a time when you did something really difficult.",
            "Think of a time when you helped someone in need.",
            "Think of a time when you did something truly selfless."
        };

    private List<string> _questions = new List<string>()
        {
            "Why was this experience meaningful to you?",
            "Have you ever done anything like this before?",
            "How did you get started?",
            "How did you feel when it was complete?",
            "What made this time different than other times when you were not as successful?",
            "What could you learn from this experience that applies to other situations?"
        };

    private Random _rng = new Random();

    public ReflectingActivity(ActivityLogger logger)
        : base("Reflecting Activity",
              "This activity will help you reflect on times in your life when you have shown strength and resilience.",
              logger)
    { }

    public override void Run()
    {
        DisplayStartingMessage();
        Console.WriteLine();

        // show a random prompt
        string prompt = _prompts[_rng.Next(_prompts.Count)];
        Console.WriteLine("Prompt:");
        Console.WriteLine($"-> {prompt}");
        Console.WriteLine();

        Stopwatch sw = Stopwatch.StartNew();
        while (sw.Elapsed.TotalSeconds < _duration)
        {
            string question = _questions[_rng.Next(_questions.Count)];
            Console.WriteLine(question);
            ShowSpinner(5); // give user time to reflect
            Console.WriteLine();

            // break early if we've reached duration
            if (sw.Elapsed.TotalSeconds >= _duration) break;
        }

        DisplayEndingMessage();
    }
}