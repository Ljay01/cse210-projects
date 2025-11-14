using System;

public class Entry
{
    public string _date;
    public string _promptText;
    public string _entryText;

    // EXTRA creativity fields
    public string _mood;
    public string _weather;

    public void Display()
    {
        Console.WriteLine($"Date: {_date}");
        Console.WriteLine($"Prompt: {_promptText}");
        Console.WriteLine($"Entry: {_entryText}");
        Console.WriteLine($"Mood: {_mood}");
        Console.WriteLine($"Weather: {_weather}");
        Console.WriteLine("-------------------------");
    }

    public string FormatForFile()
    {
        return $"{_date}|{_promptText}|{_entryText}|{_mood}|{_weather}";
    }

    public static Entry FromFileString(string line)
    {
        string[] parts = line.Split('|');
        
        return new Entry
        {
            _date = parts[0],
            _promptText = parts[1],
            _entryText = parts[2],
            _mood = parts[3],
            _weather = parts[4]
        };
    }
}
