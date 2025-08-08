namespace TrelloApiTests
{
    public class SettingEndpoints
    {
        // Main endpoint
        public static string mainEndpoint = "https://api.trello.com/1";

        // Boards endpoints
        public string boardsEndpoint = "/boards";

        public string BoardIdEndpoint(string boardId) => $"{this.boardsEndpoint}/{boardId}";

        // Labels endpoints
        public readonly string labelsEndpoint = "/labels";

        public string LabelIdEndpoint(string labelId) => $"{this.labelsEndpoint}/{labelId}";

        // Cards endpoints
        public readonly string cardsEndpoint = "/cards";

        public string CardsIdEndpoint(string cardId) => $"{this.cardsEndpoint}/{cardId}";

        // Lists endpoints
        private readonly string listsEndpoint = "/lists";

        public string ListIdEndpoint(string id) => $"{this.listsEndpoint}/{id}";

        public string ArchiveAllcardsEndpoint(string id) => $"{this.listsEndpoint}/{id}/archiveAllCards";

        public string ActionsForListEndpoint(string id) => $"{this.listsEndpoint}/{id}/actions";

        public string GetBoardListIsOn(string id) => $"{this.listsEndpoint}/{id}/board";

        public string GetCardsListIsOn(string id) => $"{this.listsEndpoint}/{id}/cards";

        // Custom field endpoints
        public string customFieldEndpoint = "/customFields";

        public string CustomFieldIdEndpoint(string id) => $"{this.customFieldEndpoint}/{id}";

        // Organization endpoints
        public readonly string organizationEndpoint = "/organizations";

        public string OrganizationId(string id) => $"{this.organizationEndpoint}/{id}";

        public string OrganizationBoardId(string id) => $"{this.organizationEndpoint}/{id}/boards";

        // Calendar endpoints
        public string CalendarEndpoint(string id) => $"{this.boardsEndpoint}/{id}/calendarKey/generate";

        // Email endpoints
        public string EmailEndpoint(string id) => $"{this.boardsEndpoint}/{id}/emailKey/generate";

        // Tag endpoints
        private readonly string tagEndopint = "/idTags";

        // MarkedAsViewed endpoints
        public string MarkedAsViewedEndpoint(string id) => $"{this.boardsEndpoint}/{id}/markedAsViewed";

        // Member endpoints
        private static string memberEndpoint = "/members";

        public string MemberIdEndpoint(string id) => $"{memberEndpoint}/{id}";

        public string MemberBoardBackgroundEndpoint(string id) => $"{this.MemberIdEndpoint(MembersProperties.id)}/boardBackgrounds/{id}";

        // Checklists endpoints
        public string checklistEndpoint = "/checklists";

        public string ChecklistIdEndpoint(string id) => $"{this.checklistEndpoint}/{id}";

        // Notification endpoints
        private readonly string notificationBoardEndpoint = "/notifications";

        public string NotificationIdEndpoint(string id) => $"{this.notificationBoardEndpoint}/{id}";

        public string NotificationBoardIdEndpoint(string id) => $"{this.notificationBoardEndpoint}/{id}/board";
    }
}
