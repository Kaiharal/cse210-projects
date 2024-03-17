abstract class Objective
{
    private string _name;
    private string _description;
    protected bool _status;
    protected int _points;

    public Objective(string name, string description, bool status, int points)
    {
        _name = name;
        _description = description;
        _status = status;
        _points = points;

    }

    public string getName()
    {
        return _name;
    }

    public string getDescription()
    {
        return _description;
    }

    public int getPoints()
    {
        return _points;
    }

    public abstract int completeTask();

    public bool getStatus()
    {
        return _status;
    }
}