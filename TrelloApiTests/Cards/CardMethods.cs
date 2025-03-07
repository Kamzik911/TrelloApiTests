using Newtonsoft.Json.Linq;

namespace TrelloApiTests.Cards
{
    public class ObjectCardProperties
    {
        public string ?Name { get; set; }
        public string ?Desc { get; set; }
        public int idList { get; set; }
    }

    public class CardMethods
    {
        RestClient client = new RestClient();
        SettingEndpoints endpoints = new SettingEndpoints();
        Tokens tokens = new Tokens();

        public void CreateNewCard()
        {
            var cardBody = new
            {
                name = "RestApi tests",
                desc = "RestApi tests",
                start = DateTime.Now,
                idlist = 15
            };
            var request = new RestRequest($"{endpoints.mainEndpoint}{endpoints.cardsEndpoint}{tokens.trelloKeyToken1}", Method.Post).AddBody(cardBody);
            var response = client.ExecuteAsync(request).Result;

            if (HttpStatusCode.OK != response.StatusCode)
            {
                throw new Exception(response.StatusCode.ToString());
            }            
        }

        public void GetCardId()
        {
            var request = new RestRequest($"{endpoints.mainEndpoint}{tokens.trelloKeyToken1}", Method.Get);
            var response = client.ExecuteAsync(request).Result;

            Assert.AreEqual(HttpStatusCode.OK, response.StatusCode);
        }
    }
}
