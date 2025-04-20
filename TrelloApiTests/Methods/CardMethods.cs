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
                idList = ObjectProperties.ListProperties.ListId
            };            
            var response = ApiMethods.PostBodyRequestApiAsync(endpoints.cardsEndpoint, cardBody);
            var jsonResponse = JObject.Parse(response.Content);
            ObjectProperties.CardProperties.CreatedCardId = jsonResponse["id"].ToString();
            ObjectsProperties.CardMainProperties.id = jsonResponse["id"].ToString();
            Assert.AreEqual(HttpStatusCode.OK, response.StatusCode);
        }

        public void GetCardId()
        {
            if (string.IsNullOrEmpty(ObjectProperties.CardProperties.CreatedCardId))
            {
                throw new Exception("Card id doesn't exist");
            }
            else
            {
                var response = ApiMethods.GetRequestApiAsync(endpoints.cardsIdEndpoint(ObjectProperties.CardProperties.CreatedCardId));
                Assert.AreEqual(HttpStatusCode.OK, response.StatusCode);
            }
        }

        public void DeleteCardId()
        {
            if (string.IsNullOrEmpty(ObjectProperties.CardProperties.CreatedCardId))
            {
                throw new Exception("Card id doesn't exist");
            }
            else
            {
                var request = new RestRequest($"{endpoints.cardsIdEndpoint(ObjectProperties.CardProperties.CreatedCardId)}", Method.Delete);
                request.AddQueryParameter("key", Tokens.trelloApiKey);
                request.AddQueryParameter("token", Tokens.trelloApiToken);
                var response = MainRestApiUrl.Client.ExecuteAsync(request).Result;
                Assert.AreEqual(HttpStatusCode.OK, response.StatusCode);
            }
        }
    }
}
