namespace TrelloApiTests
{
    public class SettingEndpoints
    {   
        //Main endpoint
        public static string mainEndpoint = "https://api.trello.com/1";

        //Cards endpoints
        public string cardsEndpoint = $"{mainEndpoint}/cards";  
        public string cardsIdEndpoint = $"{mainEndpoint}/cards/{CardProperties.CreatedCardId}";

        //Boards endpoints        
        public string boardsEndpoint = $"{mainEndpoint}/boards";
        public string boardIdEndpoint = $"{mainEndpoint}/boards/{BoardProperties.CreatedIdBoard}";

        //Labels endpoints
        public string boardLabels = $"{mainEndpoint}/labels";
        public string boardLabelId = $"{mainEndpoint}/labels/{LabelProperties.CreatedLabelId}";

        //Lists endpoints
        public string listsEndpoint = $"{mainEndpoint}/lists";
        public string listIdEndpoint = $"{mainEndpoint}/lists/{ListProperties.ListId}";

        //Calendar endpoints
        public string calendarEndpoint = $"{mainEndpoint}/boards/{BoardProperties.CreatedIdBoard}/calendarKey/generate";

        //Email endpoints
        public string emailEndpoint = $"{mainEndpoint}/boards/{BoardProperties.CreatedIdBoard}/emailKey/generate";

        //Tag endpoints
        public string tagEndopint = "/idTags";

        //MarkedAsViewed endpoints                
        public string markedAsViewedEndpoint = $"{mainEndpoint}/boards/{BoardProperties.CreatedIdBoard}/markedAsViewed";

        //Member endopoints
        public string memeberEndpoint = "/members";
    }
}
