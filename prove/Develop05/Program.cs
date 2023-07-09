class Program
{
    static List<Goal> goals = new List<Goal>();
    static int userScore = 0;
    static int userLevel = 1;

    static void Main()
    {
        Console.WriteLine("Welcome to the Eternal Quest program!");

        while (true)
        {
            Console.WriteLine();
            Console.WriteLine("Please select an option:");
            Console.WriteLine("1. View Goals");
            Console.WriteLine("2. Add Goal");
            Console.WriteLine("3. Record Event");
            Console.WriteLine("4. View Score");
            Console.WriteLine("5. Save Goals");
            Console.WriteLine("6. Load Goals");
            Console.WriteLine("7. Quit");

            string choice = Console.ReadLine();
            Console.WriteLine();

            switch (choice)
            {
                case "1":
                    DisplayGoals();
                    break;
                case "2":
                    AddGoal();
                    break;
                case "3":
                    RecordEvent();
                    break;
                case "4":
                    ViewScore();
                    break;
                case "5":
                    SaveGoals();
                    break;
                case "6":
                    LoadGoals();
                    break;
                case "7":
                    Console.WriteLine("Goodbye!");
                    return;
                default:
                    Console.WriteLine("Invalid choice. Please try again.");
                    break;
            }
        }
    }

    static void DisplayGoals()
    {
        Console.WriteLine("Goals:");
        foreach (var goal in goals)
        {
            string completionStatus = goal.IsComplete ? "[X]" : "[ ]";
            string goalDetails = goal.GetGoalDetails();
            Console.WriteLine($"{completionStatus} {goal.Name} {goalDetails}");
        }
        Console.WriteLine();
    }

     static void AddGoal()
    {
        Console.WriteLine("Please enter the goal name:");
        string name = Console.ReadLine();

        Console.WriteLine("Please select the goal type:");
        Console.WriteLine("1. Simple Goal");
        Console.WriteLine("2. Eternal Goal");
        Console.WriteLine("3. Checklist Goal");

        string choice = Console.ReadLine();

        switch (choice)
        {
            case "1":
                Console.WriteLine("Please enter the goal value:");
                int value = Convert.ToInt32(Console.ReadLine());
                goals.Add(new SimpleGoal(name, value));
                Console.WriteLine($"Simple goal \"{name}\" added successfully.");
                break;
            case "2":
                Console.WriteLine("Please enter the goal value:");
                value = Convert.ToInt32(Console.ReadLine());
                goals.Add(new EternalGoal(name, value));
                Console.WriteLine($"Eternal goal \"{name}\" added successfully.");
                break;
            case "3":
                Console.WriteLine("Please enter the goal value:");
                value = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("Please enter the desired amount of completions:");
                int desiredAmount = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("Please enter the bonus points:");
                int bonus = Convert.ToInt32(Console.ReadLine());
                 Console.WriteLine("Please enter the current completion count:");
            int completionCount = Convert.ToInt32(Console.ReadLine());
            goals.Add(new ChecklistGoal(name, value, desiredAmount, bonus, completionCount));
            Console.WriteLine($"Checklist goal \"{name}\" added successfully.");
            break;
            default:
                Console.WriteLine("Invalid choice. Goal not added.");
                break;
        }
        Console.WriteLine();
    }
    static void RecordEvent()
    {
        if (goals.Count == 0)
        {
            Console.WriteLine("No goals found. Please add a goal first.");
            Console.WriteLine();
            return;
        }

        Console.WriteLine("Please select the goal you want to record an event for:");
        for (int i = 0; i < goals.Count; i++)
        {
            Console.WriteLine($"{i + 1}. {goals[i].Name}");
        }

        string choice = Console.ReadLine();
        int index = Convert.ToInt32(choice) - 1;

        if (index >= 0 && index < goals.Count)
        {
            goals[index].MarkComplete();
            userScore += goals[index].CalculatePoints();
            Console.WriteLine($"Event recorded for goal \"{goals[index].Name}\". Points added to your score.");

            if (userScore >= 1000)
            {
                userLevel++;
                Console.WriteLine($"Congratulations! You've reached Level {userLevel}!");
            }
        }
        else
        {
            Console.WriteLine("Invalid goal index.");
        }
        Console.WriteLine();
    }

    static void ViewScore()
    {
        Console.WriteLine($"Your current score is: {userScore}");
        Console.WriteLine($"Your current level is: {userLevel}");
        Console.WriteLine();
    }

    static void SaveGoals()
    {
        Console.WriteLine("Please enter the filename to save the goals:");
        string filename = Console.ReadLine();

        using (StreamWriter writer = new StreamWriter(filename))
        {
            writer.WriteLine($"{userScore} points");
            writer.WriteLine($"Level:{userLevel}");

            foreach (var goal in goals)
            {
                string goalType = goal.GetType().Name;
                string goalDetails = goalType + ":" + goal.Name + "," + goal.Value;

                if (goal is ChecklistGoal checklistGoal)
                {
                    goalDetails += $",{checklistGoal.DesiredAmount},{checklistGoal.Bonus},{checklistGoal.CompletionCount}";
                }

                writer.WriteLine(goalDetails);
            }
        }

        Console.WriteLine("Your goals have been saved successfully.");
    }

    static void LoadGoals()
    {
        Console.WriteLine("Please enter the filename to load the goals:");
        string filename = Console.ReadLine();

        if (File.Exists(filename))
        {
            goals.Clear();
            userScore = 0;
            userLevel = 1;

            using (StreamReader reader = new StreamReader(filename))
            {
                string scoreLine = reader.ReadLine();
                if (scoreLine != null && scoreLine.EndsWith(" points"))
                {
                    int.TryParse(scoreLine.Replace(" points", ""), out userScore);
                }

                string levelLine = reader.ReadLine();
                if (levelLine != null && levelLine.StartsWith("Level:"))
                {
                    int.TryParse(levelLine.Replace("Level:", ""), out userLevel);
                }

                string line;
                while ((line = reader.ReadLine()) != null)
                {
                    string[] goalData = line.Split(':');
                    if (goalData.Length != 2)
                    {
                        continue;
                    }

                    string[] details = goalData[1].Split(',');
                    if (details.Length < 2)
                    {
                        continue;
                    }

                    string goalType = goalData[0];
                    string goalName = details[0];
                    int goalValue;
                    int.TryParse(details[1], out goalValue);

                    Goal goal;
                    switch (goalType)
                    {
                        case nameof(SimpleGoal):
                            goal = new SimpleGoal(goalName, goalValue);
                            break;
                        case nameof(EternalGoal):
                            goal = new EternalGoal(goalName, goalValue);
                            break;
                        case nameof(ChecklistGoal):
                        if (details.Length != 5)
                        {
                            continue;
                        }
                        int desiredAmount;
                        int.TryParse(details[2], out desiredAmount);
                        int completionCount;
                        int.TryParse(details[3], out completionCount);
                        int bonus;
                        int.TryParse(details[4], out bonus);
                        goal = new ChecklistGoal(goalName, goalValue, desiredAmount, completionCount, bonus);
                        break;
                    default:
                        continue;
                }

                if (goalData[0] != null && goalData[0].EndsWith(":True"))
                {
                    goal.MarkComplete();
                }

                goals.Add(goal);
            }
        }

        Console.WriteLine("Save data loaded successfully.");
    }
    else
    {
        Console.WriteLine("File not found. No goals loaded.");
    }
}

}
