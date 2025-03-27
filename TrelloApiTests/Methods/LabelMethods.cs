using System.Drawing;

namespace TrelloApiTests.Methods
{
    public class LabelMethods
    {
        RestClient client = new RestClient();
        SettingEndpoints endpoints = new SettingEndpoints();

        public void CreateLabelOnBoard(string color)
        {
            if (string.IsNullOrEmpty(BoardProperties.CreatedIdBoard))
            {
                throw new Exception("Created board ID is null or empty.");
            }

            var labelBody = new
            {
                name = "New rest api label",
                color = $"{color}"
            };

            var request = new RestRequest($"{endpoints.boardLabels}", Method.Post);
            request.AddQueryParameter("name", labelBody.name);
            request.AddQueryParameter("color", labelBody.color);
            request.AddQueryParameter("idBoard", BoardProperties.CreatedIdBoard);
            request.AddQueryParameter("key", Tokens.trelloApiKey);
            request.AddQueryParameter("token", Tokens.trelloApiToken);
            var response = client.ExecuteAsync(request).Result;
            var jsonResponse = JObject.Parse(response.Content);            
            LabelProperties.CreatedLabelId = jsonResponse["id"].ToString();

            Assert.AreEqual(HttpStatusCode.OK, response.StatusCode);
            Assert.AreEqual(labelBody.name, jsonResponse["name"]);
            Assert.AreEqual(labelBody.color, jsonResponse["color"]);
        }

        public void GetCreatedLabel()
        {
            if (string.IsNullOrEmpty(BoardProperties.CreatedIdBoard))
            {
                throw new Exception("Created board ID is null or empty");
            }

            var request = new RestRequest($"{endpoints.boardLabelId}", Method.Get);
            request.AddQueryParameter("key", Tokens.trelloApiKey);
            request.AddQueryParameter("token", Tokens.trelloApiToken);
            var response = client.ExecuteAsync(request).Result;
            
            Assert.AreEqual(HttpStatusCode.OK, response.StatusCode);            
        }

        public void UpdateCreatedLabel(string color)
        {
            if (string.IsNullOrEmpty(BoardProperties.CreatedIdBoard))
            {
                throw new Exception("Created board ID is null or empty");
            }

            var labelBody = new
            {
                name = "Label updated",
                color = $"{color}"
            };

            var request = new RestRequest($"{endpoints.boardLabelId}", Method.Put).AddBody(labelBody);
            request.AddQueryParameter("key", Tokens.trelloApiKey);
            request.AddQueryParameter("token", Tokens.trelloApiToken);
            var response = client.ExecuteAsync(request).Result;
            var jsonResponse = JObject.Parse(response.Content);

            Assert.AreEqual(HttpStatusCode.OK, response.StatusCode);
            Assert.AreEqual(labelBody.color, jsonResponse["color"]);
        }        

        public void DeleteLabel()
        {
            if (string.IsNullOrEmpty(BoardProperties.CreatedIdBoard))
            {
                throw new Exception("Created board ID is null or empty");
            }

            var request = new RestRequest($"{endpoints.boardLabelId}", Method.Delete);
            request.AddQueryParameter("key", Tokens.trelloApiKey);
            request.AddQueryParameter("token", Tokens.trelloApiToken);
            var response = client.ExecuteAsync(request).Result;

            Assert.AreEqual(HttpStatusCode.OK, response.StatusCode);
        }
    }
}
