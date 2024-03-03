using System;
using System.Configuration.Assemblies;


//used to decide how much of the scripture to black out
class Program
{
    static void Main()
    {
        //explain the program
        Console.WriteLine("Welcome to the Scripture Mastery Program!");
        Console.WriteLine("Please enter the Book of the Scripture you would like to memorize.");
        string book =  Console.ReadLine();
        Console.WriteLine("Please enter the chapter of the scripture you would like to memorize.");
        string chapter = Console.ReadLine();
        Console.WriteLine("Please enter the first verse of the scripture you would like to memorize.");
        string startVerse = Console.ReadLine();
        Console.WriteLine("Please enter the last verse of the scripture you would like to memorize. (If it is only one verse, you may enter the same verse number, or leave it blank.)");
        string endVerse = Console.ReadLine();
        Console.WriteLine("Please enter the words of the scripture you would like to memorize. ");
        string words = Console.ReadLine();
        Scripture Quiz = new Scripture(book, chapter, startVerse, endVerse, words);
        Reference reference = Quiz.GetReference();

        //start the quiz
        Console.Clear();
        Console.WriteLine("Press Enter to continue, and enter QUIT at any time to exit.");
        Console.WriteLine(reference.GetReference());
        Console.WriteLine(words);     //display full scripture.
        string choice = "default";
        int totalwords = Quiz.GetWordCount(); //counter too keep track of when you're finished
        while (choice != "QUIT" && totalwords != 0)
        {    
            choice = Console.ReadLine();
            Console.Clear();

            if (choice == "")
            {
                choice = "default";
                bool increased = false; //makes sure that a new words is blacked out each time
                while (increased == false)
                {
                    Random random = new Random();
                    int toHide = random.Next(0,Quiz.GetWordCount());
                    if (Quiz.GetWords()[toHide].GetHidden() == false) 
                    //makes sure that the randomly generated number doesn't relate to an already hidden word
                    {
                        Quiz.GetWords()[toHide].Hide();
                        increased = true;
                        totalwords--;
                        Console.WriteLine(reference.GetReference());
                        foreach(Word word in Quiz.GetWords())
                        {
                            if (word.GetHidden() == false)
                            {
                                Console.Write(word.GetWord() + " ");
                            }
                            else
                            {
                                //replaces hidden words with an equal number of underscores.
                                int underscores = word.GetWord().Length;
                                for(int i = 0; i < underscores; i++)
                                {
                                    Console.Write("_");
                                }
                                Console.Write(" ");
                            }
                        }
                        Console.WriteLine();
                    }
                }

            }
            else if(choice == "QUIT")
            {
                break;
            }
        }

        Console.WriteLine("\n\nThank you for using the Scripture Mastery Program!");
    }

}