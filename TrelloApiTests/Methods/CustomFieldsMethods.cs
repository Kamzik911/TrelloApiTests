namespace TrelloApiTests.Methods
{
    class CustomFieldsMethods : CustomFieldProperties
    {        
        SettingEndpoints endpoints = new SettingEndpoints();        
     
        public void CreateCustomFieldOnBoard()
        {
            if (string.IsNullOrEmpty(BoardProperties.id))
                {
                    throw new Exception("Board Id doesn't exist");
                }
            else
            {
                var customFieldBody = new
                {                    
                    idModel = BoardProperties.id,
                    modelType = "board",
                    name = "New custom field",
                    type = "checkbox", //Valid values: checkbox, list, number, text, date 
                    pos = "top"
                };
                var response = ApiMethods.PostBodyRequestApiAsync(endpoints.customFieldEndpoint, customFieldBody);
                Assert.AreEqual(HttpStatusCode.OK, response.StatusCode);
                var jsonResponse = JObject.Parse(response.Content);
                id = jsonResponse["id"].ToString();
            }                
        }

        public void DeleteCustomFieldDefinition()
        {
            var response = ApiMethods.DeleteRequestApiAsync(endpoints.CustomFieldIdEndpoint(id));
            Assert.AreEqual(HttpStatusCode.OK, response.StatusCode);
        }
    }
}
