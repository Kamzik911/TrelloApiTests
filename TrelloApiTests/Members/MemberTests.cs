namespace TrelloApiTests.Members
{
    [TestClass]
    public class MemberTests
    {        
        MembersMethods methods = new MembersMethods();
        
        [TestMethod]
        public void GetMembers_ShouldPass()
        {
            methods.GetMemberId();
        }
    }
}
