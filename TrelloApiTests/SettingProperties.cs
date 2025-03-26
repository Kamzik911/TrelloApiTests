namespace TrelloApiTests
{
    class SettingProperties
    {
        public static string? CreatedIdBoard { get; set; }
    }

    class LabelProperties
    {
        public static string? CreatedLabelId { get; set; }
    }

    class ListProperties
    {
        public static string? ListId { get; set; }
    }

    class BoardProperties
    {
        public string? Name { get; set; }
        public bool DefaultLabel { get; set; }
        public bool DefaultLists { get; set; }
        public string? Desc { get; set; }       // 0 - 16384 characters
        public string? IdOrganization { get; set; }     //Pattern: ^[0-9a-fA-F]{24}$
        public string? IdBoardSource { get; set; }      //Pattern: ^[0-9a-fA-F]{24}$
        public string? KeepFromSource { get; set; }     //Default: none; Valid values: cards, none
        public string? PowerUps { get; set; }       //Values: all, calendar, cardAging, recap, voting
    }
}
