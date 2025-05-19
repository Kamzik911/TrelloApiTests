namespace TrelloApiTests.Methods
{
    public class MembersMethods
    {
        SettingEndpoints endpoints = new SettingEndpoints();
        
        public void GetMemberId()
        {
            var response = ApiMethods.GetRequestApiAsync(endpoints.memberIdEndpoint(Tokens.memberId));
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
                id = Tokens.memberId
            };
            var response = ApiMethods.PutBodyRequestApiAsync(endpoints.memberIdEndpoint(MembersProperties.id), memberBody);
            var jsonResponse = JObject.Parse(response.Content);
            Assert.AreEqual(HttpStatusCode.OK, response.StatusCode);
            Console.WriteLine(jsonResponse.ToString());
        }
    }
}
