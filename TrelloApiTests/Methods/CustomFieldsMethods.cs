using TrelloApiTests.Utils;

namespace TrelloApiTests.Methods
{
    public class CustomFieldsMethods
    {
        private readonly EndpointsSetup endpoints = new EndpointsSetup();
        private readonly BoardProperties boardProperties;
        private readonly ApiMethods apiClient = new ApiMethods();
        private readonly CustomFieldProperties customFieldProperties;

        public CustomFieldsMethods(BoardProperties boardProperties, CustomFieldProperties customFieldProperties)
        {
            this.boardProperties = boardProperties;
            this.customFieldProperties = customFieldProperties;
        }
                
        public async Task CreateCustomFieldOnBoard()
        {
            if (string.IsNullOrEmpty(boardProperties.Id))
                {
                    throw new Exception("Board Id doesn't exist");
                }
            else
            {
                var customFieldBody = new
                {
                    idModel = boardProperties.Id,
                    modelType = "board",
                    name = "New custom field",
                    type = "checkbox", // Valid values: checkbox, list, number, text, date 
                    pos = "top",
                };
                var response = await apiClient.PostBodyRequestApiAsync(this.endpoints.customFieldEndpoint, customFieldBody).ConfigureAwait(false);
                Assert.AreEqual(HttpStatusCode.OK, response.StatusCode);
                var jsonResponse = JObject.Parse(response.Content);
                customFieldProperties.id = jsonResponse["id"].ToString();
            }
        }

        public async Task DeleteCustomFieldDefinition()
        {
            var response = await apiClient.DeleteRequestApiAsync(this.endpoints.CustomFieldIdEndpoint(customFieldProperties.id)).ConfigureAwait(false);
            Assert.AreEqual(HttpStatusCode.OK, response.StatusCode);
        }
    }
}
