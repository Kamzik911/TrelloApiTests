namespace TrelloApiTests
{
    public class SettingEndpoints
    {
        // Main endpoint
        public const string mainEndpoint = "https://api.trello.com/1";

        // Boards endpoints
        public readonly string boardsEndpoint = "/boards";

        public string BoardIdEndpoint(string boardId) => $"{boardsEndpoint}/{boardId}";

        // Labels endpoints
        public readonly string labelsEndpoint = "/labels";

        public string LabelIdEndpoint(string labelId) => $"{labelsEndpoint}/{labelId}";

        // Cards endpoints
        public readonly string cardsEndpoint = "/cards";

        public string CardsIdEndpoint(string cardId) => $"{cardsEndpoint}/{cardId}";

        // Lists endpoints
        public readonly string listsEndpoint = "/lists";

        public string ListIdEndpoint(string id) => $"{listsEndpoint}/{id}";

        public string ArchiveAllcardsEndpoint(string id) => $"{listsEndpoint}/{id}/archiveAllCards";

        public string ActionsForListEndpoint(string id) => $"{listsEndpoint}/{id}/actions";

        public string GetBoardListIsOn(string id) => $"{listsEndpoint}/{id}/board";

        public string GetCardsListIsOn(string id) => $"{listsEndpoint}/{id}/cards";

        // Custom field endpoints
        public readonly string customFieldEndpoint = "/customFields";

        public string CustomFieldIdEndpoint(string id) => $"{customFieldEndpoint}/{id}";

        // Organization endpoints
        public readonly string organizationEndpoint = "/organizations";

        public string OrganizationId(string id) => $"{organizationEndpoint}/{id}";

        public string OrganizationBoardId(string id) => $"{organizationEndpoint}/{id}/boards";

        // Calendar endpoints
        public string CalendarEndpoint(string id) => $"{boardsEndpoint}/{id}/calendarKey/generate";

        // Email endpoints
        public string EmailEndpoint(string id) => $"{boardsEndpoint}/{id}/emailKey/generate";

        // Tag endpoints
        //private readonly string tagEndopint = "/idTags";

        // MarkedAsViewed endpoints
        public string MarkedAsViewedEndpoint(string id) => $"{boardsEndpoint}/{id}/markedAsViewed";

        // Member endpoints
        private static string memberEndpoint = "/members";

        public string MemberIdEndpoint(string id) => $"{memberEndpoint}/{id}";


        public string MemberBoardBackgroundEndpoint(string id) => $"{MemberIdEndpoint(MembersProperties.id)}/boardBackgrounds/{id}";

        // Checklists endpoints
        public readonly string checklistEndpoint = "/checklists";

        public string ChecklistIdEndpoint(string id) => $"{checklistEndpoint}/{id}";

        // Notification endpoints
        private readonly string notificationBoardEndpoint = "/notifications";        

        public string NotificationIdEndpoint(string id) => $"{notificationBoardEndpoint}/{id}";

        public string NotificationBoardIdEndpoint(string id) => $"{notificationBoardEndpoint}/{id}/board";
    }
}
