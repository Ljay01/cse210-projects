public class EternalGoal : Goal
{
    public EternalGoal(string name, string description, int points) : base(name, description, points)
    {
    }

    public override int RecordEvent()
    {
        // Always awards points, never completes
        return _points;
    }

    public override bool IsComplete()
    {
        return false;
    }

    public override string GetStringRepresentation()
    {
        // Eternal|name|desc|points
        return $"Eternal|{_name}|{_description}|{_points}";
    }
}