using Newtonsoft.Json.Linq;

namespace TrelloApiTests.Methods
{
    public class CardMethods
    {
        RestClient client = new RestClient();
        SettingEndpoints endpoints = new SettingEndpoints();
        Tokens tokens = new Tokens();
        
        public void CreateNewCard()
        {
            var cardBody = new
            {
                name = "RestApi tests",                
            };
            var request = new RestRequest($"{endpoints.cardsEndpoint}", Method.Post);
            request.AddQueryParameter("idList", ListProperties.ListId);
            request.AddQueryParameter("key", Tokens.trelloApiKey);
            request.AddQueryParameter("token", Tokens.trelloApiToken);
            var response = client.ExecuteAsync(request).Result;
            var jsonResponse = JObject.Parse(response.Content);
            CardProperties.CreatedCardId = jsonResponse["id"].ToString();

            Assert.AreEqual(HttpStatusCode.OK, response.StatusCode);
        }

        public void GetCardId()
        {
            if (string.IsNullOrEmpty(CardProperties.CreatedCardId))
            {
                var request = new RestRequest($"{endpoints.cardsIdEndpoint}", Method.Get);
                request.AddQueryParameter("key", Tokens.trelloApiKey);
                request.AddQueryParameter("token", Tokens.trelloApiToken);
                var response = client.ExecuteAsync(request).Result;

                Assert.AreEqual(HttpStatusCode.OK, response.StatusCode);
            }            
        }

        public void DeleteCardId()
        {
            if (string.IsNullOrEmpty(CardProperties.CreatedCardId))
            {
                var request = new RestRequest($"{endpoints.cardsIdEndpoint}", Method.Delete);
                request.AddQueryParameter("key", Tokens.trelloApiKey);
                request.AddQueryParameter("token", Tokens.trelloApiToken);
                var response = client.ExecuteAsync(request).Result;

                Assert.AreEqual(HttpStatusCode.OK, response.StatusCode);
            }            
        }
    }
}
