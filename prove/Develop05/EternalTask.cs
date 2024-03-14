class EternalTask : Objective
{
    private int _timesCompleted;

    public EternalTask(string name, string description, bool status, int points) : base(name, description, status, points)
    {
        _timesCompleted = 0;

        public override int completeTask()
        {

        }

        public int getTimesCompleted()
        {
            return _timesCompleted;
        }
    }
}