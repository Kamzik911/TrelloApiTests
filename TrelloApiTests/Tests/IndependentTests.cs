using Microsoft.Testing.Platform.OutputDevice;
using System.Drawing;

namespace TrelloApiTests.Tests
{
    [TestClass]
    public class IndependentTests
    {
        private BoardMethods boardMethods = new BoardMethods();
        private LabelMethods labelMethods = new LabelMethods();
        private ListMethods listMethods = new ListMethods();

        [TestMethod]
        public void CreateBoard()
        {
            this.boardMethods.CreateBoard();
            this.boardMethods.DeleteBoard();
        }

        [TestMethod]
        public void GetBoardId()
        {
            this.boardMethods.CreateBoard();
            this.boardMethods.GetBoard();
            this.boardMethods.DeleteBoard();
        }

        [TestMethod]
        public void CreateACalendarKeyForABoard_ShouldPass()
        {
            this.boardMethods.CreateBoard();
            this.boardMethods.CreateACalendarKeyForABoard();
            this.boardMethods.DeleteBoard();
        }

        [TestMethod]
        public void CreateEmailKeyForBoard_ShouldPass()
        {
            this.boardMethods.CreateBoard();
            this.boardMethods.CreateEmailKeyForABoard();
            this.boardMethods.DeleteBoard();
        }

        [TestMethod]
        public void UpdateBoard_ShouldPass()
        {
            this.boardMethods.CreateBoard();
            this.boardMethods.UpdateBoard();
            this.boardMethods.DeleteBoard();
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
        public void CreateLabelOnBoard_ShouldPass(string color)
        {
            this.boardMethods.CreateBoard();
            this.labelMethods.CreateLabelOnBoard(color);
            this.boardMethods.DeleteBoard();
        }

        [DataTestMethod]
        [DataRow("yellow")]
        public void GetLabelOnBoard_ShouldPass(string color)
        {
            this.boardMethods.CreateBoard();
            this.labelMethods.CreateLabelOnBoard(color);
            this.labelMethods.GetCreatedLabel();
            this.boardMethods.DeleteBoard();
        }

        [DataTestMethod]
        [DataRow("yellow")]
        [DataRow("sky")]
        public void UpdateCreatedLabel_ShouldPass(string color)
        {
            this.boardMethods.CreateBoard();
            this.labelMethods.CreateLabelOnBoard(color);
            this.labelMethods.UpdateCreatedLabel(color);
            this.boardMethods.DeleteBoard();
        }

        [DataTestMethod]
        [DataRow("yellow")]
        [DataRow("purple")]
        public void CreateList_ShouldPass(string color)
        {
            this.boardMethods.CreateBoard();
            this.labelMethods.CreateLabelOnBoard(color);
            this.listMethods.CreateList();
            this.boardMethods.DeleteBoard();
        }
    }
}
