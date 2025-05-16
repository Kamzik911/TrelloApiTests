namespace TrelloApiTests.Methods
{
    public class OrganizationMethods : OrganizationProperties
    {
        SettingEndpoints endpoints = new SettingEndpoints();        

        public void CreateOrganization()
        {
            var orgBody = new
            {
                name = StringGenerator.GenerateString(10),
                displayName = StringGenerator.GenerateString(15),
                desc = StringGenerator.GenerateString(150),
                website = UrlGenerator.GenerateRandomUrl()
            };
            var response = ApiMethods.PostBodyRequestApiAsync(SettingEndpoints.organizationEndpoint, orgBody);
            var jsonResponse = JObject.Parse(response.Content);            
            id = jsonResponse["id"].ToString();
            Assert.IsNotNull(id);
            Assert.AreEqual(id, jsonResponse["id"]);
            Assert.IsNotNull(jsonResponse["name"]);
            ApiMethods.StringPatternCheck(response, "displayName");
            Assert.AreEqual(orgBody.displayName, jsonResponse["displayName"]);
            Assert.AreEqual(orgBody.desc, jsonResponse["desc"]);
            Assert.AreEqual(orgBody.website, jsonResponse["website"]);
            Assert.AreEqual(HttpStatusCode.OK, response.StatusCode);
        }

        public void UpdateOrganization()
        {
            if (string.IsNullOrEmpty(id))
            {
                throw new Exception("Organization id doesn't exist");
            }
            else
            {
                var orgBody = new
                {                    
                    displayName = StringGenerator.GenerateString(35),
                    desc = StringGenerator.GenerateString(150),
                    website = UrlGenerator.GenerateRandomUrl()
                };

                var response = ApiMethods.PutBodyRequestApiAsync(endpoints.organizationId(id), orgBody);
                var jsonResponse = JObject.Parse(response.Content);
                Assert.AreEqual(HttpStatusCode.OK, response.StatusCode);                
                Assert.AreEqual(orgBody.displayName, jsonResponse["displayName"].ToString());
                Assert.AreEqual(orgBody.desc, jsonResponse["desc"].ToString());
                Assert.AreEqual(orgBody.website, jsonResponse["website"].ToString());
            }                
        }

        public void GetOrganization()
        {
            if (string.IsNullOrEmpty(id))
            {
                throw new Exception("Org id doesn't exist");
            }
            else
            {
                var response = ApiMethods.GetRequestApiAsync(endpoints.organizationId(id));
                var jsonResponse = JObject.Parse(response.Content);
                Assert.AreEqual(HttpStatusCode.OK, response.StatusCode);
                Console.WriteLine(jsonResponse.ToString());
            }                
        }

        public void DeleteOrganization()
        {
            
            var response = ApiMethods.DeleteRequestApiAsync(endpoints.organizationId(id));
            Assert.AreEqual(HttpStatusCode.OK, response.StatusCode);
                            
        }
    }
}
