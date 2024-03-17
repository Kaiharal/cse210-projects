class EternalTask : Objective
{
    private int _timesCompleted;

    public EternalTask(string name, string description, bool status, int points, int timesCompleted) : base(name, description, status, points)
    {
        _timesCompleted = timesCompleted;
    }

    public override int completeTask()
    {
        _timesCompleted++;
        return _points;
    }

    public int getTimesCompleted()
    {            
        return _timesCompleted;
    }
}