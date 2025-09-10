namespace TrelloApiTests.Tests
{
    [TestClass]
    public class BoardTests
    {
        private readonly BoardProperties boardProperties = new BoardProperties();
        private readonly BoardMethods boardMethods;
        
        public BoardTests()
        {
            this.boardMethods = new BoardMethods(boardProperties);
        }

        [TestMethod]
        public async Task B001CreateBoard_Pass()
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
        public async Task B003UpdateBoard_Pass()
        {
            await boardMethods.CreateBoard().ConfigureAwait(false);
            await boardMethods.UpdateBoard().ConfigureAwait(false); ;
            await boardMethods.DeleteBoard().ConfigureAwait(false); ;
        }

        //TODO
        public async Task B004MarkBoardAsVieved_Pass()
        {
            await boardMethods.CreateBoard().ConfigureAwait(false);
            await boardMethods.MarkBoardViewed().ConfigureAwait(false);
            await boardMethods.DeleteBoard().ConfigureAwait(false);
        }        
    }
}
