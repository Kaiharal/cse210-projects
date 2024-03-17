using System;

//Eternal Quest
class Program
{



    private static void Main()
    {

        int _totalPoints = 0;
        List<Objective> _toDoList = new List<Objective>();
        //Menu
        Console.WriteLine("Welcome to Eternal quest.");
        bool done = false;
        int choice;
        while (!done)
        {
            choice = 0;
            Console.WriteLine("Please select an option:");
            Console.WriteLine("1. Add a new task");
            Console.WriteLine("2. Mark a task as complete");
            Console.WriteLine("3. Delete a task");
            Console.WriteLine("4. Display to-do list and total points");
            Console.WriteLine("5. Save my tasks");
            Console.WriteLine("6. Load a list of tasks");
            Console.WriteLine("7. Exit");
            while (choice < 1 || choice > 7)
            {
                try
                {
                    Console.WriteLine("Your Choice:");
                    choice = int.Parse(Console.ReadLine());
                    if (choice < 1 || choice > 7)
                    {
                        Console.WriteLine("Please enter a number between 1 and 7");
                    }
                }
                catch (FormatException)
                {
                    Console.WriteLine("Please enter a number between 1 and 7");
                }
            }
            switch (choice)
            {
                case 1:
                    MakeTask(_toDoList);
                    break;
                case 2:
                    _totalPoints = CompleteTask(_toDoList, _totalPoints);
                    break;
                case 3:
                    DelTask(_toDoList);
                    break;
                case 4:
                    DisplayList(_toDoList, _totalPoints);
                    break;
                case 5:
                    SaveList(_toDoList, _totalPoints);
                    break;
                case 6:
                    _totalPoints = LoadList(_toDoList, _totalPoints);
                    break;
                case 7:
                    done = true;
                    break;
                default:
                    Console.WriteLine("An error has occured. (1)");
                    break;
            }

        }

    }

    private static void MakeTask(List<Objective> _toDoList) //creates a new task for the list
    {

        Console.WriteLine("What is the name of the task?");
        string name = Console.ReadLine();
        Console.WriteLine("What is the description of the task?");
        string description = Console.ReadLine();
        Console.WriteLine("How many points is this task worth?");
        int points = 0;
        while (points <= 0)
        {
            try
            {
                points = int.Parse(Console.ReadLine());
            }
            catch (FormatException)
            {
                Console.WriteLine("Please enter a number greater than 0:.");
            }
        }
        Console.WriteLine("Is this task...");
        Console.WriteLine("1: A One-time task?");
        Console.WriteLine("2: A task to complete multiple times?");
        Console.WriteLine("3: A task that is never completed?");
        int taskType = 0;
        while (taskType < 1 || taskType > 3)
        {
            try
            {
                taskType = int.Parse(Console.ReadLine());
                if (taskType < 1 || taskType > 3)
                {
                    Console.WriteLine("Please enter a number between 1 and 3");
                }
            }
            catch (FormatException)
            {
                Console.WriteLine("Please enter a number between 1 and 3");
            }
        }
        switch (taskType)
        {
            case 1:
                _toDoList.Add(new OneTask(name, description, false, points));
                break;
            case 2:
                Console.WriteLine("How many times does this task need to be completed?");
                int timesCompleted = 0;
                while (timesCompleted < 1)
                {
                    try
                    {
                        timesCompleted = int.Parse(Console.ReadLine());
                    }
                    catch (FormatException)
                    {
                        Console.WriteLine("Please enter a number.");
                    }
                }
                Console.WriteLine("How many bonus points will be awarded when this task is fully complete?");
                int bonusPoints = 0;
                while (bonusPoints < 1)
                {
                    try
                    {
                        bonusPoints = int.Parse(Console.ReadLine());
                    }
                    catch (FormatException)
                    {
                        Console.WriteLine("Please enter a number.");
                    }
                }
                _toDoList.Add(new MultiTask(name, description, false, points, timesCompleted, bonusPoints, 0));
                break;
            case 3:
                _toDoList.Add(new EternalTask(name, description, false, points, 0));
                break;
            default:
                Console.WriteLine("An error has occured (2).");
                break;
        }
    }

    private static int CompleteTask( List<Objective> _toDoList, int _totalPoints) //marks a task as complete and/or adds points relating to a completed objective.
    {
        DisplayList(_toDoList, _totalPoints);
        Console.WriteLine("Which task would you like to mark as complete?");
        int compChoice = SelectedTask(_toDoList);
        _totalPoints += _toDoList[compChoice].completeTask();
        return _totalPoints;
    }

