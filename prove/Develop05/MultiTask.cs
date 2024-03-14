class MultiTask : Objective
{
    private int _goalNumber;
    private int _progressNumber;
    private int _bonusPoints

    public MultiTask(string name, string description, bool status, int points, int goalNumber, int bonusPoints) : base(name, description, status, points)
    {
        _goalNumber = goalNumber;
        _progressNumber = 0;
        _bonusPoints = bonusPoints;

        public override int completeTask()
        {

        }

        public int getProgressNumber()
        {
            return _progressNumber;
        }

        public int getGoalNumber()
        {
            return _goalNumber;
        }
    }
}