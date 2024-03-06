using System;

class Program
{
    static void Main(string[] args)
    {

        List<Shape> shapes = new List<Shape>();

        shapes.Add(new Circle("green", 10f));
        shapes.Add(new Square("blue", 10f));
        shapes.Add(new Rectangle("orange", 10f, 15f));

        foreach (Shape shape in shapes)
        {
            Console.WriteLine($"{shape.GetColor()}, {shape.GetArea()}");
        }


    }
}