    private static void DelTask(List<Objective> _toDoList) //deletes a task
    {
        Console.WriteLine("Which task would you like to delete?");
        int delChoice = SelectedTask(_toDoList);
        _toDoList.RemoveAt(delChoice);
    }

    private static void DisplayList(List<Objective> _toDoList, int _totalPoints) //displays the list of current tasks, and your total points.
    {

        Console.WriteLine("\n\n -------------------------------------------------------\n Your To-Do List: ");
        Console.WriteLine("Total Points: " + _totalPoints);
        int i = 1;
        foreach (Objective task in _toDoList)
        {
            Console.WriteLine(i + ". " + task.getName());
            Console.WriteLine("     Description: " + task.getDescription());
            Console.WriteLine("     Points: " + task.getPoints());
            if (task is MultiTask)
            {
                Console.WriteLine("     Progress: " + (task as MultiTask).getProgressNumber() + "/" + (task as MultiTask).getGoalNumber() + "  Bonus Points: " + (task as MultiTask).getBonusPoints());
            }
            else if (task is EternalTask)
            {
                Console.WriteLine("     Times Completed: " + (task as EternalTask).getTimesCompleted());
            }
            else if (task is OneTask)
            {
                if (task.getStatus())
                {
                    Console.WriteLine("     Status: Completed");
                }
                else
                {
                    Console.WriteLine("     Status: Not Completed");
                }
            }
            i++;
        }
        Console.WriteLine("\n----------------------------------------------------\n\n");
        
    }

    public static void SaveList(List<Objective> _toDoList, int _totalPoints)
    {
        Console.Write("Enter the name of the file to save your List to: ");
        string filename = Console.ReadLine();
        using (StreamWriter file = new StreamWriter(filename))
        {
            foreach  (Objective o in _toDoList)
            {
                if (o is OneTask)
                {
                    file.WriteLine($"OneTask~|~{o.getName()}~|~{o.getDescription()}~|~{(o as OneTask).getStatus()}~|~{(o as OneTask).getPoints()}");
                }
                else if (o is MultiTask)
                {
                    file.WriteLine($"MultiTask~|~{o.getName()}~|~{o.getDescription()}~|~{(o as MultiTask).getStatus()}~|~{(o as MultiTask).getPoints()}~|~{(o as MultiTask).getGoalNumber()}~|~{(o as MultiTask).getBonusPoints()}~|~{(o as MultiTask).getProgressNumber()}");
                }
                else if (o is EternalTask)
                {
                    file.WriteLine($"EternalTask~|~{o.getName()}~|~{o.getDescription()}~|~{(o as EternalTask).getStatus()}~|~{(o as EternalTask).getPoints()}~|~{(o as EternalTask).getTimesCompleted()}");
                }
            }
            file.WriteLine($"TotalPoints~|~{_totalPoints}");
        }
    }

    public static int LoadList(List<Objective> _toDoList, int _totalPoints)
    {
        Console.Write("Enter a filename to load: ");
        string filename = Console.ReadLine();
        _toDoList.Clear();
        using (StreamReader file = new StreamReader(filename))
        {
            string line;
            while ((line = file.ReadLine()) != null)
            {
                string[] parts = line.Split(new string[] { "~|~" }, StringSplitOptions.None);
                if (parts[0] == "OneTask")
                {
                    _toDoList.Add(new OneTask(parts[1], parts[2], bool.Parse(parts[3]), int.Parse(parts[4])));
                }
                else if (parts[0] == "MultiTask")
                {
                    _toDoList.Add(new MultiTask(parts[1], parts[2], bool.Parse(parts[3]), int.Parse(parts[4]), int.Parse(parts[5]), int.Parse(parts[6]), int.Parse(parts[7])));
                }
                else if (parts[0] == "EternalTask")
                {
                    _toDoList.Add(new EternalTask(parts[1], parts[2], bool.Parse(parts[3]), int.Parse(parts[4]), int.Parse(parts[5])));
                }
                else if (parts[0] == "TotalPoints")
                {
                    _totalPoints = int.Parse(parts[1]);
                }
            }
        }
        return _totalPoints;
    }

    private static int SelectedTask(List<Objective> _toDoList)  //returns the index of the selected task
    {
        int compChoice = 0;
        while (compChoice < 1 || compChoice > _toDoList.Count)
        {
            try
            {
                compChoice = int.Parse(Console.ReadLine());
                if (compChoice < 1 || compChoice > _toDoList.Count)
                {
                    Console.WriteLine("Please enter a number between 1 and " + _toDoList.Count);
                }
            }
            catch (FormatException)
            {
                    Console.WriteLine("Please enter a number.");
            }
        }

        //subtracting 1 because arrays start at 0
        return compChoice - 1;
        
    }
}