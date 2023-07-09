public abstract class Goal
{
    public string Name { get; set; }
    public bool IsComplete { get; set; }
    public int Value { get; protected set; }

    public virtual void MarkComplete()
    {
        IsComplete = true;
    }

    public abstract int CalculatePoints();

    public virtual string GetGoalDetails()
    {
        return string.Empty;
    }
}

