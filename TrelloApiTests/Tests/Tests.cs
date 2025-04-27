namespace TrelloApiTests.Boards
{
    [TestClass]
    public class MemberTests
    {
        MembersMethods members = new MembersMethods();

        [TestMethod]
        public void M101_UpdateMember_ShouldPass()
        {
            members.UpdateMember();
        }

        [TestMethod]
        public void M100_GetMemberId_ShouldPass()
        {
            members.GetMemberId();
        }
    }

    [TestClass]
    public class BoardTests
    {
        BoardMethods boards = new BoardMethods();
        LabelMethods labels = new LabelMethods();
        ListMethods lists = new ListMethods();
        CardMethods cards = new CardMethods();
        CustomFieldsMethods customFields = new CustomFieldsMethods();
        CheckListMethods checkLists= new CheckListMethods();
        MembersMethods members = new MembersMethods();
                
        [TestMethod]
        public void A100_CreateBoard_ShouldPass()
        {
            boards.CreateBoard();
        }

        [TestMethod]
        public void A101_GetBoard_ShouldPass()
        {
            boards.GetBoard();
        }                

        [TestMethod]
        public void A102_CreateACalendarKeyForABoard_ShouldPass()
        {
            boards.CreateACalendarKeyForABoard();
        }

        [TestMethod]
        public void A103_DCreateEmailKeyForABoard_ShouldPass()
        {
            boards.CreateEmailKeyForABoard();
        }

        [TestMethod]
        public void A104_UpdateBoard_ShouldPass()
        {
            boards.UpdateBoard();
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
            labels.CreateLabelOnBoard(color);
        }

        [TestMethod]
        public void A201_GetLabelOnBoard_ShouldPass()
        {
            labels.GetCreatedLabel();
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
            labels.UpdateCreatedLabel(color);
        }

        [TestMethod]
        public void A300_CreateList_ShouldPass()
        {
            lists.CreateList();
        }

        [TestMethod]
        public void A301_GetListId_ShouldPass()
        {
            lists.GetListId();
        }

        [TestMethod]
        public void A302_GetActionsForList_ShouldPass()
        {
            lists.GetActionsForList();
        }        

        [TestMethod]
        public void A304_UpdateListId_ShouldPass()
        {
            lists.UpdateListId();
        }

        [DataTestMethod]
        [DataRow(true)]
        [DataRow(false)]
        public void A305_ArchiveUnarchiveList_ShouldPass(bool value)
        {
            lists.ArchiveUnarchiveList(value);
        }

        [TestMethod]
        public void A400_CreateNewCard_ShouldPass()
        {
            cards.CreateNewCard();
        }

        [TestMethod]
        public void A401_GetCardId_ShouldPass()
        {
            cards.GetCardId();
        }

        [TestMethod]
        public void A402_GetCardInList_ShouldPass()
        {
            lists.GetCardInList();
        }

        [TestMethod]
        public void A403_ArchiveAllCardsInList()
        {
            lists.ArchiveAllCardsInList();
        }
        
        [TestMethod]
        public void A500_CreateChecklist_ShouldPass()
        {
            checkLists.CreateCheckList();
        }

        [TestMethod]
        public void A501_GetCheckList_ShouldPass()
        {
            checkLists.GetCheckList();
        }       

        [TestMethod]
        public void A901_DeleteCheckList_ShouldPass()
        {
            checkLists.DeleteCheckList();
        }

        [TestMethod]
        public void A902_DeleteCardId_ShouldPass()
        {
            cards.DeleteCardId();
        }

        [TestMethod]
        public void A903_DeleteLabel_ShouldPass()
        {
            labels.DeleteLabel();
        }       

        //[TestMethod]
        public void HMarkBoardAsViewed_ShouldPass()
        {
            boards.MarkBoardAsViewed();
        }

        [TestMethod]
        public void A904_DeleteBoard_ShouldPass()
        {
            boards.DeleteBoard();
        }

        [TestMethod]
        public void A999_CleanAllIdsAfterTests()
        {
            ApiMethods.CleanupIds.CleanIds();
        }
    }
}
