class PromptGenerator
{
    private static List<string> prompts = new List<string>()
    {
        "Who was the most interesting person I interacted with today?",
        "What was the best part of my day?",
        "How did I see the hand of the Lord in my life today?",
        "What was the strongest emotion I felt today?",
        "If I had one thing I could do over today, what would it be?",
        "What ordinary things do I appreciate the most?",
        "What was something I want to improve on?",
        "What was something exciting that happened today?",
        "What was something I learned today?"
    };

    public static string GeneratePrompt()
    {
        Random random = new Random();
        int index = random.Next(prompts.Count);
        return prompts[index];
    }
}
