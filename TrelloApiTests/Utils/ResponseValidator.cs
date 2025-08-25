namespace TrelloApiTests.Utils
{
    public class ResponseValidator
    {
        private static string stringPattern = "[A-Za-z0-9]";
        private static string numberPattern = "[0-9]";
        private static string alphabetPattern = "[A-Za-z]";
        
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
}
