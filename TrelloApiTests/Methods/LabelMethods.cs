namespace TrelloApiTests.Methods
{
    public class LabelMethods : LabelProperties
    {
        private SettingEndpoints endpoints = new SettingEndpoints();

        public async Task CreateLabelOnBoard(string color)
        {
            if (string.IsNullOrEmpty(BoardProperties.id))
            {
                throw new Exception("Board ID doens't exist.");
            }
            else
            {
                var labelBody = new
                {
                    name = "New rest api label",
                    color = color,
                    idBoard = BoardProperties.id,
                };

                var response = await ApiMethods.PostBodyRequestApiAsync(this.endpoints.labelsEndpoint, labelBody).ConfigureAwait(false);
                Assert.AreEqual(HttpStatusCode.OK, response.StatusCode);
                var jsonResponse = JObject.Parse(response.Content);
                id = jsonResponse["id"].ToString();
                Assert.AreEqual(labelBody.name, jsonResponse["name"]);
                Assert.AreEqual(labelBody.color, jsonResponse["color"]);
                Console.WriteLine(jsonResponse.ToString());
            }
        }

        public async Task GetCreatedLabel()
        {
            if (string.IsNullOrEmpty(BoardProperties.id))
            {
                throw new Exception("Created board ID is null or empty");
            }

            var response = await ApiMethods.GetRequestApiAsync(endpoints.LabelIdEndpoint(id)).ConfigureAwait(false);
            Assert.AreEqual(HttpStatusCode.OK, response.StatusCode);
        }

        public async Task UpdateCreatedLabel(string color)
        {
            if (string.IsNullOrEmpty(id))
            {
                throw new Exception("Created board ID is null or empty");
            }
            else if(string.IsNullOrEmpty(id))
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

                var request = new RestRequest($"{this.endpoints.LabelIdEndpoint(id)}", Method.Put).AddBody(labelBody);
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
            if (string.IsNullOrEmpty(id))
            {
                throw new Exception("Created board ID is null or empty");
            }
            else if (string.IsNullOrEmpty(id))
            {
                throw new Exception("Created label ID is null or empty");
            }
            else
            {
                var response = await ApiMethods.DeleteRequestApiAsync(this.endpoints.LabelIdEndpoint(id)).ConfigureAwait(false);
                Assert.AreEqual(HttpStatusCode.OK, response.StatusCode);
            }
        }
    }
}
