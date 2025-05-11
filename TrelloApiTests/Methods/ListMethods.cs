namespace TrelloApiTests.Methods
{
    internal class ListMethods : ListProperties
    {
        SettingEndpoints endpoints = new SettingEndpoints();                
        
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
            var response = ApiMethods.PostBodyRequestApiAsync(endpoints.listIdEndpoint(id), listBody);
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

            var response = ApiMethods.PutBodyRequestApiAsync(endpoints.listIdEndpoint(id), listBody);            
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
            var response = ApiMethods.GetRequestApiAsync(endpoints.listIdEndpoint(id));
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
                var response = ApiMethods.PutBodyRequestApiAsync(endpoints.listIdEndpoint(id), listBody);
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
                var response = ApiMethods.GetRequestApiAsync(endpoints.getBoardListIsOn(id));
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
                var request = new RestRequest($"{endpoints.getCardsListIsOn(id)}", Method.Get);
                request.AddQueryParameter("key", Tokens.trelloApiKey);
                request.AddQueryParameter("token", Tokens.trelloApiToken);
                var response = MainRestApiUrl.Client.ExecuteAsync(request).Result;
                var cards = JsonSerializer.Deserialize<List<CardProperties>>(response.Content).First();                
                Assert.IsNotNull(cards);
                Assert.IsFalse(cards.badges.location);
                Assert.IsFalse(cards.badges.description);
                Assert.IsNotNull(cards.badges.attachmentsByType.trello.board);
                Assert.AreEqual(HttpStatusCode.OK, response.StatusCode);                
                Console.WriteLine(response.Content);
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
                var response = ApiMethods.PostRequestApiAsync(endpoints.archiveAllcardsEndpoint(id));
                Assert.AreEqual(HttpStatusCode.OK, response.StatusCode);
            }                
        }        
    }
}
