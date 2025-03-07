using Microsoft.VisualStudio.TestPlatform.Common.Utilities;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Globalization;
using System.Text.Json.Nodes;
using System.Text.RegularExpressions;

namespace TrelloApiTests.Boards
{
    public class BoardProperties
    {
        public string ?Name { get; set; }
        public bool DefaultLabel { get; set; }
        public bool DefaultLists { get; set; }
        public string ?Desc { get; set; }       // 0 - 16384 characters
        public string ?IdOrganization { get; set; }     //Pattern: ^[0-9a-fA-F]{24}$
        public string ?IdBoardSource { get; set; }      //Pattern: ^[0-9a-fA-F]{24}$
        public string ?KeepFromSource { get; set; }     //Default: none; Valid values: cards, none
        public string ?PowerUps { get; set; }       //Values: all, calendar, cardAging, recap, voting
    }
    public class BoardMethods
    {
        string pattern = "[A-Za-z0-9]";
        public static string CreatedIdBoard { get; set; }

        RestClient client = new RestClient();
        SettingEndpoints endpoints = new SettingEndpoints();
        Tokens tokens = new Tokens();

        public void CreateBoard()
        {
            //string nameOfBoard = "RestApiTest";
            var boardBody = new
            {
                name = "New rest api board",
                desc = "Random",
                
            };

            var request = new RestRequest($"{endpoints.mainEndpoint}{endpoints.boardsEndpoint}/?name={boardBody.name}{tokens.trelloKeyToken1}", Method.Post).AddBody(boardBody);
            var response = client.ExecuteAsync(request).Result;
            
            if (HttpStatusCode.OK == response.StatusCode)            
            {
                var jsonResponse = JObject.Parse(response.Content);
                var checkPatternIdProperty = jsonResponse["id"].ToString();
                var checkPattern = Regex.IsMatch(checkPatternIdProperty, pattern);
                CreatedIdBoard = jsonResponse["id"].ToString();
                Assert.AreEqual(HttpStatusCode.OK, response.StatusCode);
                Assert.AreEqual(boardBody.name, jsonResponse["name"]);
                Assert.AreEqual(JTokenType.String, jsonResponse["name"]?.Type);
                Assert.AreEqual(boardBody.desc, jsonResponse["desc"]);
                Assert.AreEqual(JTokenType.String, jsonResponse["desc"]?.Type);
                Assert.IsTrue(checkPattern);
            }
            else if (HttpStatusCode.OK != response.StatusCode)
            {
                throw new Exception("Status code doesn't match");
            }
        }

        public void GetBoard()
        {
            var request = new RestRequest($"{endpoints.mainEndpoint}{endpoints.boardsEndpoint}/{CreatedIdBoard}{tokens.trelloKeyToken2}", Method.Get);
            var response = client.Execute(request);

            if (HttpStatusCode.OK == response.StatusCode)
            {
                var jsonResponse = JObject.Parse(response.Content);
                Assert.AreEqual(CreatedIdBoard, jsonResponse["id"]);
            }

            else if (HttpStatusCode.OK != response.StatusCode)
            {
                throw new Exception(response.StatusCode.ToString());
            }
        }

        public void UpdateBoard()
        {
            var boardBody = new
            {
                name = "New rest api board updated",
                prefs_permissionLevel = "org"
            };
            var request = new RestRequest($"{endpoints.mainEndpoint}{endpoints.boardsEndpoint}/{CreatedIdBoard}{tokens.trelloKeyToken2}", Method.Put).AddBody(boardBody);
            var response = client.Execute(request);            
            
            if (HttpStatusCode.OK == response.StatusCode)
            {
                var jsonResponse = JObject.Parse(response.Content);
                Assert.AreEqual(HttpStatusCode.OK, response.StatusCode);
                Assert.AreEqual(boardBody.name, jsonResponse["name"]);                
            }

            else if (HttpStatusCode.OK != response.StatusCode)
            {
                throw new Exception(response.StatusCode.ToString());
            }

            
        }

        public void DeleteBoard()
        {
            if (string.IsNullOrEmpty(CreatedIdBoard))
            {
                throw new InvalidOperationException("Created board is null.");
            }

            var request = new RestRequest($"{endpoints.mainEndpoint}{endpoints.boardsEndpoint}/{CreatedIdBoard}{tokens.trelloKeyToken2}", Method.Delete);
            var response = client.Execute(request);            

            Assert.AreEqual(HttpStatusCode.OK, response.StatusCode);
            
        }
    }
}
