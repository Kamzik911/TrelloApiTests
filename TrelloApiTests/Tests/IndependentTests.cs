namespace TrelloApiTests.Tests
{
    [TestClass]
    public class IndependentTests
    {
        private readonly BoardMethods boardMethods = new BoardMethods();
        private readonly LabelMethods labelMethods = new LabelMethods();
        private readonly ListMethods listMethods = new ListMethods();
        private readonly MembersMethods membersMethods = new MembersMethods();
        private readonly MembershipMethods membershipMethods = new MembershipMethods();
        
        [TestMethod]
        public async Task B001CreateBoard()
        {
            await boardMethods.CreateBoard().ConfigureAwait(false);
            await boardMethods.DeleteBoard().ConfigureAwait(false);
        }

        [TestMethod]
        public async Task B002GetBoardId()
        {
            await boardMethods.CreateBoard().ConfigureAwait(false);
            await boardMethods.GetBoard().ConfigureAwait(false);
            await boardMethods.DeleteBoard().ConfigureAwait(false);                                  
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

        [TestMethod]
        public async Task B005UpdateBoard_ShouldPass()
        {
            await boardMethods.CreateBoard().ConfigureAwait(false);
            await boardMethods.UpdateBoard().ConfigureAwait(false); ;
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
