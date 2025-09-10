namespace TrelloApiTests.Utils
{
    public class TestCleanUp
    {
        public class CleanupIds
        {       
            public readonly BoardProperties boardProperties;
            public readonly CardProperties cardProperties;
            public readonly LabelProperties labelProperties;
            public readonly ListProperties listProperties;

            public void CleanIds()
            {
                if (boardProperties.Id != null)
                {
                    boardProperties.Id = null;
                }
                if (boardProperties.IdOrganization != null)
                {
                    boardProperties.IdOrganization = null;
                }
                if (cardProperties.id != null)
                {
                    cardProperties.id = null;
                }
                if (labelProperties.id != null)
                {
                    labelProperties.id = null;
                }
                if (listProperties.id != null)
                {
                    listProperties.id = null;
                }
            }
        }
    }
}
