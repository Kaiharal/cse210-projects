public class Rectangle : Shape
{
    private float _width = 0f;
    private float _height = 0f;

    public Rectangle(string color, float width, float height) : base(color)
    {
        _width = width;
        _height = height;
    }

    public override float GetArea()
    {
        return _width * _height;
    }
}