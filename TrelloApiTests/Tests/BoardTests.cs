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
            await this.boardMethods.CreateBoard().ConfigureAwait(false);
            await this.boardMethods.DeleteBoard().ConfigureAwait(false);
        }

        [TestMethod]
        public async Task B002GetBoardId()
        {
            await this.boardMethods.CreateBoard().ConfigureAwait(false);
            await this.boardMethods.GetBoard().ConfigureAwait(false);
            await this.boardMethods.DeleteBoard().ConfigureAwait(false);
        }

        [TestMethod]
        public async Task B0021GetBoardIdWithWrongApiKey_ShouldPass()
        {
            await this.boardMethods.CreateBoard().ConfigureAwait(false);
            await this.boardMethods.GetBoardWithWrongApiKey().ConfigureAwait(false);
            await this.boardMethods.DeleteBoard().ConfigureAwait(false);
        }

        [TestMethod]
        public async Task B003UpdateBoard_Pass()
        {
            await this.boardMethods.CreateBoard().ConfigureAwait(false);
            await this.boardMethods.UpdateBoard().ConfigureAwait(false); ;
            await this.boardMethods.DeleteBoard().ConfigureAwait(false); ;
        }

        //TODO
        public async Task B004MarkBoardAsVieved_Pass()
        {
            await this.boardMethods.CreateBoard().ConfigureAwait(false);
            await this.boardMethods.MarkBoardViewed().ConfigureAwait(false);
            await this.boardMethods.DeleteBoard().ConfigureAwait(false);
        }
    }
}
