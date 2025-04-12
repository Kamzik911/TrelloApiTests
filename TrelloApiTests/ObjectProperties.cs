namespace TrelloApiTests
{   
    public class ObjectProperties
    {
        public class BoardProperties
        {
            public static string? CreatedIdBoard { get; set; }
            public static string? IdOrganization { get; set; }
            public string? name { get; set; }
            public string? desc { get; set; }
        }
        public class LabelProperties
        {
            public static string? CreatedLabelId { get; set; }
        }
        public class ListProperties
        {
            public static string? ListId { get; set; }
        }
        public class CardProperties
        {
            public static string? CreatedCardId { get; set; }
        }
        public class CustomFieldProperties
        {
            public static string? CustomFieldId { get; set; }
        }
        public class ChecklistProperties
        {
            public static string? ChecklistId { get; set; }
        }
    }        
}
