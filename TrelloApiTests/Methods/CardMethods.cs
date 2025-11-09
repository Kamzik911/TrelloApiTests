using TrelloApiTests.ObjectsProperties;

namespace TrelloApiTests.Methods
{
    public class CardMethods
    {
        private readonly EndpointsSetup endpoints = new EndpointsSetup();
        private readonly IApiClient apiClient;
        private readonly CardProperties cardProperties;
        private readonly ListProperties listProperties;

        public CardMethods(CardProperties cardProperties, ListProperties listProperties)
            : this(cardProperties, listProperties, new ApiMethods())
        {            
        }

        public CardMethods(CardProperties cardProperties, ListProperties listProperties, IApiClient apiClient)
        {
            this.cardProperties = cardProperties ?? throw new ArgumentNullException(nameof(cardProperties));
            this.listProperties = listProperties ?? throw new ArgumentNullException(nameof(listProperties));            
            this.apiClient = apiClient ?? throw new ArgumentNullException(nameof(apiClient));
        }

        public async Task CreateNewCard()
        {
            if (string.IsNullOrEmpty(this.listProperties.id))
            {
                throw new InvalidOperationException("List id donesn't exist");
            }

            var cardBody = new
            {
                name = "RestApi tests",
                idList = this.listProperties.id,
            };

            var response = await this.apiClient.PostBodyRequestApiAsync(this.endpoints.cardsEndpoint, cardBody).ConfigureAwait(false);
            var jsonResponse = JObject.Parse(response.Content);
            this.cardProperties.id = jsonResponse["id"].ToString();
            Assert.AreEqual(HttpStatusCode.OK, response.StatusCode);
        }

        public async Task GetCardId()
        {
            if (string.IsNullOrEmpty(this.cardProperties.id))
            {
                throw new Exception("Card id doesn't exist");
            }
            else
            {
                var response = await this.apiClient.GetRequestApiAsync(this.endpoints.CardsIdEndpoint(this.cardProperties.id)).ConfigureAwait(false);
                Assert.AreEqual(HttpStatusCode.OK, response.StatusCode);
            }
        }

        public async Task DeleteCardId()
        {
            if (string.IsNullOrEmpty(this.cardProperties.id))
            {
                throw new Exception("Card id doesn't exist");
            }
            else
            {                
                var response = await this.apiClient.DeleteRequestApiAsync(this.endpoints.CardsIdEndpoint(this.cardProperties.id)).ConfigureAwait(false);
                Assert.AreEqual(HttpStatusCode.OK, response.StatusCode);
            }
        }
    }
}
