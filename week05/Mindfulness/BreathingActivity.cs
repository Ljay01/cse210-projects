using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Threading;
public class BreathingActivity : Activity
{
    public BreathingActivity(ActivityLogger logger)
        : base("Breathing Activity",
              "This activity will help you relax by walking you through breathing in and out slowly. Clear your mind and focus on your breathing.",
              logger)
    { }

    public override void Run()
    {
        DisplayStartingMessage();
        Console.WriteLine();

        Stopwatch sw = Stopwatch.StartNew();
        bool inhale = true;
        while (sw.Elapsed.TotalSeconds < _duration)
        {
            if (inhale)
                Console.Write("Breathe in... ");
            else
                Console.Write("Breathe out... ");

            // show a short countdown for each breath segment (4 seconds)
            ShowCountDown(4);
            Console.WriteLine();
            inhale = !inhale;

            // small safety break if duration is near
            if (sw.Elapsed.TotalSeconds >= _duration) break;
        }

        DisplayEndingMessage();
    }
}