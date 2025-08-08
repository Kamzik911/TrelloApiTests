namespace TrelloApiTests.Methods
{
    public class BoardMethods : BoardProperties
    {
        private readonly SettingEndpoints endpoints = new SettingEndpoints();
        private readonly Tokens tokensForBoards = new Tokens();

        private string randomString = StringGenerator.GenerateString(15);

        public void CreateBoard()
        {
            var boardBody = new
            {
                name = this.randomString,
                desc = this.randomString,
            };
            var response = ApiMethods.PostBodyRequestApiAsync(this.endpoints.boardsEndpoint, boardBody);
            JObject jsonObjects = JObject.Parse(response.Content);
            id = jsonObjects["id"].ToString();
            idOrganization = jsonObjects["idOrganization"]?.ToString();
            Assert.AreEqual(HttpStatusCode.OK, response.StatusCode);
            ApiMethods.StringPatternCheck(response, "name");
            Assert.AreEqual(JTokenType.String, jsonObjects["name"]?.Type);
            Assert.AreEqual(boardBody.name, jsonObjects["name"]);
            Assert.AreEqual(JTokenType.String, jsonObjects ["desc"]?.Type);
            Assert.AreEqual(boardBody.desc, jsonObjects["desc"]);
        }

        public void CreateACalendarKeyForABoard()
        {
            var calendarKeyBody = new
            {
                id = Tokens.calendarKey,
            };

            if (string.IsNullOrEmpty(id))
            {
                throw new Exception("Board id is empty");
            }
            else
            {
                var response = ApiMethods.PostBodyRequestApiAsync(this.endpoints.CalendarEndpoint(id), calendarKeyBody);
                Assert.IsNotNull(id);
                Assert.AreEqual(HttpStatusCode.Forbidden, response.StatusCode);
            }
        }

        public void CreateEmailKeyForABoard()
        {
            if (string.IsNullOrEmpty(id))
            {
                throw new Exception("Created board ID is null or empty.");
            }
            var response = ApiMethods.PostRequestApiAsync(this.endpoints.EmailEndpoint(id));
            Assert.AreEqual(HttpStatusCode.OK, response.StatusCode);
        }

        public void GetBoard()
        {
            if (string.IsNullOrEmpty(id))
            {
                throw new Exception("Created board ID is null or empty.");
            }
            else
            {
                var response = ApiMethods.GetRequestApiAsync(this.endpoints.BoardIdEndpoint(id));
                var jsonResponse = JObject.Parse(response.Content);
                Assert.AreEqual(id, jsonResponse["id"]);
                Assert.AreEqual(HttpStatusCode.OK, response.StatusCode);
            }
        }

        public void MarkBoardViewed()
        {
            var response = ApiMethods.PostRequestApiAsync(this.endpoints.MarkedAsViewedEndpoint(id));
            var jsonResponse = JObject.Parse(response.Content);
            Assert.AreEqual(id, jsonResponse["id"]);
            Assert.AreEqual(HttpStatusCode.OK, response.StatusCode);
        }

        public void UpdateBoard()
        {
            if (string.IsNullOrEmpty(id))
            {
                throw new Exception("Created board ID is null or empty.");
            }
            var boardBody = new
            {
                name = this.randomString,
            };
            var response = ApiMethods.PutBodyRequestApiAsync(this.endpoints.BoardIdEndpoint(id), boardBody);
            var jsonResponse = JObject.Parse(response.Content);
            Assert.AreEqual(HttpStatusCode.OK, response.StatusCode);
            Assert.AreEqual(boardBody.name, jsonResponse["name"]);
            Assert.AreEqual("private", jsonResponse["prefs"]?["permissionLevel"]?.ToString());
            Console.WriteLine(jsonResponse);
        }

        public void MarkBoardAsViewed()
        {
            if (string.IsNullOrEmpty(id))
            {
                throw new Exception("Created board ID is null or empty.");
            }

            var request = new RestRequest($"{this.endpoints.MarkedAsViewedEndpoint}", Method.Post);
            request.AddQueryParameter("key", Tokens.trelloApiKey);
            request.AddQueryParameter("token", Tokens.trelloApiToken);
            var response = MainRestApiUrl.Client.ExecuteAsync(request).Result;

            Assert.AreEqual(HttpStatusCode.OK, response.StatusCode);
        }

        public void DeleteBoard()
        {
            if (string.IsNullOrEmpty(id))
            {
                throw new InvalidOperationException("Created board ID is null.");
            }
            var response = ApiMethods.DeleteRequestApiAsync(this.endpoints.BoardIdEndpoint(id));
            Assert.AreEqual(HttpStatusCode.OK, response.StatusCode);
        }
    }
}
