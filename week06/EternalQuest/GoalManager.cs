public class GoalManager
{
    private List<Goal> _goals;
    private int _score;

    public GoalManager()
    {
        _goals = new List<Goal>();
        _score = 0;
    }

    public void Start()
    {
        bool isRunning = true;
        while (isRunning)
        {
            Console.Clear();
            Console.WriteLine("=== Eternal Quest ===");
            Console.WriteLine($"Current Score: {_score}");
            Console.WriteLine();
            Console.WriteLine("Menu Options:");
            Console.WriteLine("1. Create New Goal");
            Console.WriteLine("2. List Goals (names)");
            Console.WriteLine("3. List Goals (details)");
            Console.WriteLine("4. Record Event");
            Console.WriteLine("5. Save Goals");
            Console.WriteLine("6. Load Goals");
            Console.WriteLine("7. Exit");
            Console.Write("Choose an option (1-7): ");
            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    CreateGoal();
                    break;
                case "2":
                    ListGoalNames();
                    Pause();
                    break;
                case "3":
                    ListGoalDetails();
                    Pause();
                    break;
                case "4":
                    RecordEvent();
                    Pause();
                    break;
                case "5":
                    SaveGoals();
                    Pause();
                    break;
                case "6":
                    LoadGoals();
                    Pause();
                    break;
                case "7":
                    isRunning = false;
                    break;
                default:
                    Console.WriteLine("Invalid choice.");
                    Pause();
                    break;
            }
        }
    }

    private void Pause()
    {
        Console.WriteLine();
        Console.WriteLine("Press Enter to continue...");
        Console.ReadLine();
    }

    public void DisplayPlayerInfo()
    {
        Console.WriteLine($"Score: {_score}");
    }

    public void ListGoalNames()
    {
        Console.WriteLine("Goals:");
        for (int i = 0; i < _goals.Count; i++)
        {
            Console.WriteLine($"{i + 1}. {_goals[i].GetDetailsString().Split(new[] { " -- " }, StringSplitOptions.None)[0]}");
        }
    }

    public void ListGoalDetails()
    {
        Console.WriteLine("Goals Details:");
        foreach (var g in _goals)
        {
            Console.WriteLine(g.GetDetailsString());
        }
    }

    private void CreateGoal()
    {
        Console.WriteLine("Choose goal type:");
        Console.WriteLine("1. Simple Goal");
        Console.WriteLine("2. Eternal Goal");
        Console.WriteLine("3. Checklist Goal");
        Console.Write("Type (1-3): ");
        string t = Console.ReadLine();

        Console.Write("Enter goal name: ");
        string name = Console.ReadLine();
        Console.Write("Enter description: ");
        string desc = Console.ReadLine();
        Console.Write("Enter points per record (integer): ");
        int points = ReadIntFromConsole();

        if (t == "1")
        {
            var g = new SimpleGoal(name, desc, points);
            _goals.Add(g);
            Console.WriteLine("Simple Goal created.");
        }
        else if (t == "2")
        {
            var g = new EternalGoal(name, desc, points);
            _goals.Add(g);
            Console.WriteLine("Eternal Goal created.");
        }
        else if (t == "3")
        {
            Console.Write("Enter target count (how many times to complete): ");
            int target = ReadIntFromConsole();
            Console.Write("Enter bonus points when target reached: ");
            int bonus = ReadIntFromConsole();
            var g = new ChecklistGoal(name, desc, points, target, bonus);
            _goals.Add(g);
            Console.WriteLine("Checklist Goal created.");
        }
        else
        {
            Console.WriteLine("Invalid type.");
        }
    }

    private int ReadIntFromConsole()
    {
        while (true)
        {
            string s = Console.ReadLine();
            if (int.TryParse(s, out int v)) return v;
            Console.Write("Invalid integer. Try again: ");
        }
    }

    public void RecordEvent()
    {
        if (_goals.Count == 0)
        {
            Console.WriteLine("No goals available. Create one first.");
            return;
        }

        Console.WriteLine("Which goal did you accomplish?");
        for (int i = 0; i < _goals.Count; i++)
        {
            Console.WriteLine($"{i + 1}. {_goals[i].GetDetailsString()}");
        }
        Console.Write("Enter number: ");
        int idx = ReadIntFromConsole();
        if (idx < 1 || idx > _goals.Count)
        {
            Console.WriteLine("Invalid selection.");
            return;
        }
        var goal = _goals[idx - 1];
        int earned = goal.RecordEvent();
        _score += earned;
        Console.WriteLine($"You earned {earned} points!");
        Console.WriteLine($"Total score is now {_score}.");
    }

    public void SaveGoals()
    {
        Console.Write("Enter filename to save to: ");
        string filename = Console.ReadLine();
        try
        {
            using (StreamWriter sw = new StreamWriter(filename))
            {
                // Save score on first line
                sw.WriteLine(_score);
                foreach (var g in _goals)
                {
                    sw.WriteLine(g.GetStringRepresentation());
                }
            }
            Console.WriteLine($"Saved {_goals.Count} goals to {filename}.");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error saving file: {ex.Message}");
        }
    }

    public void LoadGoals()
    {
        Console.Write("Enter filename to load from: ");
        string filename = Console.ReadLine();
        if (!File.Exists(filename))
        {
            Console.WriteLine("File not found.");
            return;
        }
        try
        {
            var lines = File.ReadAllLines(filename);
            if (lines.Length == 0)
            {
                Console.WriteLine("File is empty.");
                return;
            }

            // First line is score
            int loadedScore = int.Parse(lines[0]);
            var loadedGoals = new List<Goal>();
            for (int i = 1; i < lines.Length; i++)
            {
                if (string.IsNullOrWhiteSpace(lines[i])) continue;
                var g = Goal.CreateFromString(lines[i]);
                loadedGoals.Add(g);
            }

            _score = loadedScore;
            _goals = loadedGoals;
            Console.WriteLine($"Loaded {_goals.Count} goals from {filename}. Score set to {_score}.");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error loading file: {ex.Message}");
        }
    }
}
