using System.Net;
using System.Text.RegularExpressions;

namespace TrelloApiTests.Methods
{    
    public class BoardMethods
    {
        string pattern = "[A-Za-z0-9]";       

        RestClient client = new RestClient();
        SettingEndpoints endpoints = new SettingEndpoints();        
        Tokens tokensForBoards = new Tokens();
        
        public void CreateBoard()
        {
            var boardBody = new
            {
                name = "New rest api board",                
                desc = "Random",
            };

            var request = new RestRequest($"{endpoints.boardsEndpoint}", Method.Post).AddBody(boardBody);            
            request.AddQueryParameter("key", Tokens.trelloApiKey);
            request.AddQueryParameter("token", Tokens.trelloApiToken);
            var response = client.ExecuteAsync(request).Result;
            
            var jsonResponse = JObject.Parse(response.Content);
            var checkPatternIdProperty = jsonResponse["id"].ToString();
            var checkPattern = Regex.IsMatch(checkPatternIdProperty, pattern);
            var checkPermissionLever = jsonResponse["prefs"]?["permissionLevel"]?.ToString();

            BoardProperties.CreatedIdBoard = jsonResponse["id"].ToString();
            BoardProperties.IdOrganization = jsonResponse["idOrganization"].ToString();

            Assert.AreEqual(HttpStatusCode.OK, response.StatusCode);
            Assert.AreEqual(JTokenType.String, jsonResponse["name"]?.Type);
            Assert.AreEqual(boardBody.name, jsonResponse["name"]);
            Assert.AreEqual(JTokenType.String, jsonResponse["desc"]?.Type);
            Assert.AreEqual(boardBody.desc, jsonResponse["desc"]);
            Assert.AreEqual(BoardProperties.CreatedIdBoard, jsonResponse["id"]);
            Assert.AreEqual(BoardProperties.IdOrganization, jsonResponse["idOrganization"]);
            Assert.IsTrue(checkPattern);
            Assert.AreEqual("private", checkPermissionLever);
            Console.WriteLine(jsonResponse);            
        }

        public void CreateACalendarKeyForABoard()
        {
            var calendarKey = new
            {
                id = tokensForBoards.calendarKey
            };        
            
            if (string.IsNullOrEmpty(BoardProperties.CreatedIdBoard))
            {
                throw new Exception("Board id is empty");
            }

            else
            {
                var request = new RestRequest($"{endpoints.calendarEndpoint}", Method.Post).AddBody(calendarKey);
                request.AddQueryParameter("key", Tokens.trelloApiKey);
                request.AddQueryParameter("token", Tokens.trelloApiToken);
                var response = client.Execute(request);

                Assert.IsNotNull(BoardProperties.CreatedIdBoard);
                Assert.AreEqual(HttpStatusCode.Forbidden, response.StatusCode);
            }                
        }

        public void CreateEmailKeyForABoard()
        {
            if (string.IsNullOrEmpty(BoardProperties.CreatedIdBoard))
            {
                throw new Exception("Created board ID is null or empty.");
            }           

            var request = new RestRequest($"{endpoints.emailEndpoint}", Method.Post);
            request.AddQueryParameter("key", Tokens.trelloApiKey);
            request.AddQueryParameter("token", Tokens.trelloApiToken);
            var response = client.Execute(request);

            Assert.AreEqual(HttpStatusCode.OK, response.StatusCode);            
        }

        public void GetBoard()
        {
            if (string.IsNullOrEmpty(BoardProperties.CreatedIdBoard))
            {
                throw new Exception("Board id is empty");
            }

            var request = new RestRequest($"{endpoints.boardIdEndpoint}", Method.Get);
            request.AddQueryParameter("key", Tokens.trelloApiKey);
            request.AddQueryParameter("token", Tokens.trelloApiToken);
            var response = client.Execute(request);
            
            var jsonResponse = JObject.Parse(response.Content);
            Assert.AreEqual(BoardProperties.CreatedIdBoard, jsonResponse["id"]);
            Assert.AreEqual(HttpStatusCode.OK, response.StatusCode);
        }

        public void MarkBoardViewed()
        {
            var request = new RestRequest($"{endpoints.markedAsViewedEndpoint}", Method.Post);
            request.AddQueryParameter("key", Tokens.trelloApiKey);
            request.AddQueryParameter("token", Tokens.trelloApiToken);
            var response = client.ExecuteAsync(request).Result;                       
            var jsonResponse = JObject.Parse(response.Content);

            Assert.AreEqual(BoardProperties.CreatedIdBoard, jsonResponse["id"]);
            
            if (HttpStatusCode.OK != response.StatusCode)
            {
                throw new Exception(response.StatusCode.ToString());
            }
        }

        public void UpdateBoard()
        {
            if (string.IsNullOrEmpty(BoardProperties.CreatedIdBoard))
            {
                throw new Exception("Created board ID is null or empty.");
            }

            var boardBody = new
            {
                name = "New rest api board updated",
                prefs_permissionLevel = "org"
            };
            var request = new RestRequest($"{endpoints.boardIdEndpoint}", Method.Put).AddBody(boardBody);
            request.AddQueryParameter("key", Tokens.trelloApiKey);
            request.AddQueryParameter("token", Tokens.trelloApiToken);
            var response = client.Execute(request);            
            var jsonResponse = JObject.Parse(response.Content);

            Assert.AreEqual(HttpStatusCode.OK, response.StatusCode);
            Assert.AreEqual(boardBody.name, jsonResponse["name"]);            
        }

        public void MarkBoardAsViewed()
        {
            if (string.IsNullOrEmpty(BoardProperties.CreatedIdBoard))
            {
                throw new Exception("Created board ID is null or empty.");
            }

            var request = new RestRequest($"{endpoints.markedAsViewedEndpoint}", Method.Post);
            request.AddQueryParameter("key", Tokens.trelloApiKey);
            request.AddQueryParameter("token", Tokens.trelloApiToken);
            var response = client.ExecuteAsync(request).Result;            

            Assert.AreEqual(HttpStatusCode.OK, response.StatusCode);            
        }

        public void DeleteBoard()
        {
            if (string.IsNullOrEmpty(BoardProperties.CreatedIdBoard))
            {
                throw new InvalidOperationException("Created board ID is null.");
            }
            
            var request = new RestRequest($"{endpoints.boardIdEndpoint}", Method.Delete);
            request.AddQueryParameter("key", Tokens.trelloApiKey);
            request.AddQueryParameter("token", Tokens.trelloApiToken);
            var response = client.Execute(request);

            Assert.AreEqual(HttpStatusCode.OK, response.StatusCode);           
        }

        public void CleanBoardId()
        {
            if (BoardProperties.CreatedIdBoard != null) 
            {
                BoardProperties.CreatedIdBoard = null;
            }
            
        }
    }
}
