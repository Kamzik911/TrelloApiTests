namespace TrelloApiTests.Tests
{
    [TestClass]
    public class IndependentTests
    {
        private BoardMethods boardMethods = new BoardMethods();
        private LabelMethods labelMethods = new LabelMethods();
        private ListMethods listMethods = new ListMethods();

        [TestInitialize]
        public void TestInitialization()
        {

        }
        
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
        public async Task B003CreateACalendarKeyForABoard_ShouldPass()
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
        public void B005UpdateBoard_ShouldPass()
        {
            this.boardMethods.CreateBoard().ConfigureAwait(false);
            this.boardMethods.UpdateBoard().ConfigureAwait(false); ;
            this.boardMethods.DeleteBoard().ConfigureAwait(false); ;
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
        public void B006CreateLabelOnBoard_ShouldPass(string color)
        {
            this.boardMethods.CreateBoard().ConfigureAwait(false);
            this.labelMethods.CreateLabelOnBoard(color).ConfigureAwait(false);
            this.boardMethods.DeleteBoard().ConfigureAwait(false);
        }

        [TestMethodAttribute]
        [DataRow("yellow")]
        public void B007GetLabelOnBoard_ShouldPass(string color)
        {
            this.boardMethods.CreateBoard().ConfigureAwait(false);
            this.labelMethods.CreateLabelOnBoard(color).ConfigureAwait(false);
            this.labelMethods.GetCreatedLabel().ConfigureAwait(false);
            this.boardMethods.DeleteBoard().ConfigureAwait(false);
        }

        [TestMethodAttribute]
        [DataRow("yellow")]
        [DataRow("sky")]
        public void B008UpdateCreatedLabel_ShouldPass(string color)
        {
            this.boardMethods.CreateBoard().ConfigureAwait(false);
            this.labelMethods.CreateLabelOnBoard(color).ConfigureAwait(false);
            this.labelMethods.UpdateCreatedLabel(color).ConfigureAwait(false);
            this.boardMethods.DeleteBoard().ConfigureAwait(false);
        }

        [TestMethod]        
        public void B009CreateList_ShouldPass()
        {
            this.boardMethods.CreateBoard().ConfigureAwait(false);            
            this.listMethods.CreateList().ConfigureAwait(false);
            this.boardMethods.DeleteBoard().ConfigureAwait(false);
        }

        [TestMethod]
        public void B010GetList_ShouldPass()
        {
            this.boardMethods.CreateBoard().ConfigureAwait(false);
            this.listMethods.CreateList().ConfigureAwait(false);
            this.listMethods.GetListId().ConfigureAwait(false);
            this.boardMethods.DeleteBoard().ConfigureAwait(false);
        }

    }
}
