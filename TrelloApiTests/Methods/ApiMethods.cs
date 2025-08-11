using RestSharp;
using System.Threading.Tasks;

namespace TrelloApiTests.Methods
{
    public class ApiMethods : Tokens
    {
        private static string stringPattern = "[A-Za-z0-9]";
        private static string numberPattern = "[0-9]";
        private static string alphabetPattern = "[A-Za-z]";
                
        public static async Task<RestResponse> GetRequestApiAsync(string endpoint)
        {
            var request = new RestRequest($"{endpoint}", Method.Get);
            request.AddQueryParameter("key", trelloApiKey);
            request.AddQueryParameter("token", trelloApiToken);
            var response = await MainRestApiUrl.Client.ExecuteAsync(request).ConfigureAwait(false);            
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

        public static async Task<RestResponse> PostRequestApiAsync(string endpoint)
        {
            var request = new RestRequest($"{endpoint}", Method.Post);
            request.AddQueryParameter("key", trelloApiKey);
            request.AddQueryParameter("token", trelloApiToken);
            var response = await MainRestApiUrl.Client.ExecuteAsync(request).ConfigureAwait(false);
            return response;
        }

        public static async Task<RestResponse> PostBodyRequestApiAsync(string endpoint, object body)
        {
            var request = new RestRequest($"{endpoint}", Method.Post).AddBody(body);
            request.AddQueryParameter("key", trelloApiKey);
            request.AddQueryParameter("token", trelloApiToken);
            return await MainRestApiUrl.Client.ExecuteAsync(request).ConfigureAwait(false);            
        }

        public static async Task<RestResponse> PutBodyRequestApiAsync(string endpoint, object body)
        {
            var request = new RestRequest($"{endpoint}", Method.Put).AddBody(body);
            request.AddQueryParameter("key", trelloApiKey);
            request.AddQueryParameter("token", trelloApiToken);
            var response = await MainRestApiUrl.Client.ExecuteAsync(request).ConfigureAwait(false);
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

        public static async Task<RestResponse> DeleteRequestApiAsync(string endpoint)
        {
            var request = new RestRequest($"{endpoint}", Method.Delete);
            request.AddQueryParameter("key", trelloApiKey);
            request.AddQueryParameter("token", trelloApiToken);
            var response = await MainRestApiUrl.Client.ExecuteAsync(request).ConfigureAwait(false);
            return response;
        }

        public static bool StringPatternCheck(RestResponse response, object property)
        {
            var jsonResponse = JObject.Parse(response.Content);
            var checkPatternIdProperty = jsonResponse[property].ToString();
            //var checkPattern = Regex.IsMatch(checkPatternIdProperty, stringPattern);
            return Regex.IsMatch(checkPatternIdProperty, stringPattern);
        }

        public static bool StringArrayPatternCheck(RestResponse response, object property)
        {
            var jsonResponse = JArray.Parse(response.Content).First;
            var checkPatternIdProperty = jsonResponse[property].ToString();
            return Regex.IsMatch(checkPatternIdProperty, stringPattern);
            
        }

        public static bool NumberPatternCheck(RestResponse response, object property)
        {
            var jsonResponse = JObject.Parse(response.Content);
            var checkPatternIdProperty = jsonResponse[property].ToString();
            return Regex.IsMatch(checkPatternIdProperty, numberPattern);            
        }
        
        public static bool AlphabetPatternCheck(RestResponse response, object property)
        {
            var jsonResponse = JObject.Parse(response.Content);
            var checkPatternIdProperty = jsonResponse[property].ToString();
            return Regex.IsMatch(checkPatternIdProperty, alphabetPattern);            
        }

        public static bool AlphabetArrayPatternCheck(RestResponse response, object property)
        {
            var jsonResponse = JArray.Parse(response.Content).First;
            var checkPatternIdProperty = jsonResponse[property].ToString();
            return Regex.IsMatch(checkPatternIdProperty, alphabetPattern);            
        }        
    }
    public class CleanupIds
    {
        public void CleanIds()
        {
            if (BoardProperties.Id != null)
            {
                BoardProperties.Id = null;
            }
            if (BoardProperties.idOrganization != null)
            {
                BoardProperties.idOrganization = null;
            }
            if (CardProperties.id != null)
            {
                CardProperties.id = null;
            }
            if (LabelProperties.id != null)
            {
                LabelProperties.id = null;
            }
            if (ListProperties.id != null)
            {
                ListProperties.id = null;
            }
        }
    }
}