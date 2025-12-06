
// Creativity / Exceeding Requirements - Activity logger.
// Keeps persistent counts of how many times each activity completed.

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Threading;

class Program
{
  static void Main(string[] args)
        {
            ActivityLogger logger = new ActivityLogger(); // persists to activity_log.txt
            var activities = new Dictionary<int, Activity>()
            {
                {1, new BreathingActivity(logger) },
                {2, new ReflectingActivity(logger) },
                {3, new ListingActivity(logger) }
            };

            while (true)
            {
                Console.Clear();
                Console.WriteLine("Mindfulness Program");
                Console.WriteLine("-------------------");
                Console.WriteLine("1. Breathing Activity");
                Console.WriteLine("2. Reflecting Activity");
                Console.WriteLine("3. Listing Activity");
                Console.WriteLine("4. Show Activity Log Summary");
                Console.WriteLine("5. Quit");
                Console.WriteLine();
                Console.Write("Choose an option: ");

                var input = Console.ReadLine();
                if (!int.TryParse(input, out int choice))
                    continue;

                if (choice == 5) break;

                if (choice == 4)
                {
                    Console.Clear();
                    logger.PrintSummary();
                    Console.WriteLine();
                    Console.WriteLine("Press Enter to return to menu...");
                    Console.ReadLine();
                    continue;
                }

                if (activities.ContainsKey(choice))
                {
                    activities[choice].Run();
                }
            }

            Console.WriteLine("Goodbye. Stay mindful!");
        }
}