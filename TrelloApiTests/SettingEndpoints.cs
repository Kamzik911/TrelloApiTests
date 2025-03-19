namespace TrelloApiTests
{
    public class SettingEndpoints
    {
        //Main endpoint
        public static string mainEndpoint = "https://api.trello.com/1";
        public string trelloEndpoint = $"{mainEndpoint}";

        //Cards endpoints
        public string cardsEndpoint = $"{mainEndpoint}/cards";

        //Boards endpoints        
        public string boardsEndpoint = $"{mainEndpoint}/boards";

        //Lists endpoints
        public string listsEndpoint = $"{mainEndpoint}/lists";

        //Calendar endpoints
        public string calendarEndpoint = $"{mainEndpoint}/generate";

        //Email endpoints
        public string emailEndpoint = "emailKey/generate";

        //Tag endpoints
        public string tagEndopint = $"{mainEndpoint}/idTags";

        //MarkedAsViewed endpoints        
        public string markedAsViewedEndpoint = "markedAsViewed";

        //Member endopoints
        public string memeberEndpoint = $"{mainEndpoint}/members";
    }
}
