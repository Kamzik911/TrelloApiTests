namespace TrelloApiTests.Methods
{   
    public class BoardMethods
    {
        string pattern = "[A-Za-z0-9]";
        
        SettingEndpoints endpoints = new SettingEndpoints();        
        Tokens tokensForBoards = new Tokens();

        string randomString = StringIntGenerator.GenerateString(15);

        public void CreateBoard()
        {            
                     
            var boardBody = new ObjectProperties.BoardProperties
            {
                name = randomString,
                desc = randomString,
            };
            var response = ApiMethods.PostBodyRequestApiAsync(endpoints.boardsEndpoint, boardBody);
            var jsonResponse = JObject.Parse(response.Content);
            var checkPatternIdProperty = jsonResponse["id"]?.ToString();
            var checkPattern = Regex.IsMatch(checkPatternIdProperty, pattern);
            var checkPermissionLevel = jsonResponse["prefs"]?["permissionLevel"]?.ToString();

            ObjectProperties.BoardProperties.CreatedIdBoard = jsonResponse["id"]?.ToString();
            ObjectProperties.BoardProperties.IdOrganization = jsonResponse["idOrganization"]?.ToString();

            Assert.AreEqual(HttpStatusCode.OK, response.StatusCode);
            Assert.AreEqual(JTokenType.String, jsonResponse["name"]?.Type);
            Assert.AreEqual(boardBody.name, jsonResponse["name"]);
            Assert.AreEqual(JTokenType.String, jsonResponse["desc"]?.Type);
            Assert.AreEqual(boardBody.desc, jsonResponse["desc"]);
            Assert.AreEqual(ObjectProperties.BoardProperties.CreatedIdBoard, jsonResponse["id"]);
            Assert.AreEqual(ObjectProperties.BoardProperties.IdOrganization, jsonResponse["idOrganization"]);
            Assert.IsTrue(checkPattern);
            Assert.AreEqual("private", checkPermissionLevel);
            Console.WriteLine(jsonResponse);            
        }

        public void CreateACalendarKeyForABoard()
        {
            var calendarKey = new
            {
                id = tokensForBoards.calendarKey
            };        
            
            if (string.IsNullOrEmpty(ObjectProperties.BoardProperties.CreatedIdBoard))
            {
                throw new Exception("Board id is empty");
            }

            else
            {
                var response = ApiMethods.PostBodyRequestApiAsync(endpoints.calendarEndpoint, calendarKey);
                Assert.IsNotNull(ObjectProperties.BoardProperties.CreatedIdBoard);
                Assert.AreEqual(HttpStatusCode.Forbidden, response.StatusCode);
            }                
        }

        public void CreateEmailKeyForABoard()
        {
            if (string.IsNullOrEmpty(ObjectProperties.BoardProperties.CreatedIdBoard))
            {
                throw new Exception("Created board ID is null or empty.");
            }            
            var response = ApiMethods.PostRequestApiAsync(endpoints.emailEndpoint);
            Assert.AreEqual(HttpStatusCode.OK, response.StatusCode);            
        }

        public void GetBoard()
        {
            if (string.IsNullOrEmpty(ObjectProperties.BoardProperties.CreatedIdBoard))
            {
                throw new Exception("Created board ID is null or empty.");
            }
            else
            {
                var response = ApiMethods.GetRequestApiAsync(endpoints.boardIdEndpoint);
                var jsonResponse = JObject.Parse(response.Content);
                Assert.AreEqual(ObjectProperties.BoardProperties.CreatedIdBoard, jsonResponse["id"]);
                Assert.AreEqual(HttpStatusCode.OK, response.StatusCode);
            }                
        }

        public void MarkBoardViewed()
        {            
            var response = ApiMethods.PostRequestApiAsync(endpoints.markedAsViewedEndpoint);
            var jsonResponse = JObject.Parse(response.Content);
            Assert.AreEqual(ObjectProperties.BoardProperties.CreatedIdBoard, jsonResponse["id"]);
            Assert.AreEqual(HttpStatusCode.OK, response.StatusCode);
        }

        public void UpdateBoard()
        {
            if (string.IsNullOrEmpty(ObjectProperties.BoardProperties.CreatedIdBoard))
            {
                throw new Exception("Created board ID is null or empty.");
            }
            var boardBody = new
            {
                name = randomString,                
            };            
            var response = ApiMethods.PutBodyRequestApiAsync(endpoints.boardIdEndpoint, boardBody);
            var jsonResponse = JObject.Parse(response.Content);
            Assert.AreEqual(HttpStatusCode.OK, response.StatusCode);
            Assert.AreEqual(boardBody.name, jsonResponse["name"]);
            Assert.AreEqual("private", jsonResponse["prefs"]?["permissionLevel"]?.ToString());
            Console.WriteLine(jsonResponse);
        }

        public void MarkBoardAsViewed()
        {
            if (string.IsNullOrEmpty(ObjectProperties.BoardProperties.CreatedIdBoard))
            {
                throw new Exception("Created board ID is null or empty.");
            }

            var request = new RestRequest($"{endpoints.markedAsViewedEndpoint}", Method.Post);
            request.AddQueryParameter("key", Tokens.trelloApiKey);
            request.AddQueryParameter("token", Tokens.trelloApiToken);
            var response = MainRestApiUrl.Client.ExecuteAsync(request).Result;            

            Assert.AreEqual(HttpStatusCode.OK, response.StatusCode);            
        }

        public void DeleteBoard()
        {
            if (string.IsNullOrEmpty(ObjectProperties.BoardProperties.CreatedIdBoard))
            {
                throw new InvalidOperationException("Created board ID is null.");
            }
            
            var request = new RestRequest($"{endpoints.boardIdEndpoint}", Method.Delete);
            request.AddQueryParameter("key", Tokens.trelloApiKey);
            request.AddQueryParameter("token", Tokens.trelloApiToken);
            var response = MainRestApiUrl.Client.Execute(request);

            Assert.AreEqual(HttpStatusCode.OK, response.StatusCode);           
        }

        public void CleanBoardId()
        {
            if (ObjectProperties.BoardProperties.CreatedIdBoard != null) 
            {
                ObjectProperties.BoardProperties.CreatedIdBoard = null;
            }
            
        }
    }
}
