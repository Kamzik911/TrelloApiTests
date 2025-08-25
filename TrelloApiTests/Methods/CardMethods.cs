namespace TrelloApiTests.Methods
{
    public class CardMethods : CardProperties
    {
        SettingEndpoints endpoints = new SettingEndpoints();
        private readonly ApiMethods apiMethods;

        public CardMethods()
        {
            this.apiMethods = new ApiMethods();
        }

        public async Task CreateNewCard()
        {
            var cardBody = new
            {
                name = "RestApi tests",
                idList = ListProperties.id,
            };
            var response = await apiMethods.PostBodyRequestApiAsync(endpoints.cardsEndpoint, cardBody).ConfigureAwait(false);
            var jsonResponse = JObject.Parse(response.Content);
            id = jsonResponse["id"].ToString();
            Assert.AreEqual(HttpStatusCode.OK, response.StatusCode);
        }

        public async Task GetCardId()
        {
            if (string.IsNullOrEmpty(id))
            {
                throw new Exception("Card id doesn't exist");
            }
            else
            {
                var response = await apiMethods.GetRequestApiAsync(endpoints.CardsIdEndpoint(id)).ConfigureAwait(false);
                Assert.AreEqual(HttpStatusCode.OK, response.StatusCode);
            }
        }

        public async Task DeleteCardId()
        {
            if (string.IsNullOrEmpty(id))
            {
                throw new Exception("Card id doesn't exist");
            }
            else
            {
                var request = new RestRequest($"{endpoints.CardsIdEndpoint(id)}", Method.Delete);
                request.AddQueryParameter("key", Tokens.trelloApiKey);
                request.AddQueryParameter("token", Tokens.trelloApiToken);
                var response = await MainRestApiUrl.Client.ExecuteAsync(request).ConfigureAwait(false);
                Assert.AreEqual(HttpStatusCode.OK, response.StatusCode);
            }
        }
    }
}
