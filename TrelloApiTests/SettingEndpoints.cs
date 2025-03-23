namespace TrelloApiTests
{
    public class SettingEndpoints
    {   
        //Main endpoint
        public static string mainEndpoint = "https://api.trello.com/1";

        //Cards endpoints
        public string cardsEndpoint = $"{mainEndpoint}/cards";        

        //Boards endpoints        
        public string boardsEndpoint = $"{mainEndpoint}/boards";
        public string boardIdEndpoint = $"{mainEndpoint}/boards/{SettingProperties.CreatedIdBoard}";

        //Labels endpoints
        public string boardLabels = $"{mainEndpoint}/labels";

        //Lists endpoints
        public string listsEndpoint = $"{mainEndpoint}/lists?name=name";

        //Calendar endpoints
        public string calendarEndpoint = $"{mainEndpoint}/boards/{SettingProperties.CreatedIdBoard}/calendarKey/generate";

        //Email endpoints
        public string emailEndpoint = $"{mainEndpoint}/boards/{SettingProperties.CreatedIdBoard}/emailKey/generate";

        //Tag endpoints
        public string tagEndopint = "/idTags";

        //MarkedAsViewed endpoints        
        //--url 'https://api.trello.com/1/boards/{id}/markedAsViewed?key=APIKey&token=APIToken'
        public string markedAsViewedEndpoint = $"{mainEndpoint}/boards/{SettingProperties.CreatedIdBoard}/markedAsViewed";

        //Member endopoints
        public string memeberEndpoint = "/members";
    }
}
