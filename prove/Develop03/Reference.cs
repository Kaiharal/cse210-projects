class Reference
{
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