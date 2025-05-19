using Microsoft.AspNetCore.OData;

namespace TrelloApiTests.Methods
{    
    public class ApiMethods : Tokens
    {    
        static string stringPattern = "[A-Za-z0-9]";
        static string numberPattern = "[0-9]";
        static string alphabetPattern = "[A-Za-z]";

        public static RestResponse GetRequestApiAsync(string endpoint)
        {
            var request = new RestRequest($"{endpoint}", Method.Get);
            request.AddQueryParameter("key", trelloApiKey);
            request.AddQueryParameter("token", trelloApiToken);
            var response = MainRestApiUrl.Client.ExecuteAsync(request).Result;
            return response;
        }

        public static RestResponse GetOdataRequestApiAsync(string endpoint)
        {
            var request = new RestRequest($"{endpoint}", Method.Get);
            request.AddQueryParameter("key", trelloApiKey);
            request.AddQueryParameter("token", trelloApiToken);
            var response = MainRestApiUrl.Client.ExecuteAsync<ODataOptions>(request).Result;
            return response;
        }

        public static RestResponse PostRequestApiAsync(string endpoint)
        {
            var request = new RestRequest($"{endpoint}", Method.Post);
            request.AddQueryParameter("key", trelloApiKey);
            request.AddQueryParameter("token", trelloApiToken);
            var response = MainRestApiUrl.Client.ExecuteAsync(request).Result;
            return response;
        }
        
        public static RestResponse PostBodyRequestApiAsync(string endpoint, object body)
        {            
            var request = new RestRequest($"{endpoint}", Method.Post).AddBody(body);
            request.AddQueryParameter("key", trelloApiKey);
            request.AddQueryParameter("token", trelloApiToken);
            var response = MainRestApiUrl.Client.ExecuteAsync(request).Result;            
            return response;
        }

        public static RestResponse PutBodyRequestApiAsync(string endpoint, object body)
        {
            var request = new RestRequest($"{endpoint}", Method.Put).AddBody(body);
            request.AddQueryParameter("key", trelloApiKey);
            request.AddQueryParameter("token", trelloApiToken);
            var response = MainRestApiUrl.Client.ExecuteAsync(request).Result;
            return response;
        }

        public static RestResponse PutODataRequestApiAsync(string endpoint, object body)
        {
            var request = new RestRequest($"{endpoint}", Method.Put).AddBody(body);
            request.AddQueryParameter("key", trelloApiKey);
            request.AddQueryParameter("token", trelloApiToken);
            var response = MainRestApiUrl.Client.ExecuteAsync<ODataOptions>(request).Result;
            return response;
        }

        public static RestResponse DeleteRequestApiAsync(string endpoint)
        {
            var request = new RestRequest($"{endpoint}", Method.Delete);
            request.AddQueryParameter("key", trelloApiKey);
            request.AddQueryParameter("token", trelloApiToken);
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
        
        public class CleanupIds        
        {
            public static void CleanIds()
            {
                if (BoardProperties.id != null)
                {
                    BoardProperties.id = null;
                }
                else if (BoardProperties.idOrganization != null)
                {
                    BoardProperties.idOrganization = null;
                }
                else if (CardProperties.id != null)
                {
                    CardProperties.id = null;
                }
                else if (LabelProperties.id != null)
                {
                    LabelProperties.id = null;
                }
                else if (ListProperties.id != null)
                {
                    ListProperties.id = null;
                }
            }
        }        
    }
}