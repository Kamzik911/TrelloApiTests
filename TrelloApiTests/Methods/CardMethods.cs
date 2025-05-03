using TrelloApiTests.ObjectsProperties;

namespace TrelloApiTests.Methods
{
    public class CardMethods : CardProperties
    {        
        SettingEndpoints endpoints = new SettingEndpoints();        
        
        public void CreateNewCard()
        {
            var cardBody = new
            {
                name = "RestApi tests",
                idList = ListProperties.id
            };            
            var response = ApiMethods.PostBodyRequestApiAsync(endpoints.cardsEndpoint, cardBody);
            var jsonResponse = JObject.Parse(response.Content);            
            id = jsonResponse["id"].ToString();
            Assert.AreEqual(HttpStatusCode.OK, response.StatusCode);
        }

        public void GetCardId()
        {
            if (string.IsNullOrEmpty(id))
            {
                throw new Exception("Card id doesn't exist");
            }
            else
            {
                var response = ApiMethods.GetRequestApiAsync(endpoints.cardsIdEndpoint(id));
                Assert.AreEqual(HttpStatusCode.OK, response.StatusCode);
            }
        }

        public void DeleteCardId()
        {
            if (string.IsNullOrEmpty(id))
            {
                throw new Exception("Card id doesn't exist");
            }
            else
            {
                var request = new RestRequest($"{endpoints.cardsIdEndpoint(id)}", Method.Delete);
                request.AddQueryParameter("key", Tokens.trelloApiKey);
                request.AddQueryParameter("token", Tokens.trelloApiToken);
                var response = MainRestApiUrl.Client.ExecuteAsync(request).Result;
                Assert.AreEqual(HttpStatusCode.OK, response.StatusCode);
            }
        }
    }
}
