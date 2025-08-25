using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrelloApiTests.Utils
{
    public class UrlGenerator : StringGenerator
    {
        public static string GenerateRandomUrl()
        {
            string protocol = "https://";
            string domainName = GenerateString(8).ToLower();
            string[] domains = { "com", "net", "org", "dev" };
            string tld = domains[new Random().Next(domains.Length)];
            string path = "/" + GenerateString(6).ToLower();
            return $"{protocol}{domainName}.{tld}{path}";
        }
    }
}
