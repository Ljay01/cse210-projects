public abstract class Goal
{
    // Protected so derived classes can access in controlled ways
    protected string _name;
    protected string _description;
    protected int _points;

    public Goal(string name, string description, int points)
    {
        _name = name;
        _description = description;
        _points = points;
    }

    // Display representation used in lists
    public virtual string GetDetailsString()
    {
        string status = IsComplete() ? "[X]" : "[ ]";
        return $"{status} {_name} ({_description})";
    }

    // Record event and return points awarded
    public abstract int RecordEvent();

    // Whether the goal is finished
    public abstract bool IsComplete();

    // Return a string representation suitable for saving to file
    public abstract string GetStringRepresentation();

    // Factory method for loading - useful for GoalManager
    public static Goal CreateFromString(string savedLine)
    {
        // Format: TYPE|fields...
        // Simple: Simple|name|desc|points|isComplete
        // Eternal: Eternal|name|desc|points
        // Checklist: Checklist|name|desc|points|completed|target|bonus

        var parts = savedLine.Split('|');
        if (parts.Length == 0) throw new Exception("Invalid goal line.");

        string type = parts[0];
        if (type == "Simple")
        {
            // Validate
            // parts: 0:type 1:name 2:desc 3:points 4:isComplete
            string name = parts[1];
            string desc = parts[2];
            int points = int.Parse(parts[3]);
            bool isComplete = bool.Parse(parts[4]);
            var g = new SimpleGoal(name, desc, points);
            if (isComplete) g.ForceComplete();
            return g;
        }
        else if (type == "Eternal")
        {
            // parts: 0:type 1:name 2:desc 3:points
            string name = parts[1];
            string desc = parts[2];
            int points = int.Parse(parts[3]);
            return new EternalGoal(name, desc, points);
        }
        else if (type == "Checklist")
        {
            // parts: 0:type 1:name 2:desc 3:points 4:completed 5:target 6:bonus
            string name = parts[1];
            string desc = parts[2];
            int points = int.Parse(parts[3]);
            int completed = int.Parse(parts[4]);
            int target = int.Parse(parts[5]);
            int bonus = int.Parse(parts[6]);
            var g = new ChecklistGoal(name, desc, points, target, bonus);
            g.SetAmountCompleted(completed);
            return g;
        }
        else
        {
            throw new Exception($"Unknown goal type: {type}");
        }
    }
}