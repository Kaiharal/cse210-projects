using System;

class Program
{
    //looking over the sample solution after the face, I think that Codeium pulled a lot of the autofill from the sample solution on github.
    //Funny how that works, although with how straightforward the assignment was, I guess it was going to look similar either way?
    static void Main(string[] args)
    {
        Console.Write("Name: ");
        string name = Console.ReadLine();
        Console.Write("Topic: ");
        string topic = Console.ReadLine();

        Assignment myAssignment = new Assignment(name, topic);
        Console.WriteLine(myAssignment.GetSummary());
        Console.WriteLine();

        MathAssignment myMath = new MathAssignment(name, topic, "Section 4.2", "Problems 2-10");
        Console.WriteLine(myMath.GetSummary());
        Console.WriteLine(myMath.GetHomeworkList());
        Console.WriteLine();

        WritingAssignment myWriting = new WritingAssignment(name, topic, "Placeholder Book Title.");
        Console.WriteLine(myWriting.GetSummary());
        Console.WriteLine(myWriting.GetWritingInformation());
    }
}