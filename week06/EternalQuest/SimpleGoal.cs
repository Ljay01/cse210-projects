public class SimpleGoal : Goal
{
    private bool _isComplete;

    public SimpleGoal(string name, string description, int points) : base(name, description, points)
    {
        _isComplete = false;
    }

    // Force complete used when loading from file
    public void ForceComplete()
    {
        _isComplete = true;
    }

    public override int RecordEvent()
    {
        if (_isComplete)
        {
            return 0; // No points if already completed
        }
        _isComplete = true;
        return _points;
    }

    public override bool IsComplete()
    {
        return _isComplete;
    }

    public override string GetStringRepresentation()
    {
        // Simple|name|desc|points|isComplete
        return $"Simple|{_name}|{_description}|{_points}|{_isComplete}";
    }
}