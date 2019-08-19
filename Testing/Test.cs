using BoardDisplay.Controllers;
using BoardDisplay.Pieces;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Testing
{
    [TestClass]
    public class MyTestClass
    {
        GameController controller;


        [TestMethod]
        public void TestBoardInitialization()
        {
            bool valid = true;
            controller = new GameController();
            Piece[,] board = new Piece[8, 8];


            for (int i = 0; i < controller.Board.GetLength(0); i++)
            {
                for (int x = 0; x < controller.Board.GetLength(1); x++)
                {
                    if (board[i,x] != controller.Board[i,x])
                    {
                        valid = false;
                    }
                }
            }
            //As of now should be false
            Assert.IsTrue(valid);
        }
    }
}
