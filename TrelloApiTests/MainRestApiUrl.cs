namespace TrelloApiTests
{
    public class MainRestApiUrl : SettingEndpoints
    {
        public static RestClient Client { get; } = new RestClient(mainEndpoint);
    }
}
