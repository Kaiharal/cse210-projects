using System.Diagnostics;
using System.Timers;

class Listing : Activity
{
    
    
    private static List<string> _prompts = new List<string>
    {
        "Who are people that you appreciate?",
        "What are personal strengths of yours?",
        "Who are people that you have helped this week?",
        "When have you felt the Holy Ghost this month?",
        "Who are some of your personal heroes?"
    };


    public Listing()
    {
        _Title = "Listing";
        _Description = "This activity will help you reflect on the good things in your life by having you list as many things as you can in a certain area.";
    
    }

    public string GetPrompt()
    {
        Random random = new Random();
        int index = random.Next(_prompts.Count);
        return _prompts[index];
    }

    public Task Start(int duration)
    {
        var activityDuration = new Stopwatch();
        activityDuration.Start();
        List<string> userList = new List<string>();

        Thread.Sleep(500);
        Console.WriteLine(GetPrompt());
        while (activityDuration.Elapsed < TimeSpan.FromSeconds(duration))
        {
            userList.Add(Console.ReadLine());
        }
        Console.WriteLine($"You listed {userList.Count} answers!");
        activityDuration.Stop();
        return Task.CompletedTask;
        
    }

}