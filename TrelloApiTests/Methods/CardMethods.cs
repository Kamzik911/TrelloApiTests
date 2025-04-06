using Newtonsoft.Json.Linq;

namespace TrelloApiTests.Methods
{
    public class CardMethods
    {        
        SettingEndpoints endpoints = new SettingEndpoints();
        Tokens tokens = new Tokens();
        
        public void CreateNewCard()
        {
            var cardBody = new
            {
                name = "RestApi tests",                
            };
            var request = new RestRequest($"{endpoints.cardsEndpoint}", Method.Post);
            request.AddQueryParameter("idList", ObjectProperties.ListProperties.ListId);
            request.AddQueryParameter("key", Tokens.trelloApiKey);
            request.AddQueryParameter("token", Tokens.trelloApiToken);
            var response = MainRestApiUrl.Client.ExecuteAsync(request).Result;
            var jsonResponse = JObject.Parse(response.Content);
            ObjectProperties.CardProperties.CreatedCardId = jsonResponse["id"].ToString();

            Assert.AreEqual(HttpStatusCode.OK, response.StatusCode);
        }

        public void GetCardId()
        {
            if (string.IsNullOrEmpty(ObjectProperties.CardProperties.CreatedCardId))
            {                
                var response = ApiMethods.GetRequestApiAsync(endpoints.cardsIdEndpoint);
                Assert.AreEqual(HttpStatusCode.OK, response.StatusCode);
            }            
        }

        public void DeleteCardId()
        {
            if (string.IsNullOrEmpty(ObjectProperties.CardProperties.CreatedCardId))
            {
                var request = new RestRequest($"{endpoints.cardsIdEndpoint}", Method.Delete);
                request.AddQueryParameter("key", Tokens.trelloApiKey);
                request.AddQueryParameter("token", Tokens.trelloApiToken);
                var response = MainRestApiUrl.Client.ExecuteAsync(request).Result;

                Assert.AreEqual(HttpStatusCode.OK, response.StatusCode);
            }            
        }
    }
}
