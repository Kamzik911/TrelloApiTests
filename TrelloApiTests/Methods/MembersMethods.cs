namespace TrelloApiTests.Methods
{
    public class MembersMethods
    {
        private SettingEndpoints endpoints = new SettingEndpoints();

        public void GetMemberId()
        {
            var response = ApiMethods.GetRequestApiAsync(this.endpoints.MemberIdEndpoint(Tokens.memberId));
            var jsonResponse = JObject.Parse(response.Content);
            Assert.AreEqual(HttpStatusCode.OK, response.StatusCode);
            MembersProperties.id = jsonResponse["id"].ToString();
            Assert.IsNotNull(MembersProperties.id);
        }

        public void UpdateMember() 
        {
            if (string.IsNullOrEmpty(MembersProperties.id))
            {
                throw new Exception("Member id doesn't exist");
            }

            var memberBody = new
            {
                id = Tokens.memberId,
            };
            var response = ApiMethods.PutBodyRequestApiAsync(this.endpoints.MemberIdEndpoint(MembersProperties.id), memberBody);
            var jsonResponse = JObject.Parse(response.Content);
            Assert.AreEqual(HttpStatusCode.OK, response.StatusCode);
        }

        public void GetBoardBackgroundForMember()
        {
            if (string.IsNullOrEmpty(MembersProperties.id))
            {
                throw new Exception("Member id doesn't exist");
            }

            var response = ApiMethods.GetRequestApiAsync(this.endpoints.MemberBoardBackgroundEndpoint(MembersProperties.idBackground));
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
