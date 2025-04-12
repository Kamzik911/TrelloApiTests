namespace TrelloApiTests
{
    public class SettingEndpoints
    {
        //Main endpoint
        public static string mainEndpoint = "https://api.trello.com/1";

        //Boards endpoints                
        public string boardsEndpoint = "/boards/";
        public string boardIdEndpoint(string boardId) => $"/boards/{boardId}";

        //Labels endpoints
        public string labelsEndpoint = "/labels";
        public string LabelIdEndpoint(string labelId) => $"/labels/{labelId}";

        //Cards endpoints
        public string cardsEndpoint = "/cards";
        public string cardsIdEndpoint(string cardId) => $"/cards/{cardId}";

        //Lists endpoints
        public string listsEndpoint = $"/lists";
        public string listIdEndpoint(string id) => $"/lists/{id}";
        public string archiveAllcardsEndpoint(string id) => $"/lists/{id}/archiveAllCards";

        //Custom field endpoints
        public string customFieldEndpoint = $"/customFields/";
        public string CustomFieldIdEndpoint(string id) => $"/customFields/{id}";

        //Calendar endpoints        
        public string CalendarEndpoint(string id) => $"/boards/{id}/calendarKey/generate";

        //Email endpoints
        public string EmailEndpoint(string id) => $"/boards/{id}/emailKey/generate";

        //Tag endpoints
        public string tagEndopint = "/idTags";

        //MarkedAsViewed endpoints                
        public string markedAsViewedEndpoint = $"/boards/{ObjectProperties.BoardProperties.CreatedIdBoard}/markedAsViewed";

        //Member endpoints
        public string memeberEndpoint = "/members";

        //Checklists endpoints
        public string checklistEndpoint = "/checklists/";
        public string ChecklistIdEndpoint(string id) => $"/checklists/{id}";
    }

    public class MainRestApiUrl
    {
        public static RestClient Client { get; } = new RestClient(SettingEndpoints.mainEndpoint);                
    }    
}
