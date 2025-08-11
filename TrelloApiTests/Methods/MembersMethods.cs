namespace TrelloApiTests.Methods
{
    public class MembersMethods
    {
        private SettingEndpoints endpoints = new SettingEndpoints();

        public async Task GetMemberId()
        {
            var response = await ApiMethods.GetRequestApiAsync(this.endpoints.MemberIdEndpoint(Tokens.memberId)).ConfigureAwait(false);
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
            var response = await ApiMethods.PutBodyRequestApiAsync(this.endpoints.MemberIdEndpoint(MembersProperties.id), memberBody).ConfigureAwait(false);
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
                var response = await ApiMethods.GetRequestApiAsync(this.endpoints.MemberBoardBackgroundEndpoint(MembersProperties.idBackground)).ConfigureAwait(false);
                var arrayResponse = JArray.Parse(response.Content).First;
                Assert.AreEqual(HttpStatusCode.OK, response.StatusCode);
                Console.WriteLine(arrayResponse.ToString());
                Assert.IsFalse((bool)arrayResponse["tile"]);
                ApiMethods.AlphabetArrayPatternCheck(response, "id");
                ApiMethods.AlphabetArrayPatternCheck(response, "type");
                ApiMethods.AlphabetArrayPatternCheck(response, "brightness");
                ApiMethods.StringArrayPatternCheck(response, "color");
            }            
        }
    }
}
