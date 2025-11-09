using System;

namespace TrelloApiTests.Utils
{
    public class Tokens
    {
        private static string GetCredentials(int fileIndex)
        {
            const string fileName = "Credentials.txt";

            if (!File.Exists(fileName))
            {
                throw new FileNotFoundException($"Missing credentials file: {fileName}");
            }
            
            if (fileIndex < 0)            
            {
                throw new ArgumentOutOfRangeException(nameof(fileIndex), "Index cannot be negative ");
            }
            
            var line = File.ReadLines(fileName).Skip(fileIndex).FirstOrDefault();
            
            if (line == null) 
            {
                throw new IndexOutOfRangeException($"Credentials file '{fileName}' does not contain a line at index {fileIndex}.");
            }

            return line;
        }

        public static string trelloApiKey = GetCredentials(0);
        public static string trelloApiToken = GetCredentials(1);
        public static string memberId = GetCredentials(2);
        public static string calendarKey = GetCredentials(3);
    }
}     

