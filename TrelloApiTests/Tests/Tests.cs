namespace TrelloApiTests.Boards
{
    [TestClass]
    public class Tests
    {
        BoardMethods boardMethods = new BoardMethods();
        LabelMethods labelMethods = new LabelMethods();
        ListMethods listMethods = new ListMethods();
        CardMethods cardMethods = new CardMethods();
        CustomFieldsMethods customFields = new CustomFieldsMethods();
                
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

        //[TestMethod] //Test for Power-Up
        public void ECreateCustomFieldOnBoard_ShouldPass()
        {
            customFields.CreateCustomFieldOnBoard();
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
        public void FCreateLabelOnBoard_ShouldPass(string color)
        {
            labelMethods.CreateLabelOnBoard(color);
        }

        [TestMethod]
        public void G1GetCreatedLabel_ShouldPass()
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
        public void G2UpdateCreatedLabel_ShouldPass(string color)
        {
            labelMethods.UpdateCreatedLabel(color);
        }

        [TestMethod]
        public void G31CreateList_ShouldPass()
        {
            listMethods.CreateList();
        }

        [TestMethod]
        public void G31GetListId_ShouldPass()
        {
            listMethods.GetListId();
        }

        [TestMethod]
        public void G31UpdateListId_ShouldPass()
        {
            listMethods.UpdateListId();
        }

        [TestMethod]
        public void G3ArchiveAllCardsInList()
        {
            listMethods.ArchiveAllCardsInList();
        }

        [TestMethod]
        public void G41CreateNewCard_ShouldPass()
        {
            cardMethods.CreateNewCard();
        }

        [TestMethod]
        public void G42GetCardId_ShouldPass()
        {
            cardMethods.GetCardId();
        }

        [TestMethod]
        public void G4DeleteCardId_ShouldPass()
        {
            cardMethods.DeleteCardId();
        }

        [TestMethod]
        public void XDeleteLabel_ShouldPass()
        {
            labelMethods.DeleteLabel();
        }

        [TestMethod]
        public void AUpdateBoard_ShouldPass()
        {
           boardMethods.UpdateBoard();
        }

        //[TestMethod]
        public void HMarkBoardAsViewed_ShouldPass()
        {
            boardMethods.MarkBoardAsViewed();
        }

        [TestMethod]
        public void YDeleteBoard_ShouldPass()
        {
            boardMethods.DeleteBoard();
        }       

        [TestMethod]
        public void ZCleanBoardId1()
        {
            boardMethods.CleanBoardId();
        }
    }
}
