namespace TrelloApiTests.Members
{
    class MembersMethods
    {
        SettingEndpoints endpoints = new SettingEndpoints();
        RestClient client = new RestClient();
        Tokens tokens = new Tokens();        

        public void GetMemberId()
        {
            var request = new RestRequest($"{endpoints.trelloEndpoint}{endpoints.memeberEndpoint}/{tokens.memberId}{tokens.trelloKeyToken2}", Method.Get);
            var response = client.Execute(request);

            if (HttpStatusCode.OK == response.StatusCode)
            {
                Console.WriteLine(response.Content);
            }

            else if (HttpStatusCode.OK != response.StatusCode)
            {
                throw new Exception(response.StatusCode.ToString());
            }
        }
    }
}
