namespace TrelloApiTests.Cards
{
    [TestClass]
    public class CardTests
    {
        CardMethods cardMethods = new CardMethods();

        [TestMethod]
        public void CreateNewCard_ShouldPass()
        {
            cardMethods.CreateNewCard();
        }

        [TestMethod]
        public void GetCardId_ShouldPass()
        {
            cardMethods.GetCardId();
        }
    }
}
