using BoardDisplay.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace BoardDisplay
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Button[,] BoardDisplay = new Button[8,8];
        Piece[,] BoardArray = new Piece[8, 8];

        public void InitializePieces(ref Piece[,] p)
        {
            p[0, 0] = new Rook(false);
            p[0, 1] = new Knight(false);
            p[0, 2] = new Bishop(false);
            p[0, 3] = new Queen(false);
            p[0, 4] = new King(false);
            p[0, 5] = new Bishop(false);
            p[0, 6] = new Knight(false);
            p[0, 7] = new Rook(false);

            p[7, 0] = new Rook(true);
            p[7, 1] = new Knight(true);
            p[7, 2] = new Bishop(true);
            p[7, 3] = new Queen(true);
            p[7, 4] = new King(true);
            p[7, 5] = new Bishop(true);
            p[7, 6] = new Knight(true);
            p[7, 7] = new Rook(true);
        }
        public void SetupDisplay(ref Button[,] b)
        {
            UIElement[] ue = Board.Children.Cast<UIElement>().ToArray<UIElement>();
            UIElement[] buttonsTemp = new UIElement[64];

            for (int i = 0; i < ue.Length; i++)
            {
                if (i > 16)
                {
                    buttonsTemp[i - 17] = ue[i];
                }
            }
            int count = 0;
            for (int i = 0; i < 8; i++)
            {
                for (int x = 0; x < 8; x++)
                {
                    b[i, x] = (Button)buttonsTemp[count++];
                }
            }
        }
        public void UpdateDisplay(ref Button[,] b)
        {
            for (int i = 0; i < b.GetLength(0); i++)
            {
                for (int x = 0; x < b.GetLength(1); x++)
                {
                    b[i, x].Content = (BoardArray[i, x] != null) ? BoardArray[i, x].ToString() : "";
                }
            }
        }
        public void MoveSingle(ref Piece[,] p)
        {
            
            UpdateDisplay(ref BoardDisplay);
        }
        public void CheckMove(ref Button[,] board, Button b)
        {
            bool[,] moveable = new bool[8, 8];
            int row = 0;
            int column = 0;

            for (int i = 0; i < board.GetLength(0); i++)
            {
                for (int x = 0; x < board.GetLength(1); x++)
                {
                    if(board[i,x] == b)
                    {
                        row = i;
                        column = x;
                        i = 56;
                        break;
                    }
                }
            }

            for (int i = 0; i < board.GetLength(0); i++)
            {
                for (int x = 0; x < board.GetLength(1); x++)
                {
                    if (board[i, x] != b)
                    {
                        if (BoardArray[row, column].CanMove(ref BoardArray, row, column, i, x))
                        {
                            BoardDisplay[i, x].IsEnabled = true;
                        }
                        else
                        {
                            BoardDisplay[i, x].IsEnabled = false;
                        }
                    }
                }
            }

        }
        public MainWindow()
        {
            InitializeComponent();
            InitializePieces(ref BoardArray);
            SetupDisplay(ref BoardDisplay);
            UpdateDisplay(ref BoardDisplay);           
        }

        private void A0_Click(object sender, RoutedEventArgs e)
        {
            CheckMove(ref BoardDisplay, (Button)sender);
        }

    }
}
