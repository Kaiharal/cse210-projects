class OneTask : Objective
{
    
    public OneTask(string name, string description, bool status, int points) : base(name, description, status, points)
    {

    }

    public override int completeTask()
    {
        if (!this._status)
        {
            this._status = true;
            return this._points;
        }
        else
        {
            return 0;
        }

    }
    
}
