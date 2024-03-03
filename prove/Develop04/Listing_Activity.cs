class Listing
{
    private static List<string> _prompts = new List<string>
    {
        //prompts go here
    };

    private List<string> _UserList;

    public Listing(List<string> prompts, List<string> userlist)
    {
        _prompts = prompts;
        _UserList = userlist;
    }

}