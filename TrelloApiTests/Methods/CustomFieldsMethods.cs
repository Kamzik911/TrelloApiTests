using TrelloApiTests.ObjectsProperties;

namespace TrelloApiTests.Methods
{
    class CustomFieldsMethods : CustomFieldProperties
    {        
        SettingEndpoints endpoints = new SettingEndpoints();        
     
        public void CreateCustomFieldOnBoard()
        {
            var customFieldBody = new
            {
                idModel = BoardProperties.id,
                modelType = "board",
                name = "New custom field",
                type = "checkbox", //Valid values: checkbox, list, number, text, date 
                pos = "top"
            };
            var response = ApiMethods.PostRequestApiAsync(endpoints.customFieldEndpoint);
            Assert.AreEqual(HttpStatusCode.OK, response.StatusCode);
            var jsonResponse = JObject.Parse(response.Content);
            id = jsonResponse["id"].ToString();
            Console.WriteLine($"Response Content: {response.Content.ToString()}");
                        
        }
    }
}
