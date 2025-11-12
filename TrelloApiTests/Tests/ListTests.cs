namespace TrelloApiTests.Tests
{
    [TestClass]
    public class ListTests
    {
        private readonly BoardProperties boardProperties = new BoardProperties();
        private readonly ListProperties listProperties = new ListProperties();
        private readonly CardProperties cardProperties = new CardProperties();
        private readonly BoardMethods boardMethods;
        private readonly ListMethods listMethods;        

        public ListTests()
        {
            this.boardMethods = new BoardMethods(this.boardProperties);            
            this.listMethods = new ListMethods(this.boardProperties, this.listProperties, this.cardProperties);
        }

        [TestMethod]
        public async Task CreateList_ShouldPass() 
        {
            await this.boardMethods.CreateBoard().ConfigureAwait(false);
            await this.listMethods.CreateList().ConfigureAwait(false);            
            await this.boardMethods.DeleteBoard().ConfigureAwait(false);
        }        
    }
}
