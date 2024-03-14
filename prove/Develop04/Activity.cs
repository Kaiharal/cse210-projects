using System.Diagnostics;
using System.Timers;
class Activity
{
    protected string _Title =  "Default";
    protected string _Description = "Default";

    public Activity()
    {

    }

    public string Title()
    {
        string Title = _Title;
        return Title;
    }

    public string Description()
    {
        string Description = _Description;
        return Description;
    }

    public static async void Spinner()
    {
        int counter = 0;
        bool done = false;
        while (!done)
        {
            counter++;
            switch (counter % 4)
            {
                case 0:
                    Console.Write("|");
                    break;
                case 1:
                    Console.Write("/");
                    break;
                case 2:
                    Console.Write("-");
                    break;
                case 3:
                    Console.Write("\\");
                    break;
            }
            Console.CursorLeft = Console.CursorLeft - 1;
            await Task.Delay(600);
            if (counter >= 14)
            {
                done = true;
            }
        }
        
    }
}