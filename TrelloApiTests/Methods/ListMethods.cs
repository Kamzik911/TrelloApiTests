namespace TrelloApiTests.Methods
{
    public class ListMethods
    {
        private readonly EndpointsSetup endpoints = new EndpointsSetup();
        private readonly IApiClient apiClient;
        private readonly BoardProperties boardProperties;
        private readonly ListProperties listProperties;
        
        public ListMethods(BoardProperties boardProperties, ListProperties listProperties)
            : this(boardProperties, listProperties, new ApiMethods())
        {            
        }

        public ListMethods(BoardProperties boardProperties, ListProperties listProperties, IApiClient apiClient)
        {
            this.listProperties =  listProperties ?? throw new ArgumentNullException(nameof(listProperties));
            this.boardProperties = boardProperties ?? throw new ArgumentNullException(nameof(boardProperties));
            //this.cardProperties = cardProperties ?? throw new ArgumentNullException(nameof(cardProperties));
            this.apiClient = apiClient ?? throw new ArgumentNullException(nameof(apiClient));
        }

        public async Task CreateList()
        {
            if (string.IsNullOrEmpty(boardProperties.Id))
            {
                throw new Exception("Id board doesn't exist");
            }

            var listBody = new
            {
                name = "Rest Api list",
                idBoard = boardProperties.Id,
            };
            var response = await this.apiClient.PostBodyRequestApiAsync(endpoints.listsEndpoint, listBody).ConfigureAwait(false);
            var jsonResponse = JObject.Parse(response.Content);
            listProperties.id = jsonResponse["id"].ToString();
            Assert.AreEqual(HttpStatusCode.OK, response.StatusCode);
            Assert.AreEqual(listBody.name, jsonResponse["name"]);
            Assert.AreEqual(listProperties.id, jsonResponse["id"]);            
        }

        public async Task UpdateListId()
        {
            if (string.IsNullOrEmpty(listProperties.id))
            {
                throw new Exception("Id board doesn't exist");
            }

            var listBody = new
            {
                name = "Rest api list updated",
                closed = false,
            };

            var response = await this.apiClient.PutBodyRequestApiAsync(this.endpoints.ListIdEndpoint(listProperties.id), listBody).ConfigureAwait(false);
            var jsonResponse = JObject.Parse(response.Content);
            Assert.AreEqual(HttpStatusCode.OK, response.StatusCode);
            Assert.AreEqual(listBody.closed, jsonResponse["closed"]);
            Assert.IsTrue(ResponseValidator.NumberPatternCheck(response, "pos"));
        }

        public async Task GetListId()
        {
            if (string.IsNullOrEmpty(listProperties.id))
            {
                throw new Exception("Id list doesn't exist");
            }
            var response = await this.apiClient.GetRequestApiAsync(endpoints.ListIdEndpoint(listProperties.id)).ConfigureAwait(false);
            Assert.AreEqual(HttpStatusCode.OK, response.StatusCode);
        }

        public async Task ArchiveUnarchiveList(bool value)
        {
            if (string.IsNullOrEmpty(listProperties.id))
            {
                throw new Exception("Id list doesn't exist");
            }
            else
            {
                var listBody = new
                {
                    id = listProperties.id,
                    closed = value
                };
                var response = await this.apiClient.PutBodyRequestApiAsync(endpoints.ListIdEndpoint(listProperties.id), listBody).ConfigureAwait(false);
                var jsonResponse = JObject.Parse(response.Content);
                Assert.AreEqual(HttpStatusCode.OK, response.StatusCode);
                Assert.AreEqual(listBody.closed, (bool)jsonResponse["closed"]);
            }
        }

        public async Task GetActionsForList()
        {
            if (string.IsNullOrEmpty(listProperties.id))
            {
                throw new Exception("Id list doesn't exist");
            }
            else
            {
                var response = await apiClient.GetRequestApiAsync(endpoints.GetBoardListIsOn(listProperties.id)).ConfigureAwait(false);
                var jsonResponse = JObject.Parse(response.Content);
                Assert.AreEqual(HttpStatusCode.OK, response.StatusCode);
            }
        }

        /*public async Task GetCardInList()
        {
            if (string.IsNullOrEmpty(listProperties.id))
            {
                throw new Exception("Id list doesn't exist");
            }

            if (string.IsNullOrEmpty(cardProperties.id))
            {
                throw new Exception("Card id doesn't exist");
            }
            else
            {
                var request = new RestRequest($"{this.endpoints.GetCardsListIsOn(listProperties.id)}", Method.Get);
                request.AddQueryParameter("key", Tokens.trelloApiKey);
                request.AddQueryParameter("token", Tokens.trelloApiToken);
                var response = await MainRestApiUrl.Client.ExecuteAsync(request).ConfigureAwait(false);
                var jsonResponse = JArray.Parse(response.Content);                
                bool location = jsonResponse.Any(l => l["badges"]?["location"].Type == JTokenType.Boolean);
                Assert.IsTrue(location);
            }
        }*/

        public async Task ArchiveAllCardsInList()
        {
            if (string.IsNullOrEmpty(listProperties.id))
            {
                throw new Exception("Id board doesn't exist");
            }
            else
            {
                var response = await apiClient.PostRequestApiAsync(this.endpoints.ArchiveAllcardsEndpoint(listProperties.id)).ConfigureAwait(false);
                Assert.AreEqual(HttpStatusCode.OK, response.StatusCode);
            }
        }
    }
}
