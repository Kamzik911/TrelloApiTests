using Newtonsoft.Json.Linq;

namespace TrelloApiTests.Methods
{
    public class ObjectCardProperties
    {
        public string ?Name { get; set; }
        public string ?Desc { get; set; }        
    }

    public class CardMethods
    {
        public static int idList { get; set; }
        public static int idBoardValue { get; set; }

        RestClient client = new RestClient();
        SettingEndpoints endpoints = new SettingEndpoints();
        Tokens tokens = new Tokens();

        public void CreateNewList()
        {
            var cardBody = new
            {
                name = "RestApi test list",
                idBoard = idBoardValue
            };
            var request = new RestRequest($"{endpoints.cardsEndpoint}", Method.Post).AddBody(cardBody);
            var response = client.ExecuteAsync(request).Result;

            if (HttpStatusCode.OK != response.StatusCode)
            {
                throw new Exception(response.StatusCode.ToString());
            }
        }

        public void CreateNewCard()
        {
            var cardBody = new
            {
                name = "RestApi tests",
                desc = "RestApi tests description",
                start = DateTime.Now,
                idlist = 15
            };
            var request = new RestRequest($"{endpoints.cardsEndpoint}", Method.Post).AddBody(cardBody);
            var response = client.ExecuteAsync(request).Result;

            if (HttpStatusCode.OK != response.StatusCode)
            {
                throw new Exception(response.StatusCode.ToString());
            }            
        }

        public void GetCardId()
        {
            var request = new RestRequest($"{endpoints.boardsEndpoint}{endpoints.cardsEndpoint}", Method.Get);
            var response = client.ExecuteAsync(request).Result;

            Assert.AreEqual(HttpStatusCode.OK, response.StatusCode);
        }
    }
}
