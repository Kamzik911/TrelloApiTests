namespace TrelloApiTests
{
    public class SettingEndpoints
    {
        //Main endpoint
        public static string mainEndpoint = "https://api.trello.com/1";

        //Boards endpoints                
        public string boardsEndpoint = "/boards";
        public string boardIdEndpoint(string boardId) => $"{boardsEndpoint}/{boardId}";

        //Labels endpoints
        public string labelsEndpoint = "/labels";
        public string LabelIdEndpoint(string labelId) => $"{labelsEndpoint}/{labelId}";

        //Cards endpoints
        public string cardsEndpoint = "/cards";
        public string cardsIdEndpoint(string cardId) => $"{cardsEndpoint}/{cardId}";

        //Lists endpoints
        public string listsEndpoint = $"/lists";
        public string listIdEndpoint(string id) => $"{listsEndpoint}/{id}";
        public string archiveAllcardsEndpoint(string id) => $"{listsEndpoint}/{id}/archiveAllCards";
        public string actionsForListEndpoint(string id) => $"{listsEndpoint}/{id}/actions";
        public string getBoardListIsOn(string id) => $"{listsEndpoint}/{id}/board";
        public string getCardsListIsOn(string id) => $"{listsEndpoint}/{id}/cards";

        //Custom field endpoints
        public string customFieldEndpoint = $"/customFields/";
        public string CustomFieldIdEndpoint(string id) => $"{customFieldEndpoint}/{id}";

        //Calendar endpoints        
        public string CalendarEndpoint(string id) => $"{boardsEndpoint}/{id}/calendarKey/generate";

        //Email endpoints
        public string EmailEndpoint(string id) => $"{boardsEndpoint}/{id}/emailKey/generate";

        //Tag endpoints
        public string tagEndopint = "/idTags";

        //MarkedAsViewed endpoints                
        public string markedAsViewedEndpoint(string id) => $"{boardsEndpoint}/{id}/markedAsViewed";

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
