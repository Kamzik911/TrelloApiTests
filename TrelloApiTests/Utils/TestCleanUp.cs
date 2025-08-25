namespace TrelloApiTests.Utils
{
    public class TestCleanUp
    {
        public class CleanupIds
        {                        
            public void CleanIds()
            {
                if (BoardProperties.Id != null)
                {
                    BoardProperties.Id = null;
                }
                if (BoardProperties.IdOrganization != null)
                {
                    BoardProperties.IdOrganization = null;
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
}
