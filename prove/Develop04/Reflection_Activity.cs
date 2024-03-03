class Reflection
{
    private static List<string> _prompts = new List<string>
    {
        //prompts
    };

    private static List<string> _questions = new List<string>
    {
        //questions
    };

    public Reflection(List<string> prompts, List<string> questions)
    {
        _prompts = prompts;
        _questions = questions;
    } //not sure about how the usage of this one is, give it another look over later.
}