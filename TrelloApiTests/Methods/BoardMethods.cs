using TrelloApiTests.Utils;

namespace TrelloApiTests.Methods
{
    public class BoardMethods : BoardProperties
    {
        private readonly SettingEndpoints endpoints;
        private readonly ApiMethods apiClient;

        public BoardMethods()
        {
            this.apiClient = new ApiMethods();
            this.endpoints = new SettingEndpoints();
        }

        private string randomString = StringGenerator.GenerateString(15);

        public async Task CreateBoard()
        {
            var boardBody = new
            {
                name = this.randomString,
                desc = this.randomString,
            };

            var response = await apiClient.PostBodyRequestApiAsync(endpoints.boardsEndpoint, boardBody).ConfigureAwait(false);
            JObject jsonObjects = JObject.Parse(response.Content);            
            Id = jsonObjects["id"].ToString();
            IdOrganization = jsonObjects["idOrganization"].ToString();            
            Assert.IsNotNull(Id);
            Assert.IsNotNull(IdOrganization);
            Assert.AreEqual(HttpStatusCode.OK, response.StatusCode);
            ResponseValidator.StringPatternCheck(response, "name");
            Assert.AreEqual(JTokenType.String, jsonObjects["name"]?.Type);
            Assert.AreEqual(boardBody.name, jsonObjects["name"]);
            Assert.AreEqual(JTokenType.String, jsonObjects ["desc"]?.Type);
            Assert.AreEqual(boardBody.desc, jsonObjects["desc"]);
        }

        public async Task CreateACalendarKeyForABoard()
        {            
            if (Id != null)
            {
                var calendarKeyBody = new
                {
                    id = Tokens.calendarKey,
                };
                var response = await apiClient.PostBodyRequestApiAsync(endpoints.CalendarEndpoint(Id), calendarKeyBody).ConfigureAwait(false);
                Assert.AreEqual(HttpStatusCode.Forbidden, response.StatusCode);
            }            
        }

        public async Task CreateEmailKeyForABoard()
        {
            if (string.IsNullOrEmpty(Id))
            {
                throw new Exception("Created board ID is null or empty.");
            }
            var response = await apiClient.PostRequestApiAsync(endpoints.EmailEndpoint(Id)).ConfigureAwait(false);
            Assert.AreEqual(HttpStatusCode.OK, response.StatusCode);
            JObject jsonResponse = JObject.Parse(response.Content);
            string emailId = jsonResponse["myPrefs"]["idEmailList"].ToString();            
            Assert.IsNotNull(emailId);
        }

        public async Task GetBoard()
        {
            if (string.IsNullOrEmpty(Id))
            {
                throw new Exception("Created board ID is null or empty.");
            }
            else
            {
                var response = await apiClient.GetRequestApiAsync(endpoints.BoardIdEndpoint(Id)).ConfigureAwait(false);
                var jsonResponse = JObject.Parse(response.Content);
                Assert.AreEqual(Id, jsonResponse["id"]);
                Assert.AreEqual(HttpStatusCode.OK, response.StatusCode);
            }            
        }

        public async Task MarkBoardViewed()
        {
            var response = await apiClient.PostRequestApiAsync(endpoints.MarkedAsViewedEndpoint(Id)).ConfigureAwait(false);
            var jsonResponse = JObject.Parse(response.Content);
            Assert.AreEqual(Id, jsonResponse["id"]);
            Assert.AreEqual(HttpStatusCode.OK, response.StatusCode);
        }

        public async Task UpdateBoard()
        {
            if (string.IsNullOrEmpty(Id))
            {
                throw new Exception("Created board ID is null or empty.");
            }
            var boardBody = new
            {
                name = this.randomString,
            };
            var response = await apiClient.PutBodyRequestApiAsync(endpoints.BoardIdEndpoint(Id), boardBody).ConfigureAwait(false);
            var jsonResponse = JObject.Parse(response.Content);
            Assert.AreEqual(HttpStatusCode.OK, response.StatusCode);
            Assert.AreEqual(boardBody.name, jsonResponse["name"]);
            Assert.AreEqual("private", jsonResponse["prefs"]?["permissionLevel"]?.ToString());            
        }

        public async Task MarkBoardAsViewed()
        {
            if (string.IsNullOrEmpty(Id))
            {
                throw new Exception("Created board ID is null or empty.");
            }

            var request = new RestRequest(endpoints.MarkedAsViewedEndpoint(Id), Method.Post);
            request.AddQueryParameter("key", Tokens.trelloApiKey);
            request.AddQueryParameter("token", Tokens.trelloApiToken);
            var response = await MainRestApiUrl.Client.ExecuteAsync(request).ConfigureAwait(false);

            Assert.AreEqual(HttpStatusCode.OK, response.StatusCode);
        }

        public async Task DeleteBoard()
        {
            if (string.IsNullOrEmpty(Id))
            {
                throw new InvalidOperationException("Created board ID is null.");
            }
            var response = await apiClient.DeleteRequestApiAsync(endpoints.BoardIdEndpoint(Id)).ConfigureAwait(false);
            Assert.AreEqual(HttpStatusCode.OK, response.StatusCode);
            JObject jsonResponse = JObject.Parse(response.Content);
            bool idBoardIsNull = jsonResponse["id"] == null;
            Assert.IsTrue(idBoardIsNull);
        }
    }
}