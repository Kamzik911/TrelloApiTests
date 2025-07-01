namespace TrelloApiTests.Tests
{
    [TestClass]
    public class IndependentTests
    {
        BoardMethods boardMethods = new BoardMethods();

        [TestMethod]
        public void CreateBoard()
        {
            boardMethods.CreateBoard();
        }

        [TestMethod]
        public void GetBoardId()
        {
            boardMethods.CreateBoard();
            boardMethods.GetBoard();
            boardMethods.DeleteBoard();
        }
    }
}
