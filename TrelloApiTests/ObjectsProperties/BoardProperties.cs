namespace TrelloApiTests.ObjectsProperties
{
    public class BoardProperties
    {
        public static string id { get; set; }
        public string name { get; set; }
        public string desc { get; set; }
        public bool? closed { get; set; }
        public string idMemberCreator { get; set; }
        public static string idOrganization {  get; set; }
        public bool? pinned { get; set; }
        public string url { get; set; }
        public string shortUrl { get; set; }
        public Prefs prefs { get; set; }
    }
    public class Prefs
    {
        public string permissionLevel { get; set; }
        public bool? hideVotes { get; set; }
        public string voting {  get; set; }
        public string comments { get; set; }
        public bool? selfJoin { get; set; }
        public bool? isTemplate { get; set; }
        public string cardAging { get; set; }
        public bool? calendarFeedEnabled { get; set; }
        public string background {  get; set; }
        public string backgroundImage { get; set; }
        public List<BackgroundImageScaled> backgroundImageScaled {  get; set; }

    }
    public class BackgroundImageScaled
    {
        public int width { get; set; }
        public int height { get; set; }
        public string url { get; set; }
    }
}
