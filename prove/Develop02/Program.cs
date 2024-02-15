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
