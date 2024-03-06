public class Circle : Shape
{
    private float _radius = 0f;

    public Circle(string color, float radius) : base(color)
    {
        _radius = radius;
    }

    public override float GetArea()
    {
        return 3.14f * _radius * _radius;
    }
}