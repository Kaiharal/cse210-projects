using System;

class Program
{
    static void Main(string[] args)
    {
        //prompt the user for their grade percentage
        Console.Write("Please enter your grade percentage: ");
        string grade = Console.ReadLine();
        //parse the given string for an int
        int percentage = int.Parse(grade);

        string letter = "X";

        //I know the information was about if and else, but it's better handled by a switch case in my opinion. It's less bulky, and easier to read.
        switch(percentage){
            case >= 90:
                letter = "A";
                break;
            case >= 80:
                letter = "B";
                break;
            case >= 70:
                letter = "C";
                break;
            case >= 60:
                letter = "D";
                break;
            default:
                letter = "F";
                break;
        }
        //display results
        if (percentage >= 70)
        {
            Console.WriteLine("You pass this class!");
        }
        else
        {
            Console.WriteLine("You fail this class. Try again!");
        }
        Console.WriteLine($"The grade you earned: {letter}");
    }
}