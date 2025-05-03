using TrelloApiTests.ObjectsProperties;

namespace TrelloApiTests.Methods
{
    class CheckListMethods : ChecklistProperties
    {
        SettingEndpoints endpoints = new SettingEndpoints();
        string randomString = StringGenerator.GenerateString(15);

        public void CreateCheckList()
        {
            if (string.IsNullOrEmpty(BoardProperties.id))
            {
                throw new Exception("Board ID doesn't exist");
            }
            else
            {
                var checklistBody = new
                {
                    idCard = CardProperties.id,
                    name = randomString
                };
                var response = ApiMethods.PostBodyRequestApiAsync(SettingEndpoints.checklistEndpoint, checklistBody);
                var jsonRensponse = JObject.Parse(response.Content);
                id = jsonRensponse["id"].ToString();
                Assert.AreEqual(HttpStatusCode.OK, response.StatusCode);
                Assert.AreEqual(checklistBody.name, jsonRensponse["name"]);
                Assert.IsNotNull(id);                
            }                
        }

        public void GetCheckList()
        {
            if (string.IsNullOrEmpty(id)) 
            {
                var response = ApiMethods.GetRequestApiAsync(id);
                Assert.AreEqual(HttpStatusCode.OK, response.StatusCode);                
            }            
        }

        public void DeleteCheckList() 
        {
            if (string.IsNullOrEmpty(id))
            {
                throw new Exception("Checklist id donesn't exist");
            }
            else
            {
                var response = ApiMethods.DeleteRequestApiAsync(endpoints.ChecklistIdEndpoint(id));
                Assert.AreEqual(HttpStatusCode.OK, response.StatusCode);
            }                
        }        
    }
}
