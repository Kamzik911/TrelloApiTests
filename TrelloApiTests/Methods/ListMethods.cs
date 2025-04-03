namespace TrelloApiTests.Methods
{
    internal class ListMethods
    {
        SettingEndpoints endpoints = new SettingEndpoints();        
        RestClient client = new RestClient();
        
        public void CreateList()
        {
            if (string.IsNullOrEmpty(BoardProperties.CreatedIdBoard))
            {
                throw new Exception("Id board doesn't exist");
            }

            var listBody = new
            {
                name = "Rest Api list",
                idBoard = BoardProperties.CreatedIdBoard,
            };
            var request = new RestRequest($"{endpoints.listsEndpoint}", Method.Post);
            request.AddQueryParameter("name", listBody.name);
            request.AddQueryParameter("idBoard", listBody.idBoard);
            request.AddQueryParameter("key", Tokens.trelloApiKey);
            request.AddQueryParameter("token", Tokens.trelloApiToken);
            var response = client.ExecuteAsync(request).Result;            
            var jsonResponse = JObject.Parse(response.Content);
            ListProperties.ListId = jsonResponse["id"].ToString();

            Assert.AreEqual(HttpStatusCode.OK, response.StatusCode);
            Assert.AreEqual(listBody.name, jsonResponse["name"]);                
            Assert.AreEqual(ListProperties.ListId, jsonResponse["id"]);
            Console.WriteLine(jsonResponse["id"].ToString());
        }

        public void UpdateListId()
        {
            if (string.IsNullOrEmpty(ListProperties.ListId))
            {
                throw new Exception("Id board doesn't exist");
            }

            var listBody = new
            {
                name = "Rest api list updated",
                closed = false,                            
            };

            var request = new RestRequest($"{endpoints.listIdEndpoint}", Method.Put).AddBody(listBody);            
            request.AddQueryParameter("key", Tokens.trelloApiKey);
            request.AddQueryParameter("token", Tokens.trelloApiToken);
            var response = client.ExecuteAsync(request).Result;
            
            Assert.AreEqual(HttpStatusCode.OK, response.StatusCode);

            var jsonResponse = JObject.Parse(response.Content);            
            Assert.AreEqual(false, jsonResponse["closed"]);
            Assert.AreEqual(JTokenType.Integer, jsonResponse["pos"]?.Type);
        }        

        public void GetListId()
        {         
            if (string.IsNullOrEmpty(ListProperties.ListId))
            {
                throw new Exception("Id list doesn't exist");
            }

            var request = new RestRequest($"{endpoints.listIdEndpoint}", Method.Get);            
            request.AddQueryParameter("key", Tokens.trelloApiKey);
            request.AddQueryParameter("token", Tokens.trelloApiToken);
            var response = client.ExecuteAsync(request).Result;            

            Assert.AreEqual(HttpStatusCode.OK, response.StatusCode);
        }

        public void ArchiveAllCardsInList()
        {
            if (string.IsNullOrEmpty(ListProperties.ListId))
            {
                throw new Exception("Id board doesn't exist");
            }

            var request = new RestRequest($"{endpoints.archiveAllcardsEndpoint}", Method.Post);
            request.AddQueryParameter("key", Tokens.trelloApiKey);
            request.AddQueryParameter("token", Tokens.trelloApiToken);
            var response = client.ExecuteAsync(request).Result;

            Assert.AreEqual(HttpStatusCode.OK, response.StatusCode);
        }        
    }
}
