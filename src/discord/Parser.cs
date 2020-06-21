using System.Text.RegularExpressions;


namespace Parse
{

    public static class Parser
    {


        
        public static string getDealForumThreadNumber(string url)
        {
            return Regex.Match(url, "\\d+$").Value;

        }
        



    }


}