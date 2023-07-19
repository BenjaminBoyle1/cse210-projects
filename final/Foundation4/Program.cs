using System;

public class Program
{
    public static void Main()
    {
        Activity runningActivity = new Running(new DateTime(2022, 11, 3), 30, 3.0);
        Activity cyclingActivity = new Cycling(new DateTime(2022, 11, 3), 30, 6.0);
        Activity swimmingActivity = new Swimming(new DateTime(2022, 11, 3), 30, 60);

        Activity[] activities = { runningActivity, cyclingActivity, swimmingActivity };

        foreach (Activity activity in activities)
        {
            Console.WriteLine(activity.GetSummary());
        }
    }
}
