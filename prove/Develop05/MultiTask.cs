class MultiTask : Objective
{
    private int _goalNumber;
    private int _progressNumber;
    private int _bonusPoints;

    public MultiTask(string name, string description, bool status, int points, int goalNumber, int bonusPoints, int progressNumber) : base(name, description, status, points)
    {
        _goalNumber = goalNumber;
        _progressNumber = 0;
        _bonusPoints = bonusPoints;
        _progressNumber = progressNumber;
   
    }

    public override int completeTask()
        {
            int total = 0;
            if (_progressNumber < _goalNumber)
            {
                _progressNumber++;
                total = _points;
                if (_progressNumber == _goalNumber)
                {
                _status = true;
                total = _points + _bonusPoints;
                }
                return total;
            }
            else
            {
                return 0;
            }
        }

    public int getProgressNumber()
    {
        return _progressNumber;
    }

    public int getGoalNumber()
    {
        return _goalNumber;
    }

    public int getBonusPoints()
    {
        return _bonusPoints;
    }
}