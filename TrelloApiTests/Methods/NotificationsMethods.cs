namespace TrelloApiTests.Methods
{
    public class NotificationsMethods : NotificationsProperties
    {
        SettingEndpoints endpoints = new SettingEndpoints();
        BoardMethods boardMethods = new BoardMethods();

        public async Task NotificationDoesntExist()
        {
            
            var response = await ApiMethods.GetRequestApiAsync(endpoints.NotificationIdEndpoint(id)).ConfigureAwait(false);
            Assert.AreEqual(HttpStatusCode.NotFound, response.StatusCode);                                     
        }
    }
}
