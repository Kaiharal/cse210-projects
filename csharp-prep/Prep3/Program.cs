using System;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Guess a number between 0 and 100!");
        Random rnd = new Random();
        int num = rnd.Next(100);

        bool guessed = false;    
        int guess;
        while(!guessed){
            guess = Convert.ToInt32(Console.ReadLine());
            if(guess < num){
                Console.WriteLine("Too Low!");
            }
            if(guess > num){
                Console.WriteLine("Too High!");
            }
            if(guess == num){
                guessed = true;
            }    
        }
        Console.WriteLine("Correct!");
    }
}