namespace TrelloApiTests.Methods
{
    public class LabelMethods
    {
        RestClient client = new RestClient();
        SettingEndpoints endpoints = new SettingEndpoints();

        public void CreateLabelOnBoard(string colour)
        {
            if (string.IsNullOrEmpty(SettingProperties.CreatedIdBoard))
            {
                throw new Exception("Created board ID is null or empty.");
            }

            var labelBody = new
            {
                name = "New rest api label",
                colour = $"{colour}"
            };

            var request = new RestRequest($"{endpoints.boardLabels}", Method.Post);
            request.AddQueryParameter("name", labelBody.name);
            request.AddQueryParameter("color", labelBody.colour);
            request.AddQueryParameter("idBoard", SettingProperties.CreatedIdBoard);
            request.AddQueryParameter("key", Tokens.trelloApiKey);
            request.AddQueryParameter("token", Tokens.trelloApiToken);
            var response = client.ExecuteAsync(request).Result;
            var jsonResponse = JObject.Parse(response.Content);

            Assert.AreEqual(HttpStatusCode.OK, response.StatusCode);
            Assert.AreEqual(labelBody.name, jsonResponse["name"]);
            Assert.AreEqual(labelBody.colour, jsonResponse["color"]);
        }
    }
}
