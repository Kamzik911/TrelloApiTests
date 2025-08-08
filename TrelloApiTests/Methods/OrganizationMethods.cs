namespace TrelloApiTests.Methods
{
    public class OrganizationMethods : OrganizationProperties
    {
        private SettingEndpoints endpoints = new SettingEndpoints();
        private BoardMethods boardMethods = new BoardMethods();

        public void CreateOrganization()
        {
            var orgBody = new
            {
                name = StringGenerator.GenerateString(10),
                displayName = StringGenerator.GenerateString(15),
                desc = StringGenerator.GenerateString(150),
                website = UrlGenerator.GenerateRandomUrl(),
            };
            var response = ApiMethods.PostBodyRequestApiAsync(this.endpoints.organizationEndpoint, orgBody);
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
            Console.WriteLine(jsonResponse.ToString());
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
                    website = UrlGenerator.GenerateRandomUrl(),
                };

                var response = ApiMethods.PutBodyRequestApiAsync(this.endpoints.OrganizationId(id), orgBody);
                var jsonResponse = JObject.Parse(response.Content);
                Assert.AreEqual(HttpStatusCode.OK, response.StatusCode);
                Assert.AreEqual(orgBody.displayName, jsonResponse["displayName"]);
                Assert.AreEqual(orgBody.desc, jsonResponse["desc"]);
                Assert.AreEqual(orgBody.website, jsonResponse["website"]);
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
                var response = ApiMethods.GetRequestApiAsync(this.endpoints.OrganizationId(id));
                var jsonResponse = JObject.Parse(response.Content);
                Assert.AreEqual(HttpStatusCode.OK, response.StatusCode);
            }
        }

        public void GetFieldOnOrganization()
        {
            if (string.IsNullOrEmpty(id))
            {
                throw new Exception("Org id doesn't exist");
            }
            else
            {
                var response = ApiMethods.GetRequestApiAsync(this.endpoints.CustomFieldIdEndpoint(id));
                var jsonResponse = JObject.Parse(response.Content);
                Assert.AreEqual(HttpStatusCode.OK, response.StatusCode);
            }
        }

        public void CreateBoard()
        {
            this.boardMethods.CreateBoard();
        }

        public void GetBoardInOrganization()
        {
            if (string.IsNullOrEmpty(id))
            {
                throw new Exception("Org id doesn't exist");
            }
            else
            {
                var response = ApiMethods.GetRequestApiAsync(this.endpoints.OrganizationBoardId(id));
                var jsonResponse = JArray.Parse(response.Content).First;
                Assert.AreEqual(HttpStatusCode.OK, response.StatusCode);
                Assert.IsNotNull(jsonResponse["id"]);
            }
        }

        public void DeleteOrganization()
        {
            if (string.IsNullOrEmpty(id))
            {
                throw new Exception("Org id doesn't exist");
            }
            else
            {
                var response = ApiMethods.DeleteRequestApiAsync(this.endpoints.OrganizationId(id));
                Assert.AreEqual(HttpStatusCode.OK, response.StatusCode);
            }
        }

        public void DeleteBoard()
        {
            this.boardMethods.DeleteBoard();
        }
    }
}
