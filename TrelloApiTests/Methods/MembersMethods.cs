using TrelloApiTests.Utils;

namespace TrelloApiTests.Methods
{
    public class MembersMethods
    {
        private SettingEndpoints endpoints = new SettingEndpoints();
        private readonly ApiMethods apiClient;

        public MembersMethods()
        {
            this.apiClient = new ApiMethods();
        }

        public async Task GetMemberId()
        {
            var response = await apiClient.GetRequestApiAsync(this.endpoints.MemberIdEndpoint(Tokens.memberId)).ConfigureAwait(false);
            var jsonResponse = JObject.Parse(response.Content);
            Assert.AreEqual(HttpStatusCode.OK, response.StatusCode);
            MembersProperties.id = jsonResponse["id"].ToString();
            Assert.IsNotNull(MembersProperties.id);
        }

        public async Task UpdateMember() 
        {
            if (string.IsNullOrEmpty(MembersProperties.id))
            {
                throw new Exception("Member id doesn't exist");
            }

            var memberBody = new
            {
                id = Tokens.memberId,
            };
            var response = await apiClient.PutBodyRequestApiAsync(this.endpoints.MemberIdEndpoint(MembersProperties.id), memberBody).ConfigureAwait(false);
            var jsonResponse = JObject.Parse(response.Content);
            Assert.AreEqual(HttpStatusCode.OK, response.StatusCode);
        }

        public async Task GetBoardBackgroundForMember()
        {
            if (string.IsNullOrEmpty(MembersProperties.id))
            {
                throw new Exception("Member id doesn't exist");
            }
            else if (string.IsNullOrEmpty(MembersProperties.idBackground))
            {
                throw new Exception("Background id doesn't exist");
            }
            else            
            {
                var response = await apiClient.GetRequestApiAsync(this.endpoints.MemberBoardBackgroundEndpoint(MembersProperties.idBackground)).ConfigureAwait(false);
                var arrayResponse = JArray.Parse(response.Content).First;
                Assert.AreEqual(HttpStatusCode.OK, response.StatusCode);
                Console.WriteLine(arrayResponse.ToString());
                Assert.IsFalse((bool)arrayResponse["tile"]);
                Assert.IsTrue(ResponseValidator.AlphabetArrayPatternCheck(response, "id"));
                Assert.IsTrue(ResponseValidator.AlphabetArrayPatternCheck(response, "type"));
                Assert.IsTrue(ResponseValidator.AlphabetArrayPatternCheck(response, "brightness"));
                Assert.IsTrue(ResponseValidator.StringArrayPatternCheck(response, "color"));
            }            
        }
    }
}
