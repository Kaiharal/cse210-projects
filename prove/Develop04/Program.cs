using System;
using System.ComponentModel.Design;

class Program
{
    
    static int _countdown = 120; //placeholder variable, test out later
    private int _requestedDuration; //assigned further down, each loop

    void Main() //menu
    {  
        
        Console.WriteLine("Welcome to the Mindfulness program. Please select one of the following options:");
        int choice = Menu();
        bool done = false;
        while(!done)
        {
           switch(choice)
            {
                case 1:
                    //for each case...
                    //call StartingMessage() with some variable relating to the type of activity
                    //create a new class object for the activity chosen
                    //call the activity method
                    break;
                case 2:
                    //do reflection
                    break;
                case 3:
                    //do listing
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
        Console.WriteLine("1: Breathing Activity");
        Console.WriteLine("2: Reflection Activity");
        Console.WriteLine("3: Listing Activity");
        Console.WriteLine("4: Quit");

        while(choice == 0)
        {
            try
            {
             choice = int.Parse(Console.ReadLine());
            }
            catch (FormatException)
            {
                Console.WriteLine("Invalid input. Please enter a number between 1 and 4.");
            }
        }


        return choice;
    }

    static void StartingMessage()
    {
        // this should adjust to introduce each type of activity, 
        //and also prompt for the duration of any activity.

    }
    static void EndingMessage()
    {
        //pretty straightforward.
    }

    static void Spinner()
    {

    }


}