namespace TrelloApiTests.Methods
{
    public class ListMethods : ListProperties
    {
        private SettingEndpoints endpoints = new SettingEndpoints();

        public async Task CreateList()
        {
            if (string.IsNullOrEmpty(BoardProperties.id))
            {
                throw new Exception("Id board doesn't exist");
            }

            var listBody = new
            {
                name = "Rest Api list",
                idBoard = BoardProperties.id,
            };
            var response = await ApiMethods.PostBodyRequestApiAsync(this.endpoints.ListIdEndpoint(id), listBody).ConfigureAwait(false);
            var jsonResponse = JObject.Parse(response.Content);
            id = jsonResponse["id"].ToString();
            Assert.AreEqual(HttpStatusCode.OK, response.StatusCode);
            Assert.AreEqual(listBody.name, jsonResponse["name"]);
            Assert.AreEqual(id, jsonResponse["id"]);            
        }

        public async Task UpdateListId()
        {
            if (string.IsNullOrEmpty(id))
            {
                throw new Exception("Id board doesn't exist");
            }

            var listBody = new
            {
                name = "Rest api list updated",
                closed = false,
            };

            var response = await ApiMethods.PutBodyRequestApiAsync(this.endpoints.ListIdEndpoint(id), listBody).ConfigureAwait(false);
            var jsonResponse = JObject.Parse(response.Content);
            Assert.AreEqual(HttpStatusCode.OK, response.StatusCode);
            Assert.AreEqual(listBody.closed, jsonResponse["closed"]);
            ApiMethods.NumberPatternCheck(response, "pos");            
        }

        public async Task GetListId()
        {
            if (string.IsNullOrEmpty(id))
            {
                throw new Exception("Id list doesn't exist");
            }
            var response = await ApiMethods.GetRequestApiAsync(this.endpoints.ListIdEndpoint(id)).ConfigureAwait(false);
            Assert.AreEqual(HttpStatusCode.OK, response.StatusCode);
        }

        public async Task ArchiveUnarchiveList(bool value)
        {
            if (string.IsNullOrEmpty(id))
            {
                throw new Exception("Id list doesn't exist");
            }
            else
            {
                var listBody = new
                {
                    id = id,
                    closed = value
                };
                var response = await ApiMethods.PutBodyRequestApiAsync(this.endpoints.ListIdEndpoint(id), listBody).ConfigureAwait(false);
                var jsonResponse = JObject.Parse(response.Content);
                Assert.AreEqual(HttpStatusCode.OK, response.StatusCode);
                Assert.AreEqual(listBody.closed, (bool)jsonResponse["closed"]);
            }
        }

        public async Task GetActionsForList()
        {
            if (string.IsNullOrEmpty(id))
            {
                throw new Exception("Id list doesn't exist");
            }
            else
            {
                var response = await ApiMethods.GetRequestApiAsync(this.endpoints.GetBoardListIsOn(id)).ConfigureAwait(false);
                var jsonResponse = JObject.Parse(response.Content);
                Assert.AreEqual(HttpStatusCode.OK, response.StatusCode);
            }
        }

        public async Task GetCardInList()
        {
            if (string.IsNullOrEmpty(id))
            {
                throw new Exception("Id list doesn't exist");
            }

            if (string.IsNullOrEmpty(CardProperties.id))
            {
                throw new Exception("Card id doesn't exist");
            }
            else
            {
                var request = new RestRequest($"{this.endpoints.GetCardsListIsOn(id)}", Method.Get);
                request.AddQueryParameter("key", Tokens.trelloApiKey);
                request.AddQueryParameter("token", Tokens.trelloApiToken);
                var response = await MainRestApiUrl.Client.ExecuteAsync(request).ConfigureAwait(false);
                var jsonResponse = JArray.Parse(response.Content);                
                bool location = jsonResponse.Any(l => l["badges"]?["location"].Type == JTokenType.Boolean);
                Assert.IsTrue(location);
            }
        }

        public async Task ArchiveAllCardsInList()
        {
            if (string.IsNullOrEmpty(id))
            {
                throw new Exception("Id board doesn't exist");
            }
            else
            {
                var response = await ApiMethods.PostRequestApiAsync(this.endpoints.ArchiveAllcardsEndpoint(id)).ConfigureAwait(false);
                Assert.AreEqual(HttpStatusCode.OK, response.StatusCode);
            }
        }
    }
}
