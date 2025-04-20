namespace TrelloApiTests.Methods
{    
    public class ApiMethods()
    {    
        static string stringPattern = "[A-Za-z0-9]";
        static string numberPattern = "[0-9]";
        static string alphabetPattern = "[A-Za-z]";

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
        public static void StringPatternCheck(RestResponse response, object property)
        {            
            var jsonResponse = JObject.Parse(response.Content);
            var checkPatternIdProperty = jsonResponse[property].ToString();
            var checkPattern = Regex.IsMatch(checkPatternIdProperty, stringPattern);            
        }
        public static void NumberPatternCheck(RestResponse response, object property)
        {
            var jsonResponse = JObject.Parse(response.Content);
            var checkPatternIdProperty = jsonResponse[property].ToString();
            var checkPattern = Regex.IsMatch(checkPatternIdProperty, numberPattern);
        }
        public static void AlphabetPatternCheck(RestResponse response, object property)
        {
            var jsonResponse = JObject.Parse(response.Content);
            var checkPatternIdProperty = jsonResponse[property].ToString();
            var checkPattern = Regex.IsMatch(checkPatternIdProperty, alphabetPattern);
        }
        public class CleanUpIds
        {
            public static void CleanAllIds()
            {
                if (ObjectProperties.BoardProperties.CreatedIdBoard != null)
                {
                    ObjectProperties.BoardProperties.CreatedIdBoard = null;
                }
                else if (ObjectProperties.BoardProperties.IdOrganization != null)
                {
                    ObjectProperties.BoardProperties.IdOrganization = null;
                }
                else if (ObjectProperties.BoardProperties.IdOrganization != null)
                {
                    ObjectProperties.BoardProperties.IdOrganization = null;
                }
            }
        }        
    }
}