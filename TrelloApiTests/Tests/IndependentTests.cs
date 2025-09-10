using TrelloApiTests.ObjectsProperties;

namespace TrelloApiTests.Tests
{
    [TestClass]
    public class IndependentTests
    {
        private readonly BoardProperties boardProperties = new BoardProperties();
        private readonly LabelProperties labelProperties = new LabelProperties();
        private readonly ListProperties listProperties = new ListProperties();
        private readonly MembersProperties membersProperties = new MembersProperties();
        private readonly CardProperties cardProperties = new CardProperties();
                
        private readonly BoardMethods boardMethods;        
        private readonly LabelMethods labelMethods;
        private readonly ListMethods listMethods;
        private readonly MembershipMethods membershipMethods;

        public IndependentTests()
        {
            this.boardMethods = new BoardMethods(boardProperties);            
            this.labelMethods = new LabelMethods(labelProperties, boardProperties, cardProperties);
            this.listMethods = new ListMethods(listProperties, boardProperties);
            this.membershipMethods = new MembershipMethods(boardProperties);
        }
                
        [TestMethod]
        public async Task B003CreateACalendarKeyForABoard_Forbidden()
        {
            await boardMethods.CreateBoard().ConfigureAwait(false);
            await boardMethods.CreateACalendarKeyForABoard().ConfigureAwait(false);
            await boardMethods.DeleteBoard().ConfigureAwait(false);
        }

        [TestMethod]
        public async Task B004CreateEmailKeyForBoard_ShouldPass()
        {
            await boardMethods.CreateBoard().ConfigureAwait(false);
            await boardMethods.CreateEmailKeyForABoard().ConfigureAwait(false); ;
            await boardMethods.DeleteBoard().ConfigureAwait(false); ;
        }       

        [TestMethodAttribute]
        [DataRow("yellow")]
        [DataRow("purple")]
        [DataRow("blue")]
        [DataRow("red")]
        [DataRow("green")]
        [DataRow("orange")]
        [DataRow("black")]
        [DataRow("sky")]
        [DataRow("pink")]
        [DataRow("lime")]
        public async Task B006CreateLabelOnBoard_ShouldPass(string color)
        {
            await boardMethods.CreateBoard().ConfigureAwait(false);
            await labelMethods.CreateLabelOnBoard(color).ConfigureAwait(false);
            await boardMethods.DeleteBoard().ConfigureAwait(false);
        }

        [TestMethodAttribute]
        [DataRow("yellow")]
        public async Task B007GetLabelOnBoard_ShouldPass(string color)
        {
            await boardMethods.CreateBoard().ConfigureAwait(false);
            await labelMethods.CreateLabelOnBoard(color).ConfigureAwait(false);
            await labelMethods.GetCreatedLabel().ConfigureAwait(false);
            await boardMethods.DeleteBoard().ConfigureAwait(false);
        }

        [TestMethodAttribute]
        [DataRow("yellow")]
        [DataRow("sky")]
        public async Task B008UpdateCreatedLabel_ShouldPass(string color)
        {
            await boardMethods.CreateBoard().ConfigureAwait(false);
            await labelMethods.CreateLabelOnBoard(color).ConfigureAwait(false);
            await labelMethods.UpdateCreatedLabel(color).ConfigureAwait(false);
            await boardMethods.DeleteBoard().ConfigureAwait(false);
        }

        [TestMethod]        
        public async Task B009CreateList_ShouldPass()
        {
            await boardMethods.CreateBoard().ConfigureAwait(false);            
            await listMethods.CreateList().ConfigureAwait(false);
            await boardMethods.DeleteBoard().ConfigureAwait(false);
        }

        [TestMethod]
        public async Task B010GetList_ShouldPass()
        {
            await boardMethods.CreateBoard().ConfigureAwait(false);
            await listMethods.CreateList().ConfigureAwait(false);
            await listMethods.GetListId().ConfigureAwait(false);
            await boardMethods.DeleteBoard().ConfigureAwait(false);
        }

        [TestMethod]
        public async Task B11GetMembershipsOfBoard_ShouldPass()
        {
            await boardMethods.CreateBoard().ConfigureAwait(false);
            await membershipMethods.GetMembershipOfBoard().ConfigureAwait(false);
            await boardMethods.DeleteBoard().ConfigureAwait(false);
        }
    }
}
