using System;

class Scripture
{
    private List<Word> _words;
    private Reference _references;

    public Scripture(string book, string chapter, string startVerse, string endVerse, string words)
    {
        //initialize classes
        this._references = new Reference(book, chapter, startVerse, endVerse);
        this._words = new List<Word>();
        //Create a list of Word objects from the given string
        string[] wordsList = words.Split(' ');
        foreach (string text in wordsList)
        {
            this._words.Add(new Word(text));
        }
    }

    public int GetWordCount()
    {
        int count = _words.Count;
        return count;
    }

    public List<Word> GetWords()
    {
        return _words;
    }

    public Reference GetReference()
    {
        return _references;
    }
}