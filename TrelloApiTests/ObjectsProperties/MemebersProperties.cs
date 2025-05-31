namespace TrelloApiTests.ObjectsProperties
{
    public class MembersProperties
    {
        public static string? id { get; set; }
        public static string? aaId { get; set; }
        public bool activityBlocked { get; set; }
        public string? avatarHash { get; set; }
        public string? avatarUrl { get; set; }
        public string? bio {  get; set; }
        public BioData bioData { get; set; }
        public bool confirmed { get; set; }
        public string fullName { get; set; }
        public string idEnterprise { get; set; }
        public string idMemberReferrer { get; set; }
        public List<IdPremOrgsAdmin> idPremOrgsAdmin { get; set; }
        public string initials { get; set; }
        public string memberType { get; set; }
        public NonPublic nonPublic { get; set; }
        public static string idBackground { get; set; }
    }
    public class BioData
    {
        public string emoji { get; set; }
    }
    public class IdPremOrgsAdmin
    {
        public string id {get; set; }
    }
    public class NonPublic
    {
        public string fullName { get; set; }
        public string initials { get; set; }
        public string avatarUrl { get; set; }
        public string avatarHash { get; set; }
    }
    public class BoardBackgroundProperties
    {
        public static string id { get; set; }
        public string type { get; set; }
        public bool tile {  get; set; }
        public string brightness { get; set; }
        public string color { get; set; }
    }
}
