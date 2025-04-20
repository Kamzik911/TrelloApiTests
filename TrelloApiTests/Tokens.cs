namespace TrelloApiTests
{
    public class Tokens
    {
        static string[] lines = File.ReadAllLines("Credentials.txt");
        public static string trelloApiKey = lines[0];
        public static string trelloApiToken = lines[1];
        public static string memberId = lines[2];
        public static string calendarKey = lines[3];
    }    
}
