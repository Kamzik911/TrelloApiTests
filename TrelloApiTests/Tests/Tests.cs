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
        CheckListMethods checkListMethods = new CheckListMethods();        

        [TestMethod]            
        public void A100_CreateBoard_ShouldPass()
        {
            boardMethods.CreateBoard();
        }

        [TestMethod]
        public void A101_GetBoard_ShouldPass()
        {
            boardMethods.GetBoard();
        }

        [TestMethod]
        public void A102_CreateACalendarKeyForABoard_ShouldPass()
        {
            boardMethods.CreateACalendarKeyForABoard();
        }

        [TestMethod]
        public void A103_DCreateEmailKeyForABoard_ShouldPass()
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
        public void A200_CreateLabelOnBoard_ShouldPass(string color)
        {
            labelMethods.CreateLabelOnBoard(color);
        }

        [TestMethod]
        public void A201_GetLabelOnBoard_ShouldPass()
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
        public void A202_UpdateCreatedLabel_ShouldPass(string color)
        {
            labelMethods.UpdateCreatedLabel(color);
        }

        [TestMethod]
        public void A300_CreateList_ShouldPass()
        {
            listMethods.CreateList();
        }

        [TestMethod]
        public void A301_GetListId_ShouldPass()
        {
            listMethods.GetListId();
        }

        [TestMethod]
        public void A302_GetActionsForList_ShouldPass()
        {
            listMethods.GetActionsForList();
        }

        [TestMethod]
        public void A402_GetCardInList_ShouldPass()
        {
            listMethods.GetCardInList();
        }

        [TestMethod]
        public void A304_UpdateListId_ShouldPass()
        {
            listMethods.UpdateListId();
        }

        [DataTestMethod]
        [DataRow(true)]
        [DataRow(false)]
        public void A305_ArchiveUnarchiveList_ShouldPass(bool value)
        {
            listMethods.ArchiveUnarchiveList(value);
        }

        [TestMethod]
        public void A400_CreateNewCard_ShouldPass()
        {
            cardMethods.CreateNewCard();
        }

        [TestMethod]
        public void A401_GetCardId_ShouldPass()
        {
            cardMethods.GetCardId();
        }

        [TestMethod]
        public void A403_ArchiveAllCardsInList()
        {
            listMethods.ArchiveAllCardsInList();
        }

        [TestMethod]
        public void A902_DeleteCardId_ShouldPass()
        {
            cardMethods.DeleteCardId();
        }

        [TestMethod]
        public void A500_CreateChecklist_ShouldPass()
        {
            checkListMethods.CreateCheckList();
        }

        [TestMethod]
        public void A901_DeleteCheckList_ShouldPass()
        {
            checkListMethods.DeleteCheckList();
        }

        [TestMethod]
        public void A903_DeleteLabel_ShouldPass()
        {
            labelMethods.DeleteLabel();
        }

        [TestMethod]
        public void A104_UpdateBoard_ShouldPass()
        {
           boardMethods.UpdateBoard();
        }

        //[TestMethod]
        public void HMarkBoardAsViewed_ShouldPass()
        {
            boardMethods.MarkBoardAsViewed();
        }

        [TestMethod]
        public void A904_DeleteBoard_ShouldPass()
        {
            boardMethods.DeleteBoard();
        }

        [TestMethod]
        public void A999_CleanAllIdsAfterTests()
        {
            ApiMethods.CleanUpIds.CleanAllIds();
        }
    }
}
