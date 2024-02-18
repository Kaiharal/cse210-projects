class Reference
{
    //using strings instead of ints, since we aren't doing any math here, and it makes it less likely to crash if someone puts in a weird input.
    private string _book;
    private string _chapter;
    private string _startVerse;
    private string _endVerse;

    public Reference(string book, string chapter, string startVerse, string endVerse)
    {
        this._book = book;
        this._chapter = chapter;
        this._startVerse = startVerse;
        this._endVerse = endVerse;
    }

    public string GetReference()
    {
        string fullReference = (_book + " " + _chapter + ":" + _startVerse + "-" + _endVerse);
        return fullReference;
    }
}