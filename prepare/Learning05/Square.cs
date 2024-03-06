public class Square : Shape
{
    private float _side = 0f;
    public Square(string color, float side) : base(color)
    {
        _side = side;
    }

    public override float GetArea()
    {
        return _side * _side;
    }

}