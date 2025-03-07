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
        public void BGetBoard_ShouldPass()
        {
            methods.GetBoard();
        }

        [TestMethod]
        public void CUpdateBoard_ShouldPass()
        {
           methods.UpdateBoard();
        }

        [TestMethod]
        public void DDeleteBoard_ShouldPass()
        {
            methods.DeleteBoard();
        }
    }
}
