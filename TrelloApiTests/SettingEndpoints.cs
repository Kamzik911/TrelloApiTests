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
        public string listsEndpoint = "/lists";
        public string listIdEndpoint(string id) => $"{listsEndpoint}/{id}";
        public string archiveAllcardsEndpoint(string id) => $"{listsEndpoint}/{id}/archiveAllCards";
        public string actionsForListEndpoint(string id) => $"{listsEndpoint}/{id}/actions";
        public string getBoardListIsOn(string id) => $"{listsEndpoint}/{id}/board";
        public string getCardsListIsOn(string id) => $"{listsEndpoint}/{id}/cards";

        //Custom field endpoints
        public string customFieldEndpoint = "/customFields/";
        public string CustomFieldIdEndpoint(string id) => $"{customFieldEndpoint}/{id}";

        //Organization endpoints
        public static string organizationEndpoint = "/organizations";
        public string organizationId(string id) => $"{organizationEndpoint}/{id}";
        public string organizationBoardId(string id) => $"{organizationEndpoint}/{id}/boards";

        //Calendar endpoints        
        public string CalendarEndpoint(string id) => $"{boardsEndpoint}/{id}/calendarKey/generate";

        //Email endpoints
        public string EmailEndpoint(string id) => $"{boardsEndpoint}/{id}/emailKey/generate";

        //Tag endpoints
        public string tagEndopint = "/idTags";

        //MarkedAsViewed endpoints                
        public string markedAsViewedEndpoint(string id) => $"{boardsEndpoint}/{id}/markedAsViewed";

        //Member endpoints
        public static string memberEndpoint = "/members";
        public string memberIdEndpoint(string id) => $"{memberEndpoint}/{id}";
        public string memberBoardBackgroundEndpoint(string id) => $"{memberIdEndpoint(MembersProperties.id)}/boardBackgrounds/{id}";

        //Checklists endpoints
        public static string checklistEndpoint = "/checklists";
        public string ChecklistIdEndpoint(string id) => $"{checklistEndpoint}/{id}";

        //Notification endpoints
        public static string notificationBoardEndpoint = "/notifications";
        public string NotificationIdEndpoint(string id) => $"{notificationBoardEndpoint}/{id}";
        public string NotificationBoardIdEndpoint(string id) => $"{notificationBoardEndpoint}/{id}/board";
    }

    public class MainRestApiUrl
    {
        public static RestClient Client { get; } = new RestClient(SettingEndpoints.mainEndpoint);                
    }    
}
