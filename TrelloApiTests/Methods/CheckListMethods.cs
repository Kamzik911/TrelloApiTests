namespace TrelloApiTests.Methods
{
    class CheckListMethods
    {
        SettingEndpoints endpoints = new SettingEndpoints();
        string randomString = StringGenerator.GenerateString(15);
        public void CreateCheckList()
        {
            if (string.IsNullOrEmpty(ObjectProperties.BoardProperties.CreatedIdBoard))
            {
                throw new Exception("Board ID doesn't exist");
            }
            else
            {
                var checklistBody = new
                {
                    idCard = ObjectProperties.CardProperties.CreatedCardId,
                    name = randomString
                };
                var response = ApiMethods.PostBodyRequestApiAsync(endpoints.ChecklistIdEndpoint(ObjectProperties.ChecklistProperties.ChecklistId), checklistBody);
                var jsonRensponse = JObject.Parse(response.Content);
                ObjectProperties.ChecklistProperties.ChecklistId = jsonRensponse["id"].ToString();
                Assert.AreEqual(HttpStatusCode.OK, response.StatusCode);
                Assert.AreEqual(checklistBody.name, jsonRensponse["name"]);
            }                
        }

        public void GetCheckList()
        {
            var response = ApiMethods.GetRequestApiAsync(ObjectProperties.ChecklistProperties.ChecklistId);
            Assert.AreEqual(HttpStatusCode.OK, response.StatusCode);
        }

        public void DeleteCheckList() 
        {
            if (string.IsNullOrEmpty(ObjectProperties.ChecklistProperties.ChecklistId))
            {
                throw new Exception("Checklist id donesn't exist");
            }
            else
            {
                var response = ApiMethods.DeleteRequestApiAsync(endpoints.ChecklistIdEndpoint(ObjectProperties.ChecklistProperties.ChecklistId));
                Assert.AreEqual(HttpStatusCode.OK, response.StatusCode);
            }                
        }        
    }
}
