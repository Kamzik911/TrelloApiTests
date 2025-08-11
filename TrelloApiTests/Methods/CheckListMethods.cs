namespace TrelloApiTests.Methods
{
    public class CheckListMethods : ChecklistProperties
    {
        SettingEndpoints endpoints = new SettingEndpoints();
        string randomString = StringGenerator.GenerateString(15);

        public async Task CreateCheckList()
        {
            if (string.IsNullOrEmpty(BoardProperties.Id))
            {
                throw new Exception("Board ID doesn't exist");
            }
            else
            {
                var checklistBody = new
                {
                    idCard = CardProperties.id,
                    name = this.randomString,
                };
                var response = await ApiMethods.PostBodyRequestApiAsync(this.endpoints.checklistEndpoint, checklistBody).ConfigureAwait(false);
                var jsonRensponse = JObject.Parse(response.Content);
                id = jsonRensponse["id"].ToString();
                Assert.AreEqual(HttpStatusCode.OK, response.StatusCode);
                Assert.AreEqual(checklistBody.name, jsonRensponse["name"]);
                Assert.IsNotNull(id);
            }
        }

        public async Task GetCheckList()
        {
            if (string.IsNullOrEmpty(id)) 
            {
                throw new Exception("Checklist id doesn't exist");
            }
            else
            {
                var response = await ApiMethods.GetRequestApiAsync(id).ConfigureAwait(false);
                Assert.AreEqual(HttpStatusCode.OK, response.StatusCode);
            }
        }

        public async Task DeleteCheckList() 
        {
            if (string.IsNullOrEmpty(id))
            {
                throw new Exception("Checklist id donesn't exist");
            }
            else
            {
                var response = await ApiMethods.DeleteRequestApiAsync(this.endpoints.ChecklistIdEndpoint(id)).ConfigureAwait(false);
                Assert.AreEqual(HttpStatusCode.OK, response.StatusCode);
            }
        }
    }
}
