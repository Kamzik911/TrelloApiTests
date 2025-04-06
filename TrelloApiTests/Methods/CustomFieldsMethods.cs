using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace TrelloApiTests.Methods
{
    class CustomFieldsMethods
    {
        RestClient client = new RestClient();
        SettingEndpoints endpoints = new SettingEndpoints();        
     
        public void CreateCustomFieldOnBoard()
        {
            var customFieldBody = new
            {
                idModel = ObjectProperties.BoardProperties.CreatedIdBoard,
                modelType = "board",
                name = "New custom field",
                type = "checkbox", //Valid values: checkbox, list, number, text, date 
                pos = "top"
            };

            var request = new RestRequest($"{endpoints.customFieldEndpoint}", Method.Post).AddBody(customFieldBody);            
            request.AddQueryParameter("key", Tokens.trelloApiKey);
            request.AddQueryParameter("token", Tokens.trelloApiToken);            
            var response = client.ExecuteAsync(request).Result;            
            var jsonResponse = JObject.Parse(response.Content);

            ObjectProperties.CustomFieldProperties.CustomFieldId = jsonResponse["id"].ToString();
            Console.WriteLine($"Response Content: {response.Content.ToString()}");
                        
        }
    }
}
