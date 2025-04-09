namespace TrelloApiTests.Methods
{
    public class ApiMethods()
    {           
        public static RestResponse GetRequestApiAsync(string endpoint)
        {
            var request = new RestRequest($"{endpoint}", Method.Get);
            request.AddQueryParameter("key", Tokens.trelloApiKey);
            request.AddQueryParameter("token", Tokens.trelloApiToken);
            var response = MainRestApiUrl.Client.ExecuteAsync(request).Result;
            return response;
        }

        public static RestResponse PostRequestApiAsync(string endpoint)
        {
            var request = new RestRequest($"{endpoint}", Method.Post);
            request.AddQueryParameter("key", Tokens.trelloApiKey);
            request.AddQueryParameter("token", Tokens.trelloApiToken);
            var response = MainRestApiUrl.Client.ExecuteAsync(request).Result;
            return response;
        }

        public static RestResponse PostBodyRequestApiAsync(string endpoint, object body)
        {            
            var request = new RestRequest($"{endpoint}", Method.Post).AddBody(body);            
            request.AddQueryParameter("key", Tokens.trelloApiKey);
            request.AddQueryParameter("token", Tokens.trelloApiToken);
            var response = MainRestApiUrl.Client.ExecuteAsync(request).Result;            
            return response;
        }        

        public static RestResponse PutBodyRequestApiAsync(string endpoint, object body)
        {
            var request = new RestRequest($"{endpoint}", Method.Put).AddBody(body);
            request.AddQueryParameter("key", Tokens.trelloApiKey);
            request.AddQueryParameter("token", Tokens.trelloApiToken);
            var response = MainRestApiUrl.Client.ExecuteAsync(request).Result;
            return response;
        }
        
        public static RestResponse DeleteRequestApiAsync(string endpoint)
        {
            var request = new RestRequest($"{endpoint}", Method.Delete);
            request.AddQueryParameter("key", Tokens.trelloApiKey);
            request.AddQueryParameter("token", Tokens.trelloApiToken);
            var response = MainRestApiUrl.Client.ExecuteAsync(request).Result;
            return response;
        }        

        public static void StringPatternCheck(string response, object body, string property)
        {
            string pattern = "[A-Za-z0-9]";
            var jsonResponse = JObject.Parse(response);
            var checkPatternIdProperty = jsonResponse[$"{property}"].ToString();
            var checkPattern = Regex.IsMatch(checkPatternIdProperty, pattern);            
        }
    }
}
