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
        //public string boardsEndpoint = $"{mainEndpoint}/boards";
        public string boardsEndpoint = "/boards/";
        public string boardIdEndpoint = $"/boards/{BoardProperties.CreatedIdBoard}";

        //Labels endpoints
        public string boardLabels = $"/labels/";
        public string boardLabelId = $"/labels/{LabelProperties.CreatedLabelId}";

        //Lists endpoints
        public string listsEndpoint = $"/lists/";
        public string listIdEndpoint = $"/lists/{ListProperties.ListId}";
        public string archiveAllcardsEndpoint = $"/lists/{ListProperties.ListId}/archiveAllCards";

        //Custom field endpoints
        public string customFieldEndpoint = $"/customFields/";
        public string customFieldIdEndpoint = $"/customFields/{CustomFieldProperties.CustomFieldId}";

        //Calendar endpoints
        public string calendarEndpoint = $"/boards/{BoardProperties.CreatedIdBoard}/calendarKey/generate";

        //Email endpoints
        public string emailEndpoint = $"/boards/{BoardProperties.CreatedIdBoard}/emailKey/generate";

        //Tag endpoints
        public string tagEndopint = "/idTags";

        //MarkedAsViewed endpoints                
        public string markedAsViewedEndpoint = $"/boards/{BoardProperties.CreatedIdBoard}/markedAsViewed";

        //Member endopoints
        public string memeberEndpoint = "/members";        
    }

    public static class MainEndpoint
    {
        public static RestClient Client { get; } = new RestClient(SettingEndpoints.mainEndpoint);
    }
}
