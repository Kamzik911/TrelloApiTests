using TrelloApiTests.ObjectsProperties;
using TrelloApiTests.Utils;

namespace TrelloApiTests.Methods
{
    public class NotificationsMethods
    {
        EndpointsSetup endpoints = new EndpointsSetup();        
        private readonly ApiMethods apiClient;
        private readonly NotificationsProperties notifProp;

        public NotificationsMethods(NotificationsProperties notifProp)
        {
            this.apiClient = new ApiMethods();
            this.notifProp = notifProp;
        }

        public async Task NotificationDoesntExist()
        {
            
            var response = await apiClient.GetRequestApiAsync(endpoints.NotificationIdEndpoint(notifProp.id)).ConfigureAwait(false);
            Assert.AreEqual(HttpStatusCode.NotFound, response.StatusCode);                                     
        }
    }
}
