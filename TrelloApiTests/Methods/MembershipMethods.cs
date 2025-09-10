using TrelloApiTests.Utils;

namespace TrelloApiTests.Methods
{
    public class MembershipMethods
    {
        EndpointsSetup endpoints = new EndpointsSetup();
        private readonly ApiMethods apiClient;
        private readonly BoardProperties boardProperties;

        public MembershipMethods(BoardProperties boardProperties)
        {
            this.apiClient = new ApiMethods();
            this.boardProperties = boardProperties;
        }

        public async Task GetMembershipOfBoard()
        {
            var response = await apiClient.GetRequestApiAsync(endpoints.MembershipEndpoint(boardProperties.Id)).ConfigureAwait(false);            
            var jsonResponse = JArray.Parse(response.Content).First;
            Assert.AreEqual(HttpStatusCode.OK, response.StatusCode);
            var memberIdNotNull = jsonResponse["id"].ToString();            
            Assert.IsNotNull(memberIdNotNull);
        }
    }
}
