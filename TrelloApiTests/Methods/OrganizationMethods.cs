using TrelloApiTests.ObjectsProperties;
using TrelloApiTests.Utils;

namespace TrelloApiTests.Methods
{
    public class OrganizationMethods
    {
        private EndpointsSetup endpoints = new EndpointsSetup();        
        private readonly ApiMethods apiClient;
        private readonly OrganizationProperties organizationProperties;

        public OrganizationMethods(OrganizationProperties organizationProperties)
        {
            this.apiClient = new ApiMethods();
            this.organizationProperties = organizationProperties;
        }

        public async Task CreateOrganization()
        {
            var orgBody = new
            {
                name = StringGenerator.GenerateString(10),
                displayName = StringGenerator.GenerateString(15),
                desc = StringGenerator.GenerateString(150),
                website = UrlGenerator.GenerateRandomUrl(),
            };
            var response = await apiClient.PostBodyRequestApiAsync(this.endpoints.organizationEndpoint, orgBody).ConfigureAwait(false);
            var jsonResponse = JObject.Parse(response.Content);
            organizationProperties.id = jsonResponse["id"].ToString();
            Assert.IsNotNull(organizationProperties.id);
            Assert.AreEqual(organizationProperties.id, jsonResponse["id"]);
            Assert.IsNotNull(jsonResponse["name"]);
            Assert.IsTrue(ResponseValidator.StringPatternCheck(response, "displayName"));
            Assert.AreEqual(orgBody.displayName, jsonResponse["displayName"]);
            Assert.AreEqual(orgBody.desc, jsonResponse["desc"]);
            Assert.AreEqual(orgBody.website, jsonResponse["website"]);
            Assert.AreEqual(HttpStatusCode.OK, response.StatusCode);
            Console.WriteLine(jsonResponse.ToString());
        }

        public async Task UpdateOrganization()
        {
            if (string.IsNullOrEmpty(organizationProperties.id))
            {
                throw new Exception("Organization id doesn't exist");
            }
            else
            {
                var orgBody = new
                {
                    displayName = StringGenerator.GenerateString(35),
                    desc = StringGenerator.GenerateString(150),
                    website = UrlGenerator.GenerateRandomUrl(),
                };

                var response = await apiClient.PutBodyRequestApiAsync(this.endpoints.OrganizationId(organizationProperties.id), orgBody).ConfigureAwait(false);
                var jsonResponse = JObject.Parse(response.Content);
                Assert.AreEqual(HttpStatusCode.OK, response.StatusCode);
                Assert.AreEqual(orgBody.displayName, jsonResponse["displayName"]);
                Assert.AreEqual(orgBody.desc, jsonResponse["desc"]);
                Assert.AreEqual(orgBody.website, jsonResponse["website"]);
            }
        }

        public async Task GetOrganization()
        {
            if (string.IsNullOrEmpty(organizationProperties.id))
            {
                throw new Exception("Org id doesn't exist");
            }
            else
            {
                var response = await apiClient.GetRequestApiAsync(this.endpoints.OrganizationId(organizationProperties.id)).ConfigureAwait(false);
                var jsonResponse = JObject.Parse(response.Content);
                Assert.AreEqual(HttpStatusCode.OK, response.StatusCode);
            }
        }

        public async Task GetFieldOnOrganization()
        {
            if (string.IsNullOrEmpty(organizationProperties.id))
            {
                throw new Exception("Org id doesn't exist");
            }
            else
            {
                var response = await apiClient.GetRequestApiAsync(this.endpoints.CustomFieldIdEndpoint(organizationProperties.id)).ConfigureAwait(false);
                var jsonResponse = JObject.Parse(response.Content);
                Assert.AreEqual(HttpStatusCode.OK, response.StatusCode);
            }
        }
        
        public async Task GetBoardInOrganization()
        {
            if (string.IsNullOrEmpty(organizationProperties.id))
            {
                throw new Exception("Org id doesn't exist");
            }
            else
            {
                var response = await apiClient.GetRequestApiAsync(this.endpoints.OrganizationBoardId(organizationProperties.id)).ConfigureAwait(false);
                var jsonResponse = JArray.Parse(response.Content).First;
                Assert.AreEqual(HttpStatusCode.OK, response.StatusCode);
                Assert.IsNotNull(jsonResponse["id"]);
            }
        }

        public async Task DeleteOrganization()
        {
            if (string.IsNullOrEmpty(organizationProperties.id))
            {
                throw new Exception("Org id doesn't exist");
            }
            else
            {
                var response = await apiClient.DeleteRequestApiAsync(this.endpoints.OrganizationId(organizationProperties.id)).ConfigureAwait(false);
                Assert.AreEqual(HttpStatusCode.OK, response.StatusCode);
            }
        }
    }
}
