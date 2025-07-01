namespace TrelloApiTests.Methods
{
    class NotificationsMethods : NotificationsProperties
    {
        SettingEndpoints endpoints = new SettingEndpoints();
        BoardMethods boardMethods = new BoardMethods();

        public void NotificationDoesntExist()
        {
            
            var response = ApiMethods.GetRequestApiAsync(endpoints.NotificationIdEndpoint(id));
            Assert.AreEqual(HttpStatusCode.NotFound, response.StatusCode);                                     
        }
    }
}
