namespace TrelloApiTests.Methods
{
    internal class ListMethods
    {
        SettingEndpoints endpoints = new SettingEndpoints();
        Tokens tokens = new Tokens();
        BoardMethods boardMethods = new BoardMethods();
        RestClient client = new RestClient();

        public void ACreateBoard()
        {
            boardMethods.CreateBoard();
        }

        public void BCreateList()
        {
            var listBody = new
            {
                name = "",
                idBoard = "",
            };
            var request = new RestRequest($"{endpoints.listsEndpoint}?name={listBody.name}&idboard=5abbe4b7ddc1b351ef961414");
            var response = client.ExecuteAsync(request).Result;

            Assert.AreEqual(HttpStatusCode.OK, response.StatusCode);
        }

        public void ZDeleteBoard()
        {
            boardMethods.DeleteBoard();
        }
    }
}
