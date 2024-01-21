using System;
using System.Globalization;
using System.IO.Compression;

class Program
{
    static void Main(string[] args)
    {
        DisplayWelcome();
        string name = PromptUserName();
        int num = PromptUserNumber();
        int squared = SquareNumber(num);
        DisplayResult(squared, name);
    }
    
    static void DisplayWelcome(){
        Console.WriteLine("Welcome to the program!");
    }

    static string PromptUserName(){
        Console.Write("Please enter your name: ");
        string name = Console.ReadLine();
        return(name);
    }

    static int PromptUserNumber(){
        Console.Write("Please enter your favorite number: ");
        int favnum = Convert.ToInt32(Console.ReadLine());
        return(favnum);
    }

    static int SquareNumber(int num){
        int numnum = num*num;
        return(numnum);
    }

    static void DisplayResult(int squared, string name){
        Console.WriteLine(name + ", the square of your favorite number is " + squared);
    }
}