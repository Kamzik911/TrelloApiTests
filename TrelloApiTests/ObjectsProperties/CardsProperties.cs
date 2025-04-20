using Microsoft.VisualStudio.TestPlatform.Utilities;

namespace TrelloApiTests.ObjectsProperties
{
    public class CardMainProperties
    {
        public static string id { get; set; }
        public string address { get; set; }
        public Badges badges { get; set; }             
        public bool closed { get; set; }
        public string dateLastActivity { get; set; }
        public string desc { get; set; }
        public string idBoard { get; set; }
        public List<IdLabels> idLabels { get; set; }
        public string idList { get; set; }
        public int idShort { get; set; }
        public bool manualCoverAttachment { get; set; }
        public string name { get; set; }
        public int pos { get; set; }
        public string shortLink { get; set; }
        public string shortUrl { get; set; }
        public bool subscribed { get; set; }
        public string url { get; set; }
        public Cover cover { get; set; }
    }
    public class Badges
    {
        public AttachmentsByType attachmentsByType { get; set; }
        public bool location { get; set; }
        public int votes { get; set; }
        public bool viewingMemberVoted { get; set; }
        public bool subscribed { get; set; }        
        public int checkItems { get; set; }
        public int checkItemsChecked { get; set; }
        public int comments { get; set; }
        public int attachments { get; set; }
        public bool description { get; set; }
        public bool dueComplete { get; set; }
    }
    public class AttachmentsByType
    {
        public TrelloType trello { get; set; }
    }
    public class TrelloType
    {
        public int board { get; set; }
        public int card { get; set; }
    }
    public class IdLabels
    {
        public string id { get; set; }
        public string idBoard { get; set; }
        public string name { get; set; }
        public string color { get; set; }
    }      
    public class Cover
    {
        public string color { get; set; }
        public bool? idUploadedBackground { get; set; }
        public string size { get; set; }
        public string brightness { get; set; }
        public bool isTemplate { get; set; }
    }
}
