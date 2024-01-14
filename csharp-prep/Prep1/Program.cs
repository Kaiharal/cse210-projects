using System;

class Program
{
    static void Main(string[] args)
    {
        //prompt user for their first and last names
        Console.Write("What is your first name? ");
        string firstname = Console.ReadLine();
        Console.Write("What is your last name? ");
        string lastname = Console.ReadLine();

        //repeat it back to them
        Console.WriteLine($"Your name is {lastname}, {firstname} {lastname}.");
    }
}