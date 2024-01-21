using System;

class Program
{
    static void Main(string[] args)
    {
        List<int> numList = new List<int>();
        Console.WriteLine("Enter a list of numbers, type 0 when finished.");
        int userInput = 1;
        int counter = 0;
        //getting the list
        while(userInput != 0){
            Console.Write("Enter number: ");
            userInput = Convert.ToInt32(Console.ReadLine());
            if(userInput == 0){
                break;
            }
            numList.Add(userInput);
            counter++;
        }
        //calculations
        int total = 0;
        int largest = 0;
        foreach(int num in numList){
            total += num;
            if(num > largest){
                largest = num;
            }
        }
        float average = total / counter;
        Console.WriteLine("The sum is " + total);
        Console.WriteLine("The average is " + average);
        Console.WriteLine("The largest number is " + largest);
    }
}