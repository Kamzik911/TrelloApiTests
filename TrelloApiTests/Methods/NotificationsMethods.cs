namespace TrelloApiTests.Methods
{
    public class NotificationsMethods : NotificationsProperties
    {
        SettingEndpoints endpoints = new SettingEndpoints();
        BoardMethods boardMethods = new BoardMethods();
        private readonly ApiMethods apiClient;

        public NotificationsMethods()
        {
            this.apiClient = new ApiMethods();
        }

        public async Task NotificationDoesntExist()
        {
            
            var response = await apiClient.GetRequestApiAsync(endpoints.NotificationIdEndpoint(id)).ConfigureAwait(false);
            Assert.AreEqual(HttpStatusCode.NotFound, response.StatusCode);                                     
        }
    }
}
