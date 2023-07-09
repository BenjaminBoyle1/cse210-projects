class SimpleGoal : Goal
{
    public SimpleGoal(string name, int value)
    {
        Name = name;
        Value = value;
    }

    public override int CalculatePoints()
    {
        return IsComplete ? Value : 0;
    }
}
