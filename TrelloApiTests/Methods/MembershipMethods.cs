namespace TrelloApiTests.Methods
{
    public class MembershipMethods
    {
        SettingEndpoints endpoints = new SettingEndpoints();        

        public async Task GetMembershipOfBoard()
        {
            var response = await ApiMethods.GetRequestApiAsync(endpoints.MembershipEndpoint(BoardProperties.Id)).ConfigureAwait(false);            
            var jsonResponse = JArray.Parse(response.Content).First;
            Assert.AreEqual(HttpStatusCode.OK, response.StatusCode);
            var memberIdNotNull = jsonResponse["id"].ToString();            
            Assert.IsNotNull(memberIdNotNull);
        }
    }
}
