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
            var response = ApiMethods.PostBodyRequestApiAsync(endpoints.listsEndpoint, listBody);
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

            var request = new RestRequest($"{endpoints.listIdEndpoint}", Method.Put).AddBody(listBody);            
            request.AddQueryParameter("key", Tokens.trelloApiKey);
            request.AddQueryParameter("token", Tokens.trelloApiToken);
            var response = MainRestApiUrl.Client.ExecuteAsync(request).Result;
            
            Assert.AreEqual(HttpStatusCode.OK, response.StatusCode);

            var jsonResponse = JObject.Parse(response.Content);            
            Assert.AreEqual(false, jsonResponse["closed"]);
            Assert.AreEqual(JTokenType.Integer, jsonResponse["pos"]?.Type);
        }        

        public void GetListId()
        {         
            if (string.IsNullOrEmpty(ObjectProperties.ListProperties.ListId))
            {
                throw new Exception("Id list doesn't exist");
            }
            var response = ApiMethods.GetRequestApiAsync(endpoints.listIdEndpoint);
            Assert.AreEqual(HttpStatusCode.OK, response.StatusCode);
        }

        public void ArchiveAllCardsInList()
        {
            if (string.IsNullOrEmpty(ObjectProperties.ListProperties.ListId))
            {
                throw new Exception("Id board doesn't exist");
            }

            var request = new RestRequest($"{endpoints.archiveAllcardsEndpoint}", Method.Post);
            request.AddQueryParameter("key", Tokens.trelloApiKey);
            request.AddQueryParameter("token", Tokens.trelloApiToken);
            var response = MainRestApiUrl.Client.ExecuteAsync(request).Result;

            Assert.AreEqual(HttpStatusCode.OK, response.StatusCode);
        }        
    }
}
