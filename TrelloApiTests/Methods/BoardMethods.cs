using TrelloApiTests.ObjectsProperties;
namespace TrelloApiTests.Methods
{   
    public class BoardMethods
    {        
        public readonly SettingEndpoints endpoints = new SettingEndpoints();        
        public readonly Tokens tokensForBoards = new Tokens();        

        string randomString = StringGenerator.GenerateString(15);

        public void CreateBoard()
        {                                 
            var boardBody = new ObjectProperties.BoardProperties
            {
                name = randomString,
                desc = randomString,
            };
            var response = ApiMethods.PostBodyRequestApiAsync(endpoints.boardsEndpoint, boardBody);
            var jsonResponse = JObject.Parse(response.Content);            
            BoardProperties.id = jsonResponse["id"]?.ToString();
            BoardProperties.idOrganization = jsonResponse["idOrganization"]?.ToString();
            ApiMethods.StringPatternCheck(response, "name");
            Assert.AreEqual(HttpStatusCode.OK, response.StatusCode);
            Assert.AreEqual(JTokenType.String, jsonResponse["name"]?.Type);            
            Assert.AreEqual(boardBody.name, jsonResponse["name"]);
            Assert.AreEqual(JTokenType.String, jsonResponse["desc"]?.Type);
            Assert.AreEqual(boardBody.desc, jsonResponse["desc"]);
            Assert.AreEqual(BoardProperties.id, jsonResponse["id"]);
            Assert.AreEqual(BoardProperties.idOrganization, jsonResponse["idOrganization"]);            
            Console.WriteLine(jsonResponse);            
        }

        public void CreateACalendarKeyForABoard()
        {
            var calendarKeyBody = new
            {
                id = Tokens.calendarKey
            };        
            
            if (string.IsNullOrEmpty(BoardProperties.id))
            {
            
                throw new Exception("Board id is empty");
            }            
            else
            {
                var response = ApiMethods.PostBodyRequestApiAsync(endpoints.CalendarEndpoint(BoardProperties.id), calendarKeyBody);
                Assert.IsNotNull(BoardProperties.id);
                Assert.AreEqual(HttpStatusCode.Forbidden, response.StatusCode);
            }                
        }

        public void CreateEmailKeyForABoard()
        {
            if (string.IsNullOrEmpty(BoardProperties.id))
            {
                throw new Exception("Created board ID is null or empty.");
            }            
            var response = ApiMethods.PostRequestApiAsync(endpoints.EmailEndpoint(BoardProperties.id));
            Assert.AreEqual(HttpStatusCode.OK, response.StatusCode);            
        }

        public void GetBoard()
        {
            if (string.IsNullOrEmpty(BoardProperties.id))
            {
                throw new Exception("Created board ID is null or empty.");
            }
            else
            {
                var response = ApiMethods.GetRequestApiAsync(endpoints.boardIdEndpoint(BoardProperties.id));
                var jsonResponse = JObject.Parse(response.Content);
                Assert.AreEqual(BoardProperties.id, jsonResponse["id"]);
                Assert.AreEqual(HttpStatusCode.OK, response.StatusCode);
            }                
        }

        public void MarkBoardViewed()
        {            
            var response = ApiMethods.PostRequestApiAsync(endpoints.markedAsViewedEndpoint(BoardProperties.id));
            var jsonResponse = JObject.Parse(response.Content);
            Assert.AreEqual(BoardProperties.id, jsonResponse["id"]);
            Assert.AreEqual(HttpStatusCode.OK, response.StatusCode);
        }

        public void UpdateBoard()
        {
            if (string.IsNullOrEmpty(BoardProperties.id))
            {
                throw new Exception("Created board ID is null or empty.");
            }
            var boardBody = new
            {
                name = randomString,                
            };            
            var response = ApiMethods.PutBodyRequestApiAsync(endpoints.boardIdEndpoint( BoardProperties.id), boardBody);
            var jsonResponse = JObject.Parse(response.Content);
            Assert.AreEqual(HttpStatusCode.OK, response.StatusCode);
            Assert.AreEqual(boardBody.name, jsonResponse["name"]);
            Assert.AreEqual("private", jsonResponse["prefs"]?["permissionLevel"]?.ToString());
            Console.WriteLine(jsonResponse);
        }

        public void MarkBoardAsViewed()
        {
            if (string.IsNullOrEmpty(BoardProperties.id))
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
            if (string.IsNullOrEmpty(BoardProperties.id))
            {
                throw new InvalidOperationException("Created board ID is null.");
            }
            var response = ApiMethods.DeleteRequestApiAsync(endpoints.boardIdEndpoint(BoardProperties.id));
            Assert.AreEqual(HttpStatusCode.OK, response.StatusCode);           
        }        
    }
}
