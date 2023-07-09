public class EternalGoal : Goal
{
    public EternalGoal(string name, int value)
    {
        Name = name;
        Value = value;
    }

    public override int CalculatePoints()
    {
        return Value;
    }
}
