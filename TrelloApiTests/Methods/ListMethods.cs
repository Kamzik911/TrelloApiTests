using TrelloApiTests.ObjectsProperties;

namespace TrelloApiTests.Methods
{
    internal class ListMethods
    {
        SettingEndpoints endpoints = new SettingEndpoints();                
        
        public void CreateList()
        {
            if (string.IsNullOrEmpty(ObjectProperties.BoardProperties.CreatedIdBoard))
            {
                throw new Exception("Id board doesn't exist");
            }

            var listBody = new
            {
                name = "Rest Api list",
                idBoard = ObjectProperties.BoardProperties.CreatedIdBoard,
            };
            var response = ApiMethods.PostBodyRequestApiAsync(endpoints.listIdEndpoint(ObjectProperties.ListProperties.ListId), listBody);
            var jsonResponse = JObject.Parse(response.Content);
            ObjectProperties.ListProperties.ListId = jsonResponse["id"].ToString();
            Assert.AreEqual(HttpStatusCode.OK, response.StatusCode);
            Assert.AreEqual(listBody.name, jsonResponse["name"]);                
            Assert.AreEqual(ObjectProperties.ListProperties.ListId, jsonResponse["id"]);
            Console.WriteLine(jsonResponse.ToString());
        }

        public void UpdateListId()
        {
            if (string.IsNullOrEmpty(ObjectProperties.ListProperties.ListId))
            {
                throw new Exception("Id board doesn't exist");
            }

            var listBody = new
            {
                name = "Rest api list updated",
                closed = false,                            
            };

            var response = ApiMethods.PutBodyRequestApiAsync(endpoints.listIdEndpoint(ObjectProperties.ListProperties.ListId), listBody);            
            var jsonResponse = JObject.Parse(response.Content);
            Assert.AreEqual(HttpStatusCode.OK, response.StatusCode);
            Assert.AreEqual(listBody.closed, jsonResponse["closed"]);
            ApiMethods.NumberPatternCheck(response, "pos");
            Console.WriteLine(jsonResponse.ToString());
        }        

        public void GetListId()
        {         
            if (string.IsNullOrEmpty(ObjectProperties.ListProperties.ListId))
            {
                throw new Exception("Id list doesn't exist");
            }
            var response = ApiMethods.GetRequestApiAsync(endpoints.listIdEndpoint(ObjectProperties.ListProperties.ListId));
            Assert.AreEqual(HttpStatusCode.OK, response.StatusCode);
        }

        public void ArchiveUnarchiveList(bool value)
        {            
            if (string.IsNullOrEmpty(ObjectProperties.ListProperties.ListId))
            {
                throw new Exception("Id list doesn't exist");
            }
            else
            {
                var listBody = new
                {
                    id = ObjectProperties.ListProperties.ListId,
                    closed = value
                };
                var response = ApiMethods.PutBodyRequestApiAsync(endpoints.listIdEndpoint(ObjectProperties.ListProperties.ListId), listBody);
                var jsonResponse = JObject.Parse(response.Content);
                Assert.AreEqual(HttpStatusCode.OK, response.StatusCode);
                Assert.AreEqual(listBody.closed, (bool)jsonResponse["closed"]);
            }                
        }

        public void GetActionsForList()
        {
            if (string.IsNullOrEmpty(ObjectProperties.ListProperties.ListId))
            {
                throw new Exception("Id list doesn't exist");
            }
            else
            {
                var response = ApiMethods.GetRequestApiAsync(endpoints.getBoardListIsOn(ObjectProperties.ListProperties.ListId));
                var jsonResponse = JObject.Parse(response.Content);
                Assert.AreEqual(HttpStatusCode.OK, response.StatusCode);                
            }                
        }

        public void GetCardInList()
        {
            if (string.IsNullOrEmpty(ObjectProperties.ListProperties.ListId))
            {
                throw new Exception("Id list doesn't exist");
            }
            if (string.IsNullOrEmpty(ObjectsProperties.CardMainProperties.id))
            {
                throw new Exception("Card id doesn't exist");
            }
            else
            {
                var request = new RestRequest($"{endpoints.getCardsListIsOn(ObjectProperties.ListProperties.ListId)}", Method.Get);
                request.AddQueryParameter("key", Tokens.trelloApiKey);
                request.AddQueryParameter("token", Tokens.trelloApiToken);
                var response = MainRestApiUrl.Client.ExecuteAsync(request).Result;
                var cards = JsonSerializer.Deserialize<List<CardMainProperties>>(response.Content).First();                
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
            if (string.IsNullOrEmpty(ObjectProperties.ListProperties.ListId))
            {
                throw new Exception("Id board doesn't exist");
            }
            else
            {
                var response = ApiMethods.PostRequestApiAsync(endpoints.archiveAllcardsEndpoint(ObjectProperties.ListProperties.ListId));
                Assert.AreEqual(HttpStatusCode.OK, response.StatusCode);
            }                
        }        
    }
}
