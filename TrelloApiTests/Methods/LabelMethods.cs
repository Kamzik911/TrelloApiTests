
namespace TrelloApiTests.Methods
{
    public class LabelMethods
    {
        private EndpointsSetup endpoints = new EndpointsSetup();
        private readonly ApiMethods apiClient;
        private readonly BoardProperties boardProperties;
        private readonly LabelProperties labelProperties;
        private readonly CardProperties cardProperties;

        public LabelMethods(LabelProperties labelProperties, BoardProperties boardProperties, CardProperties cardProperties)
        {
            this.apiClient = new ApiMethods();
            this.labelProperties = labelProperties;
            this.boardProperties = boardProperties;
            this.cardProperties = cardProperties;
        }

        public async Task CreateLabelOnBoard(string color)
        {
            if (string.IsNullOrEmpty(boardProperties.Id))
            {
                throw new Exception("Board ID doens't exist.");
            }
            else
            {
                var labelBody = new
                {
                    name = "New rest api label",
                    color = color,
                    idBoard = boardProperties.Id,
                };

                var response = await apiClient.PostBodyRequestApiAsync(this.endpoints.labelsEndpoint, labelBody).ConfigureAwait(false);
                Assert.AreEqual(HttpStatusCode.OK, response.StatusCode);
                var jsonResponse = JObject.Parse(response.Content);
                labelProperties.id = jsonResponse["id"].ToString();
                Assert.AreEqual(labelBody.name, jsonResponse["name"]);
                Assert.AreEqual(labelBody.color, jsonResponse["color"]);
                Console.WriteLine(jsonResponse.ToString());
            }
        }

        public async Task GetCreatedLabel()
        {
            if (string.IsNullOrEmpty(boardProperties.Id))
            {
                throw new Exception("Created board ID is null or empty");
            }

            var response = await apiClient.GetRequestApiAsync(endpoints.LabelIdEndpoint(labelProperties.id)).ConfigureAwait(false);
            Assert.AreEqual(HttpStatusCode.OK, response.StatusCode);
        }

        public async Task UpdateCreatedLabel(string color)
        {
            if (string.IsNullOrEmpty(boardProperties.Id))
            {
                throw new Exception("Created board ID is null or empty");
            }
            else if(string.IsNullOrEmpty(labelProperties.id))
            {
                throw new Exception("Created label ID is null or empty");
            }
            else
            {
                var labelBody = new
                {
                    name = "Label updated",
                    color = $"{color}"
                };

                var request = new RestRequest($"{this.endpoints.LabelIdEndpoint(labelProperties.id)}", Method.Put).AddBody(labelBody);
                request.AddQueryParameter("key", Tokens.trelloApiKey);
                request.AddQueryParameter("token", Tokens.trelloApiToken);
                var response = await MainRestApiUrl.Client.ExecuteAsync(request).ConfigureAwait(false);
                var jsonResponse = JObject.Parse(response.Content);
                Assert.AreEqual(HttpStatusCode.OK, response.StatusCode);
                Assert.AreEqual(labelBody.color, jsonResponse["color"]);
            }
        }

        public async Task DeleteLabel()
        {
            if (string.IsNullOrEmpty(boardProperties.Id))
            {
                throw new Exception("Created board ID is null or empty");
            }
            else if (string.IsNullOrEmpty(labelProperties.id))
            {
                throw new Exception("Created label ID is null or empty");
            }
            else
            {
                var response = await apiClient.DeleteRequestApiAsync(this.endpoints.LabelIdEndpoint(labelProperties.id)).ConfigureAwait(false);
                Assert.AreEqual(HttpStatusCode.OK, response.StatusCode);
            }
        }
    }
}
