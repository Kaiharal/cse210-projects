using System.Diagnostics;
using System.Timers;
class Breathing : Activity
{
    
    public Breathing()
    { 
       _Title = "Breathing";
       _Description = "This activity will help you relax by walking your through breathing in and out slowly. Clear your mind and focus on your breathing.";
    }


    public Task Start(int duration)
    {
        var activityDuration = new Stopwatch();
        activityDuration.Start();
        int count = 8;
        string command = "Breathe in...";

        while (activityDuration.Elapsed < TimeSpan.FromSeconds(duration))
        {
            Console.WriteLine(command);
            Thread.Sleep(1000);
            while (count > 0 && (activityDuration.Elapsed < TimeSpan.FromSeconds(duration)))
            {
                Console.WriteLine($"{count}...");
                Thread.Sleep(1000);
                count--;        
            }
            count = 8;
            if (command == "Breathe in...")
            {
                command = "Breathe out...";
            }
            else
            {
                command = "Breathe in...";
            }
            
        }
        activityDuration.Stop();
        return Task.CompletedTask;
    }

}