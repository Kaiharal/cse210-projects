using System;
class Program
{
    static void Main(string[] args)
    {
        //the Program class is basically just the menu, with the Journal class handling most of the actual options.
        Journal journal = new Journal();
        bool activeloop = true;
        while (activeloop)
        {
            Console.WriteLine("1. Write a new entry");
            Console.WriteLine("2. Display the journal");
            Console.WriteLine("3. Save the journal to a file");
            Console.WriteLine("4. Load the journal from a file");
            Console.WriteLine("5. Exit");
            Console.Write("Choose an option: ");
            string menu = Console.ReadLine();

            switch (menu)
            {
                case "1":
                    journal.AddEntry(PromptGenerator.GeneratePrompt(), DateTime.Now.ToString("yyyy-MM-dd"));
                    break;
                case "2":
                    journal.DisplayEntries();
                    break;
                case "3":
                    journal.SaveToFile();
                    break;
                case "4":
                    journal.LoadFromFile();
                    break;
                case "5":
                    activeloop = false;
                    break;
                default:
                    Console.WriteLine("Invalid input. Please enter a number between 1 and 5.");
                    break;
            }
        }
    }
}

class Journal
{
    private List<NewEntry> entries = new List<NewEntry>();

    public void AddEntry(string prompt, string date)
    {
        Console.WriteLine(prompt);
        string response = Console.ReadLine();
        entries.Add(new NewEntry(prompt, response, date));
    }

    public void DisplayEntries()
    {
        foreach (var entry in entries)
        {
            Console.WriteLine($"Date: {entry.Date}");
            Console.WriteLine($"Prompt: {entry.Prompt}");
            Console.WriteLine($"Entry: {entry.Response}");
            Console.WriteLine();
        }
    }

    public void SaveToFile()
    {
        Console.Write("Enter the name of the file to save your journal to: ");
        string filename = Console.ReadLine();
        using (StreamWriter file = new StreamWriter(filename))
        {
            foreach (var entry in entries)
            {
                file.WriteLine($"{entry.Date}~|~{entry.Prompt}~|~{entry.Response}");
            }
        }
    }

    public void LoadFromFile()
    {
        Console.Write("Enter a filename to load: ");
        string filename = Console.ReadLine();
        entries.Clear();
        using (StreamReader file = new StreamReader(filename))
        {
            string line;
            while ((line = file.ReadLine()) != null)
            {
                string[] parts = line.Split(new string[] { "~|~" }, StringSplitOptions.None);
                entries.Add(new NewEntry(parts[1], parts[2], parts[0]));
            }
        }
    }
}

class PromptGenerator
{
    private static List<string> prompts = new List<string>()
    {
        "Who was the most interesting person I interacted with today?",
        "What was the best part of my day?",
        "How did I see the hand of the Lord in my life today?",
        "What was the strongest emotion I felt today?",
        "If I had one thing I could do over today, what would it be?",
        "What ordinary things do I appreciate the most?",
        "What was something I want to improve on?",
        "What was something exciting that happened today?",
        "What was something I learned today?"
    };

    public static string GeneratePrompt()
    {
        Random random = new Random();
        int index = random.Next(prompts.Count);
        return prompts[index];
    }
}

class NewEntry
{
    public string Prompt { get; private set; }
    public string Response { get; private set; }
    public string Date { get; private set; }

    public NewEntry(string prompt, string response, string date)
    {
        Prompt = prompt;
        Response = response;
        Date = date;
    }
}
