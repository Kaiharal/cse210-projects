using System;
using System.ComponentModel.Design;

class Program
{
    static void Main() //menu
    {  
        
        Console.WriteLine("Welcome to the Mindfulness program.");
        int choice = 0;
        int requestedDuration = 0;
        bool done = false;
        while(!done)
        {
            choice = Menu();
            if (choice != 4)
            {
                requestedDuration = AskForDuration();
            }
            switch(choice)
            {
                case 1:
                    Breathing activity_01 = new Breathing();
                    StartingMessage(activity_01.Title(), activity_01.Description()); //this needs to take input!
                    Task.WaitAll(activity_01.Start(requestedDuration));
                    EndingMessage(activity_01.Title());
                    break;
                case 2:
                    Reflection activity_02 = new Reflection();
                    StartingMessage(activity_02.Title(), activity_02.Description());
                    activity_02.Start(requestedDuration);                    
                    EndingMessage(activity_02.Title());
                    break;
                case 3:
                    Listing activity_03 = new Listing();
                    StartingMessage(activity_03.Title(), activity_03.Description());
                    activity_03.Start(requestedDuration);
                    EndingMessage(activity_03.Title());
                    break;
                case 4:
                    Console.WriteLine("Thank you for using the program!");
                    done = true;
                    break;

            }
        }

    }

    static int Menu()
    {
        int choice = 0;
        Console.WriteLine("Please select one of the following options:");
        Console.WriteLine("1: Breathing Activity");
        Console.WriteLine("2: Reflection Activity");
        Console.WriteLine("3: Listing Activity");
        Console.WriteLine("4: Quit");

        while(choice <= 0 || choice > 4)
        {
            try
            {
                choice = int.Parse(Console.ReadLine());
                if (choice <= 0 || choice > 4)
                {
                    Console.WriteLine("Invalid input. Please enter a number between 1 and 4.");
                }
            }
            catch (FormatException)
            {
                Console.WriteLine("Invalid input. Please enter a number between 1 and 4.");
            }

        }

        return choice;
    }

    static int AskForDuration()
    {
        Console.WriteLine("How long would you like this activity to last (in seconds)?");
        int duration = 0;
        while (duration <= 0)
        {
            try
            {
                duration = int.Parse(Console.ReadLine());
                if (duration <= 0)
                {
                    Console.WriteLine("Invalid input. Please enter a number greater than 0.");
                }
            }
            catch (FormatException)
            {
                Console.WriteLine("Invalid input. Please enter a number.");
            }  
        }
        return duration;
    }

    static void StartingMessage(string activity, string description)
    {
        Console.Clear();
        Console.WriteLine($"This is the {activity} activity.\n{description}");
        Thread.Sleep(200);
    }
    static void EndingMessage(string title)
    {
        Console.WriteLine($"Thank you for trying the {title} activity.\n\n");
        Thread.Sleep(300);
    }

    
}