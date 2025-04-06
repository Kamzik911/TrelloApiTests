namespace TrelloApiTests
{
    public class SettingEndpoints
    {
        //Main endpoint
        public static string mainEndpoint = "https://api.trello.com/1";        
        
        //Boards endpoints        
        //public string boardsEndpoint = $"{mainEndpoint}/boards";
        public string boardsEndpoint = "/boards/";
        public string boardIdEndpoint = $"/boards/{ObjectProperties.BoardProperties.CreatedIdBoard}";

        //Labels endpoints
        public string boardLabels = $"/labels/";
        public string boardLabelId = $"/labels/{ObjectProperties.LabelProperties.CreatedLabelId}";

        //Cards endpoints
        public string cardsEndpoint = "/cards";
        public string cardsIdEndpoint = $"/cards/{ObjectProperties.CardProperties.CreatedCardId}";

        //Lists endpoints
        public string listsEndpoint = $"/lists/";
        public string listIdEndpoint = $"/lists/{ObjectProperties.ListProperties.ListId}";
        public string archiveAllcardsEndpoint = $"/lists/{ObjectProperties.ListProperties.ListId}/archiveAllCards";

        //Custom field endpoints
        public string customFieldEndpoint = $"/customFields/";
        public string customFieldIdEndpoint = $"/customFields/{ObjectProperties.CustomFieldProperties.CustomFieldId}";

        //Calendar endpoints
        public string calendarEndpoint = $"/boards/{ObjectProperties.BoardProperties.CreatedIdBoard}/calendarKey/generate";

        //Email endpoints
        public string emailEndpoint = $"/boards/{ObjectProperties.BoardProperties.CreatedIdBoard}/emailKey/generate";

        //Tag endpoints
        public string tagEndopint = "/idTags";

        //MarkedAsViewed endpoints                
        public string markedAsViewedEndpoint = $"/boards/{ObjectProperties.BoardProperties.CreatedIdBoard}/markedAsViewed";

        //Member endopoints
        public string memeberEndpoint = "/members";        
    }

    public class MainRestApiUrl
    {
        public static RestClient Client { get; } = new RestClient(SettingEndpoints.mainEndpoint);                
    }    
}
