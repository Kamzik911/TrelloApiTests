namespace TrelloApiTests.Methods
{
    public class ListMethods : ListProperties
    {
        private SettingEndpoints endpoints = new SettingEndpoints();

        public void CreateList()
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
            var response = ApiMethods.PostBodyRequestApiAsync(this.endpoints.ListIdEndpoint(id), listBody);
            var jsonResponse = JObject.Parse(response.Content);
            id = jsonResponse["id"].ToString();
            Assert.AreEqual(HttpStatusCode.OK, response.StatusCode);
            Assert.AreEqual(listBody.name, jsonResponse["name"]);
            Assert.AreEqual(id, jsonResponse["id"]);
            Console.WriteLine(jsonResponse.ToString());
        }

        public void UpdateListId()
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

            var response = ApiMethods.PutBodyRequestApiAsync(this.endpoints.ListIdEndpoint(id), listBody);
            var jsonResponse = JObject.Parse(response.Content);
            Assert.AreEqual(HttpStatusCode.OK, response.StatusCode);
            Assert.AreEqual(listBody.closed, jsonResponse["closed"]);
            ApiMethods.NumberPatternCheck(response, "pos");
            Console.WriteLine(jsonResponse.ToString());
        }

        public void GetListId()
        {
            if (string.IsNullOrEmpty(id))
            {
                throw new Exception("Id list doesn't exist");
            }
            var response = ApiMethods.GetRequestApiAsync(this.endpoints.ListIdEndpoint(id));
            Assert.AreEqual(HttpStatusCode.OK, response.StatusCode);
        }

        public void ArchiveUnarchiveList(bool value)
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
                var response = ApiMethods.PutBodyRequestApiAsync(this.endpoints.ListIdEndpoint(id), listBody);
                var jsonResponse = JObject.Parse(response.Content);
                Assert.AreEqual(HttpStatusCode.OK, response.StatusCode);
                Assert.AreEqual(listBody.closed, (bool)jsonResponse["closed"]);
            }
        }

        public void GetActionsForList()
        {
            if (string.IsNullOrEmpty(id))
            {
                throw new Exception("Id list doesn't exist");
            }
            else
            {
                var response = ApiMethods.GetRequestApiAsync(this.endpoints.GetBoardListIsOn(id));
                var jsonResponse = JObject.Parse(response.Content);
                Assert.AreEqual(HttpStatusCode.OK, response.StatusCode);
            }
        }

        public void GetCardInList()
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
                var response = MainRestApiUrl.Client.ExecuteAsync(request).Result;
                //var cards = JsonSerializer.Deserialize<List<CardProperties>>(response.Content).First();
                var jsonResponse = JArray.Parse(response.Content);                
                bool location = jsonResponse.Any(l => l["badges"]?["location"].Type == JTokenType.Boolean);
                Assert.IsTrue(location);
                /*Assert.IsFalse(cards.badges.location);
                Assert.IsFalse(cards.badges.description);
                Assert.IsNotNull(cards.badges.attachmentsByType.trello.board);
                Assert.AreEqual(HttpStatusCode.OK, response.StatusCode);
                Console.WriteLine(response.Content);*/
            }
        }

        public void ArchiveAllCardsInList()
        {
            if (string.IsNullOrEmpty(id))
            {
                throw new Exception("Id board doesn't exist");
            }
            else
            {
                var response = ApiMethods.PostRequestApiAsync(this.endpoints.ArchiveAllcardsEndpoint(id));
                Assert.AreEqual(HttpStatusCode.OK, response.StatusCode);
            }
        }
    }
}
