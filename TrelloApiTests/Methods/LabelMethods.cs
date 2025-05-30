﻿namespace TrelloApiTests.Methods
{
    public class LabelMethods : LabelProperties
    {        
        SettingEndpoints endpoints = new SettingEndpoints();
        
        public void CreateLabelOnBoard(string color)
        {
            if (string.IsNullOrEmpty(BoardProperties.id))
            {
                throw new Exception("Board ID doens't exist.");
            }
            else
            {
                var labelBody = new
                {
                    name = "New rest api label",
                    color = color,
                    idBoard = BoardProperties.id,                    
                };

                var response = ApiMethods.PostBodyRequestApiAsync(endpoints.labelsEndpoint, labelBody); ;
                Assert.AreEqual(HttpStatusCode.OK, response.StatusCode);
                var jsonResponse = JObject.Parse(response.Content);
                id = jsonResponse["id"].ToString();                
                Assert.AreEqual(labelBody.name, jsonResponse["name"]);
                Assert.AreEqual(labelBody.color, jsonResponse["color"]);  
                Console.WriteLine(jsonResponse.ToString());
            }
        }

        public void GetCreatedLabel()
        {
            if (string.IsNullOrEmpty(BoardProperties.id))
            {
                throw new Exception("Created board ID is null or empty");
            }

            var response = ApiMethods.GetRequestApiAsync(endpoints.LabelIdEndpoint(id));            
            Assert.AreEqual(HttpStatusCode.OK, response.StatusCode);            
        }

        public void UpdateCreatedLabel(string color)
        {
            if (string.IsNullOrEmpty(id))
            {
                throw new Exception("Created board ID is null or empty");
            }
            else if(string.IsNullOrEmpty(id))
            {
                throw new Exception("Created label ID is null or empty");
            }
            else
            {
                var labelBody = new
                {
                    name = "Label updated",
                    color = $"{color}"
                };

                var request = new RestRequest($"{endpoints.LabelIdEndpoint(id)}", Method.Put).AddBody(labelBody);
                request.AddQueryParameter("key", Tokens.trelloApiKey);
                request.AddQueryParameter("token", Tokens.trelloApiToken);
                var response = MainRestApiUrl.Client.ExecuteAsync(request).Result;
                var jsonResponse = JObject.Parse(response.Content);
                Assert.AreEqual(HttpStatusCode.OK, response.StatusCode);
                Assert.AreEqual(labelBody.color, jsonResponse["color"]);
            }               
        }        

        public void DeleteLabel()
        {
            if (string.IsNullOrEmpty(id))
            {
                throw new Exception("Created board ID is null or empty");
            }
            else if (string.IsNullOrEmpty(id))
            {
                throw new Exception("Created label ID is null or empty");
            }
            else
            {                
                var response = ApiMethods.DeleteRequestApiAsync(endpoints.LabelIdEndpoint(id));
                Assert.AreEqual(HttpStatusCode.OK, response.StatusCode);
            }

                
        }
    }
}
