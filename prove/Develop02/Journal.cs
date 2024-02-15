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
