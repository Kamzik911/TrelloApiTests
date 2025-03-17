namespace TrelloApiTests.Boards
{
    [TestClass]
    public class BoardTests
    {
        BoardMethods methods = new BoardMethods();

        [TestMethod]            
        public void ACreateBoard_ShouldPass()
        {
            methods.CreateBoard();
        }

        [TestMethod]
        public void BCreateACalendarKeyForABoard_ShouldPass()
        {
            methods.CreateACalendarKeyForABoard();
        }

        [TestMethod]
        public void CCreateEmailKeyForABoard_ShouldPass()
        {
            methods.CreateEmailKeyForABoard();
        }

        [TestMethod]
        public void DGetBoard_ShouldPass()
        {
            methods.GetBoard();
        }

        [TestMethod]
        public void EUpdateBoard_ShouldPass()
        {
           methods.UpdateBoard();
        }

        [TestMethod]
        public void FMarkBoardAsViewed_ShouldPass()
        {
            methods.MarkBoardAsViewed();
        }

        [TestMethod]
        public void GDeleteBoard_ShouldPass()
        {
            methods.DeleteBoard();
        }        
    }
}
