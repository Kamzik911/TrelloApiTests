using TrelloApiTests.ObjectsProperties;

namespace TrelloApiTests.Methods
{
    class CheckListMethods
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
                ChecklistProperties.id = jsonRensponse["id"].ToString();
                Assert.AreEqual(HttpStatusCode.OK, response.StatusCode);
                Assert.AreEqual(checklistBody.name, jsonRensponse["name"]);
                Assert.IsNotNull(ChecklistProperties.id);                
            }                
        }

        public void GetCheckList()
        {
            if (string.IsNullOrEmpty(BoardProperties.id)) 
            {
                var response = ApiMethods.GetRequestApiAsync(ChecklistProperties.id);
                Assert.AreEqual(HttpStatusCode.OK, response.StatusCode);                
            }            
        }

        public void DeleteCheckList() 
        {
            if (string.IsNullOrEmpty(ChecklistProperties.id))
            {
                throw new Exception("Checklist id donesn't exist");
            }
            else
            {
                var response = ApiMethods.DeleteRequestApiAsync(endpoints.ChecklistIdEndpoint(ChecklistProperties.id));
                Assert.AreEqual(HttpStatusCode.OK, response.StatusCode);
            }                
        }        
    }
}
