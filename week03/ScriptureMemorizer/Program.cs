using System;

/*
   EXCEEDING REQUIREMENTS:
   - Added a library of scriptures instead of a single scripture.
   - Program picks a random scripture each time.
*/

class Program
{
    static void Main(string[] args)
    {
        Console.Clear();
        Console.WriteLine("SCRIPTURE MEMORIZER\n");

        // Scripture library
        var scriptures = new[]
        {
            new Scripture(
                new Reference("John", 3, 16),
                "For God so loved the world that he gave his only begotten Son"
            ),

            new Scripture(
                new Reference("Proverbs", 3, 5, 6),
                "Trust in the Lord with all thine heart and lean not unto thine own understanding"
            ),

            new Scripture(
                new Reference("Psalms", 23, 1),
                "The Lord is my shepherd I shall not want"
            )
        };

        Random rand = new Random();
        Scripture scripture = scriptures[rand.Next(scriptures.Length)];

        while (true)
        {
            Console.Clear();
            Console.WriteLine(scripture.GetDisplayText());
            Console.WriteLine("\nPress ENTER to hide words or type 'quit' to exit.");
            string input = Console.ReadLine();

            if (input.ToLower() == "quit")
                break;

            scripture.HideRandomWords(1);

            if (scripture.IsCompletelyHidden())
            {
                Console.Clear();
                Console.WriteLine(scripture.GetDisplayText());
                Console.WriteLine("\nAll words are hidden. Goodbye!");
                break;
            }
        }
    }
}
