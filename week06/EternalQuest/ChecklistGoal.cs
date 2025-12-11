public class ChecklistGoal : Goal
{
    private int _amountCompleted;
    private int _target;
    private int _bonus;

    public ChecklistGoal(string name, string description, int points, int target, int bonus) : base(name, description, points)
    {
        _amountCompleted = 0;
        _target = target;
        _bonus = bonus;
    }

    public override int RecordEvent()
    {
        if (IsComplete())
        {
            return 0;
        }

        _amountCompleted++;
        int award = _points;
        if (_amountCompleted >= _target)
        {
            // Award bonus the moment target reached
            award += _bonus;
        }
        return award;
    }

    public override bool IsComplete()
    {
        return _amountCompleted >= _target;
    }

    public override string GetDetailsString()
    {
        string status = IsComplete() ? "[X]" : "[ ]";
        return $"{status} {_name} ({_description}) -- Completed {_amountCompleted}/{_target}";
    }

    public override string GetStringRepresentation()
    {
        // Checklist|name|desc|points|completed|target|bonus
        return $"Checklist|{_name}|{_description}|{_points}|{_amountCompleted}|{_target}|{_bonus}";
    }

    // For loading
    public void SetAmountCompleted(int c)
    {
        _amountCompleted = c;
    }
}