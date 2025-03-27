namespace TrelloApiTests.Boards
{
    [TestClass]
    public class Tests
    {
        BoardMethods boardMethods = new BoardMethods();
        LabelMethods labelMethods = new LabelMethods();
        ListMethods listMethods = new ListMethods();
        CardMethods cardMethods = new CardMethods();


        [TestMethod]            
        public void A1CreateBoard_ShouldPass()
        {
            boardMethods.CreateBoard();
        }

        [TestMethod]
        public void A2GetBoard_ShouldPass()
        {
            boardMethods.GetBoard();
        }

        [TestMethod]
        public void BCreateACalendarKeyForABoard_ShouldPass()
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
        public void ECreateLabelOnBoard_ShouldPass(string color)
        {
            labelMethods.CreateLabelOnBoard(color);
        }

        [TestMethod]
        public void F1GetCreatedLabel_ShouldPass()
        {
            labelMethods.GetCreatedLabel();
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
        public void F2UpdateCreatedLabel_ShouldPass(string color)
        {
            labelMethods.UpdateCreatedLabel(color);
        }

        [TestMethod]
        public void F3CreateList_ShouldPass()
        {
            listMethods.CreateList();
        }

        [TestMethod]
        public void F3GetListId_ShouldPass()
        {
            listMethods.GetListId();
        }       

        [TestMethod]
        public void F3GetBoardListIsOn_ShouldPass()
        {
            listMethods.GetBoardListIsOn();
        }

        public void F3UpdateCreatedList_ShouldPass()
        {
            listMethods.UpdateCreatedList();
        }

        //[TestMethod]
        public void F4CreateNewCard_ShouldPass()
        {
            cardMethods.CreateNewCard();
        }

        //[TestMethod]
        public void F41GetCardId_ShouldPass()
        {
            cardMethods.GetCardId();
        }

        [TestMethod]
        public void F9DeleteLabel_ShouldPass()
        {
            labelMethods.DeleteLabel();
        }

        [TestMethod]
        public void GUpdateBoard_ShouldPass()
        {
           boardMethods.UpdateBoard();
        }

        //[TestMethod]
        public void HMarkBoardAsViewed_ShouldPass()
        {
            boardMethods.MarkBoardAsViewed();
        }

        [TestMethod]
        public void ZDeleteBoard_ShouldPass()
        {
            boardMethods.DeleteBoard();
        }
    }
}
