using TrelloApiTests.Utils;

namespace TrelloApiTests.Methods
{
    public interface IApiClient
    {
        Task<RestResponse> GetRequestApiAsync(string endpoint);
        Task<RestResponse> GetOdataRequestApiAsync(string endpoint);
        Task<RestResponse> PostRequestApiAsync(string endpoint);
        Task<RestResponse> PostBodyRequestApiAsync(string endpoint, object body);
        Task<RestResponse> PutBodyRequestApiAsync(string endpoint, object body);
        Task<RestResponse> PutODataRequestApiAsync(string endpoint, object body);
        Task<RestResponse> DeleteRequestApiAsync(string endpoint);
    }

    public class ApiMethods : Tokens, IApiClient
    {
        private readonly RestClient restClient;

        public ApiMethods()
            : this(MainRestApiUrl.Client) 
        {        
        }
        
        public ApiMethods(RestClient restClient)
        {
            this.restClient = restClient ?? throw new ArgumentNullException (nameof(restClient));
        }

        public async Task<RestResponse> GetRequestApiAsync(string endpoint)
        {
            var request = new RestRequest($"{endpoint}", Method.Get);
            request.AddQueryParameter("key", trelloApiKey);
            request.AddQueryParameter("token", trelloApiToken);            
            var response = await this.restClient.ExecuteAsync(request).ConfigureAwait(false);
            return response;
        }

        public async Task<RestResponse> GetOdataRequestApiAsync(string endpoint)
        {
            var request = new RestRequest($"{endpoint}", Method.Get);
            request.AddQueryParameter("key", trelloApiKey);
            request.AddQueryParameter("token", trelloApiToken);            
            var response = await this.restClient.ExecuteAsync<ODataOptions>(request).ConfigureAwait(false);
            return response;
        }

        public async Task<RestResponse> PostRequestApiAsync(string endpoint)
        {
            var request = new RestRequest($"{endpoint}", Method.Post);
            request.AddQueryParameter("key", trelloApiKey);
            request.AddQueryParameter("token", trelloApiToken);
            var response = await this.restClient.ExecuteAsync(request).ConfigureAwait(false);
            return response;
        }

        public async Task<RestResponse> PostBodyRequestApiAsync(string endpoint, object body)
        {
            var request = new RestRequest($"{endpoint}", Method.Post).AddBody(body);
            request.AddQueryParameter("key", trelloApiKey);
            request.AddQueryParameter("token", trelloApiToken);
            return await this.restClient.ExecuteAsync(request).ConfigureAwait(false);
        }

        public async Task<RestResponse> PutBodyRequestApiAsync(string endpoint, object body)
        {
            var request = new RestRequest($"{endpoint}", Method.Put).AddBody(body);
            request.AddQueryParameter("key", trelloApiKey);
            request.AddQueryParameter("token", trelloApiToken);
            var response = await this.restClient.ExecuteAsync(request).ConfigureAwait(false);
            return response;
        }

        public async Task<RestResponse> PutODataRequestApiAsync(string endpoint, object body)
        {
            var request = new RestRequest($"{endpoint}", Method.Put).AddBody(body);
            request.AddQueryParameter("key", trelloApiKey);
            request.AddQueryParameter("token", trelloApiToken);
            var response = await this.restClient.ExecuteAsync<ODataOptions>(request).ConfigureAwait(false);
            return response;
        }

        public async Task<RestResponse> DeleteRequestApiAsync(string endpoint)
        {
            var request = new RestRequest($"{endpoint}", Method.Delete);
            request.AddQueryParameter("key", trelloApiKey);
            request.AddQueryParameter("token", trelloApiToken);
            var response = await this.restClient.ExecuteAsync(request).ConfigureAwait(false);
            return response;
        }
    }
}
