using System.Runtime.CompilerServices;
using TrelloApiTests.ObjectsProperties;
using TrelloApiTests.Utils;

namespace TrelloApiTests.Methods
{
    public class CardMethods
    {
        EndpointsSetup endpoints = new EndpointsSetup();
        ApiMethods apiMethods = new ApiMethods();        
        CardProperties cardProperties;
        ListProperties listProperties = new ListProperties();

        public CardMethods(CardProperties cardProperties)
        {
            this.apiMethods = new ApiMethods();
            this.cardProperties = cardProperties;
        }

        public async Task CreateNewCard()
        {
            var cardBody = new
            {
                name = "RestApi tests",
                idList = listProperties.id,
            };
            var response = await apiMethods.PostBodyRequestApiAsync(endpoints.cardsEndpoint, cardBody).ConfigureAwait(false);
            var jsonResponse = JObject.Parse(response.Content);
            cardProperties.id = jsonResponse["id"].ToString();
            Assert.AreEqual(HttpStatusCode.OK, response.StatusCode);
        }

        public async Task GetCardId()
        {
            if (string.IsNullOrEmpty(cardProperties.id))
            {
                throw new Exception("Card id doesn't exist");
            }
            else
            {
                var response = await apiMethods.GetRequestApiAsync(endpoints.CardsIdEndpoint(cardProperties.id)).ConfigureAwait(false);
                Assert.AreEqual(HttpStatusCode.OK, response.StatusCode);
            }
        }

        public async Task DeleteCardId()
        {
            if (string.IsNullOrEmpty(cardProperties.id))
            {
                throw new Exception("Card id doesn't exist");
            }
            else
            {
                var request = new RestRequest($"{endpoints.CardsIdEndpoint(cardProperties.id)}", Method.Delete);
                request.AddQueryParameter("key", Tokens.trelloApiKey);
                request.AddQueryParameter("token", Tokens.trelloApiToken);
                var response = await MainRestApiUrl.Client.ExecuteAsync(request).ConfigureAwait(false);
                Assert.AreEqual(HttpStatusCode.OK, response.StatusCode);
            }
        }
    }
}
