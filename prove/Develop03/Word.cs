class Word
{
    private string _word;
    private bool _hidden;

    public Word(string word)
    {
        this._word = word; 
    }

    public string GetWord()
    {
        return _word;
    }

    public bool GetHidden()
    {
        return _hidden;
    }

    public void Hide()
    {
        _hidden = true;
    }
}