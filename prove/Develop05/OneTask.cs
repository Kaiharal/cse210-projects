class OneTask : Objective
{
    public OneTask(string name, string description, bool status, int points) : base(name, description, status, points)
    {
        public override int completeTask()
        {
            
        }

        public bool getStatus()
        {
            return _status;
        }
    }
}