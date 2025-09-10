namespace TrelloApiTests.Utils
{
    public class EndpointsSetup
    {
        // Main endpoint
        public const string mainEndpoint = "https://api.trello.com/1";

        // Boards endpoints
        public readonly string boardsEndpoint = "/boards";
                
        public string BoardIdEndpoint(string boardId)
        {
            return $"{boardsEndpoint}/{boardId}";
        }
        // Board membership endpoints
        public string MembershipEndpoint(string boardId)
        {
            return $"{BoardIdEndpoint(boardId)}/memberships";            
        }

        // Labels endpoints
        public readonly string labelsEndpoint = "/labels";

        public string LabelIdEndpoint(string labelId)
        {
            return $"{labelsEndpoint}/{labelId}";
        }

        // Cards endpoints
        public readonly string cardsEndpoint = "/cards";

        public string CardsIdEndpoint(string cardId)
        {
            return $"{cardsEndpoint}/{cardId}";
        }

        // Lists endpoints
        public readonly string listsEndpoint = "/lists";

        public string ListIdEndpoint(string id)
        {
            return $"{listsEndpoint}/{id}";
        }

        public string ArchiveAllcardsEndpoint(string id)
        {
            return $"{listsEndpoint}/{id}/archiveAllCards";
        }

        public string ActionsForListEndpoint(string id)
        {
            return $"{listsEndpoint}/{id}/actions";
        }

        public string GetBoardListIsOn(string id)
        {
            return $"{listsEndpoint}/{id}/board";
        }

        public string GetCardsListIsOn(string id)
        {
            return$"{listsEndpoint}/{id}/cards";
        }
        // Custom field endpoints
        public readonly string customFieldEndpoint = "/customFields";

        public string CustomFieldIdEndpoint(string id)
        {
            return $"{customFieldEndpoint}/{id}";
        }

        // Organization endpoints
        public readonly string organizationEndpoint = "/organizations";

        public string OrganizationId(string id)
        {
            return $"{organizationEndpoint}/{id}";
        }

        public string OrganizationBoardId(string id)
        {
            return $"{organizationEndpoint}/{id}/boards";
        } 
        // Calendar endpoints
        public string CalendarEndpoint(string id)
        {
            return $"{boardsEndpoint}/{id}/calendarKey/generate";
        }
        // Email endpoints
        public string EmailEndpoint(string id)
        {
            return $"{boardsEndpoint}/{id}/emailKey/generate";
        }

        // Tag endpoints
        //private string tagEndopint = "/idTags";

        // MarkedAsViewed endpoints
        //https://api.trello.com/1/boards/{id}/markedAsViewed?key=APIKey&token=APIToken
        public string MarkedAsViewedEndpoint(string id)
        {
            return $"{boardsEndpoint}/{id}/markedAsViewed";
        }

        // Member endpoints
        private static string memberEndpoint = "/members";

        public string MemberIdEndpoint(string id)
        {
            return $"{memberEndpoint}/{id}";
        }

        public string MemberBoardBackgroundEndpoint(string id)
        {
            return $"{MemberIdEndpoint(MembersProperties.id)}/boardBackgrounds/{id}";
        }

        // Checklists endpoints
        public readonly string checklistEndpoint = "/checklists";

        public string ChecklistIdEndpoint(string id)
        {
            return $"{checklistEndpoint}/{id}";
        }

        // Notification endpoints
        private readonly string notificationBoardEndpoint = "/notifications";        

        public string NotificationIdEndpoint(string id)
        {
            return$"{notificationBoardEndpoint}/{id}";
        }

        public string NotificationBoardIdEndpoint(string id)
        {
            return $"{notificationBoardEndpoint}/{id}/board";
        }
    }
    public class MainRestApiUrl : EndpointsSetup
    {
        public static RestClient Client { get; } = new RestClient(mainEndpoint);
    }

}
