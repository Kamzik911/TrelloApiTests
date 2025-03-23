namespace TrelloApiTests.Boards
{
    [TestClass]
    public class Tests
    {
        BoardMethods boardMethods = new BoardMethods();
        LabelMethods labelMethods = new LabelMethods();


        [TestMethod]            
        public void ACreateBoard_ShouldPass()
        {
            boardMethods.CreateBoard();
        }

        [TestMethod]
        public void BGetBoard_ShouldPass()
        {
            boardMethods.GetBoard();
        }

        [TestMethod]
        public void CCreateACalendarKeyForABoard_ShouldPass()
        {
            boardMethods.CreateACalendarKeyForABoard();
        }

        [TestMethod]
        public void DCreateEmailKeyForABoard_ShouldPass()
        {
            boardMethods.CreateEmailKeyForABoard();
        }

        [DataTestMethod]
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
        public void ECreateLabelOnBoard_ShouldPass(string colour)
        {
            labelMethods.CreateLabelOnBoard(colour);
        }

        [TestMethod]
        public void FUpdateBoard_ShouldPass()
        {
           boardMethods.UpdateBoard();
        }

        [TestMethod]
        public void GMarkBoardAsViewed_ShouldPass()
        {
            boardMethods.MarkBoardAsViewed();
        }

        //[TestMethod]
        public void ZDeleteBoard_ShouldPass()
        {
            boardMethods.DeleteBoard();
        }
    }
}
