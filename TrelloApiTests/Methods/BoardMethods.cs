using TrelloApiTests.ObjectsProperties;
using TrelloApiTests.Utils;

namespace TrelloApiTests.Methods
{
    public class BoardMethods
    {
        private readonly EndpointsSetup endpoints = new EndpointsSetup();
        private readonly ApiMethods apiClient;
        private readonly BoardProperties boardProperties;

        public BoardMethods(BoardProperties boardProperties)
        {
            this.apiClient = new ApiMethods();            
            this.boardProperties = boardProperties;
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
            boardProperties.Id = jsonObjects["id"].ToString();
            boardProperties.IdOrganization = jsonObjects["idOrganization"].ToString();            
            Assert.IsNotNull(boardProperties.Id);
            Assert.IsNotNull(boardProperties.IdOrganization);
            Assert.AreEqual(HttpStatusCode.OK, response.StatusCode);
            ResponseValidator.StringPatternCheck(response, "name");
            Assert.AreEqual(JTokenType.String, jsonObjects["name"]?.Type);
            Assert.AreEqual(boardBody.name, jsonObjects["name"]);
            Assert.AreEqual(JTokenType.String, jsonObjects ["desc"]?.Type);
            Assert.AreEqual(boardBody.desc, jsonObjects["desc"]);
        }

        public async Task CreateACalendarKeyForABoard()
        {            
            if (boardProperties.Id != null)
            {
                var calendarKeyBody = new
                {
                    id = Tokens.calendarKey,
                };
                var response = await apiClient.PostBodyRequestApiAsync(endpoints.CalendarEndpoint(boardProperties.Id), calendarKeyBody).ConfigureAwait(false);
                Assert.AreEqual(HttpStatusCode.Forbidden, response.StatusCode);
            }            
        }

        public async Task CreateEmailKeyForABoard()
        {
            if (string.IsNullOrEmpty(boardProperties.Id))
            {
                throw new Exception("Created board ID is null or empty.");
            }
            var response = await apiClient.PostRequestApiAsync(endpoints.EmailEndpoint(boardProperties.Id)).ConfigureAwait(false);
            Assert.AreEqual(HttpStatusCode.OK, response.StatusCode);
            JObject jsonResponse = JObject.Parse(response.Content);
            string emailId = jsonResponse["myPrefs"]["idEmailList"].ToString();            
            Assert.IsNotNull(emailId);
        }

        public async Task GetBoard()
        {
            if (string.IsNullOrEmpty(boardProperties.Id))
            {
                throw new Exception("Created board ID is null or empty.");
            }
            else
            {
                var response = await apiClient.GetRequestApiAsync(endpoints.BoardIdEndpoint(boardProperties.Id)).ConfigureAwait(false);
                var jsonResponse = JObject.Parse(response.Content);
                Assert.AreEqual(boardProperties.Id, jsonResponse["id"]);
                Assert.AreEqual(HttpStatusCode.OK, response.StatusCode);
            }
        }
        
        public async Task MarkBoardViewed()
        {
            var response = await apiClient.PostRequestApiAsync(endpoints.MarkedAsViewedEndpoint(boardProperties.Id)).ConfigureAwait(false);
            var jsonResponse = JObject.Parse(response.Content);
            Assert.AreEqual(boardProperties.Id, jsonResponse["id"]);
            Assert.AreEqual(HttpStatusCode.OK, response.StatusCode);
        }

        public async Task UpdateBoard()
        {
            if (string.IsNullOrEmpty(boardProperties.Id))
            {
                throw new Exception("Created board ID is null or empty.");
            }
            var boardBody = new
            {
                name = this.randomString,
            };
            var response = await apiClient.PutBodyRequestApiAsync(endpoints.BoardIdEndpoint(boardProperties.Id), boardBody).ConfigureAwait(false);
            var jsonResponse = JObject.Parse(response.Content);
            Assert.AreEqual(HttpStatusCode.OK, response.StatusCode);
            Assert.AreEqual(boardBody.name, jsonResponse["name"]);
            Assert.AreEqual("private", jsonResponse["prefs"]?["permissionLevel"]?.ToString());            
        }       

        public async Task DeleteBoard()
        {
            if (string.IsNullOrEmpty(boardProperties.Id))
            {
                throw new InvalidOperationException("Created board ID is null.");
            }
            var response = await apiClient.DeleteRequestApiAsync(endpoints.BoardIdEndpoint(boardProperties.Id)).ConfigureAwait(false);
            Assert.AreEqual(HttpStatusCode.OK, response.StatusCode);
            JObject jsonResponse = JObject.Parse(response.Content);
            var idBoardIsNull = jsonResponse["id"] == null;
            Assert.IsTrue(idBoardIsNull);
        }
    }
}