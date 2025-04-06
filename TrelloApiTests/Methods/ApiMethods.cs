namespace TrelloApiTests.Methods
{
    public class ApiMethods()
    {        
        public static RestResponse GetRequestApiAsync(string endpoint)
        {
            if (string.IsNullOrEmpty(ObjectProperties.BoardProperties.CreatedIdBoard))
            {
                throw new Exception("Board id is empty");
            }

            var request = new RestRequest($"{endpoint}", Method.Get);
            request.AddQueryParameter("key", Tokens.trelloApiKey);
            request.AddQueryParameter("token", Tokens.trelloApiToken);
            var response = MainRestApiUrl.Client.ExecuteAsync(request).Result;
            return response;
        }

        public static RestResponse PostRequestApiAsync(string endpoint, object body)
        {            
            var request = new RestRequest($"{endpoint}", Method.Post).AddBody(body);            
            request.AddQueryParameter("key", Tokens.trelloApiKey);
            request.AddQueryParameter("token", Tokens.trelloApiToken);
            var response = MainRestApiUrl.Client.ExecuteAsync(request).Result;            
            return response;
        }
    }
}
