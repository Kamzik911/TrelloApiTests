namespace TrelloApiTests.Methods
{
    public class CustomFieldsMethods : CustomFieldProperties
    {
        SettingEndpoints endpoints = new SettingEndpoints();

        public async Task CreateCustomFieldOnBoard()
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
                    type = "checkbox", // Valid values: checkbox, list, number, text, date 
                    pos = "top",
                };
                var response = await ApiMethods.PostBodyRequestApiAsync(this.endpoints.customFieldEndpoint, customFieldBody).ConfigureAwait(false);
                Assert.AreEqual(HttpStatusCode.OK, response.StatusCode);
                var jsonResponse = JObject.Parse(response.Content);
                id = jsonResponse["id"].ToString();
            }
        }

        public async Task DeleteCustomFieldDefinition()
        {
            var response = await ApiMethods.DeleteRequestApiAsync(this.endpoints.CustomFieldIdEndpoint(id)).ConfigureAwait(false);
            Assert.AreEqual(HttpStatusCode.OK, response.StatusCode);
        }
    }
}
