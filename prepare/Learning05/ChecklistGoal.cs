public class ChecklistGoal : Goal
{
    public int DesiredAmount { get; private set; }
    public int CompletionCount { get; private set; }
    public int Bonus { get; private set; }

    public ChecklistGoal(string name, int value, int desiredAmount, int bonus, int completionCount = 0)
{
    Name = name;
    Value = value;
    DesiredAmount = desiredAmount;
    Bonus = bonus;
    CompletionCount = completionCount;
}


    public override void MarkComplete()
    {
        CompletionCount++;
        if (CompletionCount >= DesiredAmount)
            IsComplete = true;
    }

    public override int CalculatePoints()
    {
        if (IsComplete)
            return (Value * CompletionCount) + Bonus;
        else
            return Value * CompletionCount;
    }

    public override string GetGoalDetails()
    {
        return $"(Completed {CompletionCount}/{DesiredAmount} times)";
    }
}
