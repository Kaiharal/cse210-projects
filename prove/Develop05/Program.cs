using System;

//Eternal Quest
class Program
{

    private int _totalPoints;
    private List<Objective> _toDoList = [];

    static void Main()
    {
        //Menu
        Console.WriteLine("Welcome to Eternal quest.");
        bool done = false;
        int choice;
        while (!done)
        {
            choice = 0;
            Console.Writeline("Please select an option:");
            Console.Writeline("1. Add a new task");
            Console.Writeline("2. Mark a task as complete");
            Console.Writeline("3. Delete a task");
            Console.Writeline("4. Display to-do list and total points");
            Console.Writeline("5. Save my tasks");
            Console.Writeline("6. Load a list of tasks");
            while (choice < 1 or choice > 6)
            {
                try
                {
                    Console.WriteLine("Your Choice:");
                    choice = int.Parse(Console.ReadLine());
                    if (choice < 1 or choice > 6)
                    {
                        Console.WriteLine("Please enter a number between 1 and 6");
                    }
                }
                catch (FormatException)
                {
                    Console.WriteLine("Please enter a number between 1 and 6");
                }
            }
            switch choice
            {
                case 1:
                    MakeTask();
                    break;
                case 2:
                    CompleteTask();
                    break;
                case 3:
                    DelTask();
                    break;
                case 4:
                    DisplayList();
                    break;
                case 5:
                    SaveList();
                    break;
                case 6:
                    LoadList();
                    break;
                default:
                    Console.Writeline("An error has occured. (1)");
                    break;
            }

        }

    }

    private void MakeTask() //creates a new task for the list
    {

        Console.WriteLine("What is the name of the task?");
        string name = Console.ReadLine();
        Console.WriteLine("What is the description of the task?");
        string description = Console.ReadLine();
        Console.Writeline("How many points is this task worth?");
        string points = null;
        while (points == null)
        {
            try
            {
                points = int.Parse(Console.ReadLine());
            }
            catch (FormatException)
            {
                Console.WriteLine("Please enter a number.");
            }
        }
        Console.Writeline("Is this task...");
        Console.Writeline("1: A One-time task?");
        Console.Writeline("2: A task to complete multiple times?");
        Console.Writeline("3: A task that is never completed?");
        int taskType = 0;
        while (taskType < 1 or taskType > 3)
        {
            try
            {
                taskType = int.Parse(Console.ReadLine());
                if (taskType < 1 or taskType > 3)
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
            case 2:
                Console.WriteLine("How many times does this task need to be completed?")
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
                Console.Writeline("How many bonus points will be awarded when this task is fully complete?");
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
                _toDoList.Add(new MultiTask(name, description, false, points, timesCompleted, bonusPoints));
            case 3:
                _toDoList.Add(new EternalTask(name, description, false, points));
            default:
                Console.WriteLine("An error has occured (2).");
                break;
        }
        

    }

    private void CompleteTask() //marks a task as complete and/or adds points relating to a completed objective.
    {
        Console.Writeline("Which task would you like to mark as complete?");
        int compChoice = SelectedTask();
        _totalPoints += _todoList[compChoice].completeTask();
    }

    private void DelTask() //deletes a task
    {
        Console.Writeline("Which task would you like to delete?");
        int delChoice = SelectedTask();
        _toDoList.RemoveAt(delChoice);
    }

    private void DisplayList() //displays the list of current tasks, and your total points.
    {
        int i = 1;
        foreach (Objective task in _toDoList)
        {
            Console.WriteLine(i + ". " + task.getName());
            Console.WriteLine("     Description: " + task.getDescription());
            Console.WriteLine("     Points: " + task.getPoints());
            if (task is MultiTask)
            {
                Console.WriteLine("     Progress: " + task.getProgressNumber() + "/" + task.getGoalNumber());
            }
            else if (task is eternalTask)
            {
                Console.WriteLine("     Times Completed: " + task.getTimesCompleted());
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
        }
        
    }

    private void LoadList() //Loads a previously saved list of tasks and total points.
    {

    }

    private void SaveList() //Saves your list of tasks and total points to a file
    {

    }

    private int SelectedTask()  //returns the index of the selected task
    {
        int compChoice = 0;
        while (compChoice < 1 or compChoice > _toDoList.Count)
        {
            try
            {
                compChoice = int.Parse(Console.ReadLine());
                if (compChoice < 1 or compChoice > _toDoList.Count)
                {
                    Console.WriteLine("Please enter a number between 1 and " + _toDoList.Count);
                }
                catch (FormatException)
                {
                    Console.WriteLine("Please enter a number.");
                }
            }
        }

        return compChoice;
        
    }
}