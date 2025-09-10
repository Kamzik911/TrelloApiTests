using TrelloApiTests.ObjectsProperties;
using TrelloApiTests.Utils;

namespace TrelloApiTests.Methods
{
    public class CheckListMethods
    {
        EndpointsSetup endpoints = new EndpointsSetup();
        private readonly ApiMethods apiClient;
        private readonly ChecklistProperties checklistProperties;
        private readonly BoardProperties boardProperties = new BoardProperties();
        private readonly CardProperties cardProperties = new CardProperties();
        string randomString = StringGenerator.GenerateString(15);

        public CheckListMethods(ChecklistProperties checklistProperties)
        {
            this.apiClient = new ApiMethods();
            this.checklistProperties = checklistProperties;
        }

        public async Task CreateCheckList()
        {
            if (string.IsNullOrEmpty(boardProperties.Id))
            {
                throw new Exception("Board ID doesn't exist");
            }
            else
            {
                var checklistBody = new
                {
                    idCard = cardProperties.id,
                    name = this.randomString,
                };
                var response = await apiClient.PostBodyRequestApiAsync(this.endpoints.checklistEndpoint, checklistBody).ConfigureAwait(false);
                var jsonRensponse = JObject.Parse(response.Content);
                checklistProperties.id = jsonRensponse["id"].ToString();
                Assert.AreEqual(HttpStatusCode.OK, response.StatusCode);
                Assert.AreEqual(checklistBody.name, jsonRensponse["name"]);
                Assert.IsNotNull(checklistProperties.id);
            }
        }

        public async Task GetCheckList()
        {
            if (string.IsNullOrEmpty(checklistProperties.id)) 
            {
                throw new Exception("Checklist id doesn't exist");
            }
            else
            {
                var response = await apiClient.GetRequestApiAsync(checklistProperties.id).ConfigureAwait(false);
                Assert.AreEqual(HttpStatusCode.OK, response.StatusCode);
            }
        }

        public async Task DeleteCheckList() 
        {
            if (string.IsNullOrEmpty(checklistProperties.id))
            {
                throw new Exception("Checklist id donesn't exist");
            }
            else
            {
                var response = await apiClient.DeleteRequestApiAsync(this.endpoints.ChecklistIdEndpoint(checklistProperties.id)).ConfigureAwait(false);
                Assert.AreEqual(HttpStatusCode.OK, response.StatusCode);
            }
        }
    }
}
