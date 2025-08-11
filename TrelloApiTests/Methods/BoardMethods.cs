namespace TrelloApiTests.Methods
{
    public class BoardMethods : BoardProperties
    {
        private static readonly SettingEndpoints endpoints = new SettingEndpoints();
        private readonly Tokens tokensForBoards = new Tokens();

        private string randomString = StringGenerator.GenerateString(15);

        public async Task CreateBoard()
        {
            var boardBody = new
            {
                name = this.randomString,
                desc = this.randomString,
            };
            var response = await ApiMethods.PostBodyRequestApiAsync(endpoints.boardsEndpoint, boardBody).ConfigureAwait(false);
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

        public async Task CreateACalendarKeyForABoard()
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
                var response = await ApiMethods.PostBodyRequestApiAsync(endpoints.CalendarEndpoint(id), calendarKeyBody).ConfigureAwait(false);
                Assert.IsNotNull(id);
                Assert.AreEqual(HttpStatusCode.Forbidden, response.StatusCode);
            }
        }

        public async Task CreateEmailKeyForABoard()
        {
            if (string.IsNullOrEmpty(id))
            {
                throw new Exception("Created board ID is null or empty.");
            }
            var response = await ApiMethods.PostRequestApiAsync(endpoints.EmailEndpoint(id)).ConfigureAwait(false);
            Assert.AreEqual(HttpStatusCode.OK, response.StatusCode);
        }

        public async Task GetBoard()
        {
            if (string.IsNullOrEmpty(id))
            {
                throw new Exception("Created board ID is null or empty.");
            }
            else
            {
                var response = await ApiMethods.GetRequestApiAsync(endpoints.BoardIdEndpoint(id)).ConfigureAwait(false);
                var jsonResponse = JObject.Parse(response.Content);
                Assert.AreEqual(id, jsonResponse["id"]);
                Assert.AreEqual(HttpStatusCode.OK, response.StatusCode);
            }            
        }

        public async Task MarkBoardViewed()
        {
            var response = await ApiMethods.PostRequestApiAsync(endpoints.MarkedAsViewedEndpoint(id)).ConfigureAwait(false);
            var jsonResponse = JObject.Parse(response.Content);
            Assert.AreEqual(id, jsonResponse["id"]);
            Assert.AreEqual(HttpStatusCode.OK, response.StatusCode);
        }

        public async Task UpdateBoard()
        {
            if (string.IsNullOrEmpty(id))
            {
                throw new Exception("Created board ID is null or empty.");
            }
            var boardBody = new
            {
                name = this.randomString,
            };
            var response = await ApiMethods.PutBodyRequestApiAsync(endpoints.BoardIdEndpoint(id), boardBody).ConfigureAwait(false);
            var jsonResponse = JObject.Parse(response.Content);
            Assert.AreEqual(HttpStatusCode.OK, response.StatusCode);
            Assert.AreEqual(boardBody.name, jsonResponse["name"]);
            Assert.AreEqual("private", jsonResponse["prefs"]?["permissionLevel"]?.ToString());
            Console.WriteLine(jsonResponse);
        }

        public async Task MarkBoardAsViewed()
        {
            if (string.IsNullOrEmpty(id))
            {
                throw new Exception("Created board ID is null or empty.");
            }

            var request = new RestRequest(endpoints.MarkedAsViewedEndpoint(id), Method.Post);
            request.AddQueryParameter("key", Tokens.trelloApiKey);
            request.AddQueryParameter("token", Tokens.trelloApiToken);
            var response = await MainRestApiUrl.Client.ExecuteAsync(request).ConfigureAwait(false);

            Assert.AreEqual(HttpStatusCode.OK, response.StatusCode);
        }

        public async Task DeleteBoard()
        {
            if (string.IsNullOrEmpty(id))
            {
                throw new InvalidOperationException("Created board ID is null.");
            }
            var response = await ApiMethods.DeleteRequestApiAsync(endpoints.BoardIdEndpoint(id)).ConfigureAwait(false);
            Assert.AreEqual(HttpStatusCode.OK, response.StatusCode);
        }
    }
}
