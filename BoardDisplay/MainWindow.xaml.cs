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
        bool playerSwitch = true;
        Button[,] BoardDisplay = new Button[8, 8];
        Piece[,] BoardArray = new Piece[8, 8];
        SolidColorBrush selectable = new SolidColorBrush(Color.FromArgb((byte)100, (byte)0, (byte)255, (byte)255));
        Piece moving;
        int moving_row, moving_column;
        public List<int[]> locate = new List<int[]>();

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
            p[1, 0] = new Pawn(false);
            p[1, 1] = new Pawn(false);
            p[1, 2] = new Pawn(false);
            p[1, 3] = new Pawn(false);
            p[1, 4] = new Pawn(false);
            p[1, 5] = new Pawn(false);
            p[1, 6] = new Pawn(false);
            p[1, 7] = new Pawn(false);

            p[7, 0] = new Rook(true);
            p[7, 1] = new Knight(true);
            p[7, 2] = new Bishop(true);
            p[7, 3] = new Queen(true);
            p[7, 4] = new King(true);
            p[7, 5] = new Bishop(true);
            p[7, 6] = new Knight(true);
            p[7, 7] = new Rook(true);
            p[6, 0] = new Pawn(true);
            p[6, 1] = new Pawn(true);
            p[6, 2] = new Pawn(true);
            p[6, 3] = new Pawn(true);
            p[6, 4] = new Pawn(true);
            p[6, 5] = new Pawn(true);
            p[6, 6] = new Pawn(true);
            p[6, 7] = new Pawn(true);
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
            ResetClick(ref b);
        }
        public void MoveSingle(ref Piece[,] p)
        {
            UpdateDisplay(ref BoardDisplay);
        }
        public void CheckMove(ref Button[,] board, Button b)
        {
            //bool[,] moveable = new bool[8, 8];
            int row = 0;
            int column = 0;


            for (int i = 0; i < board.GetLength(0); i++)
            {
                for (int x = 0; x < board.GetLength(1); x++)
                {
                    if (board[i, x] == b)
                    {
                        board[i, x].Click -= OnClick;
                        row = i;
                        column = x;
                        moving_row = i;
                        moving_column = x;
                        moving = BoardArray[i, x];
                        i = 56;
                        break;
                    }
                }
            }
            BoardArray[row, column].KingInCheck(CheckForCheck());

            for (int i = 0; i < board.GetLength(0); i++)
            {
                for (int x = 0; x < board.GetLength(1); x++)
                {
                    if (board[i, x] != b)
                    {
                        if (BoardArray[row, column].CanMove(ref BoardArray, row, column, i, x))
                        {
                            //BoardDisplay[i, x].IsEnabled = true;
                            //BoardDisplay[i, x].Click += OnClick;
                            BoardDisplay[i, x].Background = selectable;
                            TurnOnClick(ref BoardDisplay, i, x);
                        }
                        else
                        {
                            //BoardDisplay[i, x].IsEnabled = false;
                            BoardDisplay[i, x].Click -= OnClick;

                        }
                    }
                }
            }
        }
        private void TurnOnClick(ref Button[,] b, int row, int column)
        {
            b[row, column].Click += OnClick;
        }
        private void ResetClick(ref Button[,] b)
        {
            for (int i = 0; i < b.GetLength(0); i++)
            {
                for (int x = 0; x < b.GetLength(1); x++)
                {
                    if (BoardArray[i, x] != null)
                    {
                        if ((playerSwitch == true && BoardArray[i, x].Color == 0) ||
                            playerSwitch == false && BoardArray[i, x].Color == 1)
                        {
                            b[i, x].Click -= OnClick;
                            b[i, x].Click += OnClick;
                        }
                        else
                        {
                            b[i, x].Click -= OnClick;
                        }
                    }
                    else
                    {
                        b[i, x].Click -= OnClick;
                    }
                }
            }
        }
        private void ResetColor(ref Button[,] b)
        {
            for (int i = 0; i < b.GetLength(0); i++)
            {
                for (int x = 0; x < b.GetLength(1); x++)
                {
                    //b[i, x].Click += OnClick;
                    if ((i % 2 == 0 && x % 2 == 1) || (i % 2 == 1 && x % 2 == 0))
                    {
                        b[i, x].Background = Brushes.DodgerBlue;
                    }
                    else
                    {
                        b[i, x].Background = Brushes.White;
                    }
                }
            }
        }
        private bool Select(Button[,] b)
        {
            bool selecting = true;
            for (int i = 0; i < b.GetLength(0); i++)
            {
                for (int x = 0; x < b.GetLength(1); x++)
                {
                    if (b[i, x].Background == selectable)
                    {
                        selecting = false;
                    }
                }
            }

            return selecting;
        }
        private void OnClick(object sender, RoutedEventArgs e)
        {

            if (Select(BoardDisplay))
            {

                CheckMove(ref BoardDisplay, (Button)sender);
            }
            else
            {
                for (int i = 0; i < BoardDisplay.GetLength(0); i++)
                {
                    for (int x = 0; x < BoardDisplay.GetLength(1); x++)
                    {
                        //TurnOnClick(ref BoardDisplay, i, x);
                        if (BoardDisplay[i, x] == (Button)sender)
                        {
                            moving.Move(ref BoardArray, moving_row, moving_column, i, x);
                            playerSwitch = !playerSwitch;
                            ResetColor(ref BoardDisplay);
                            UpdateDisplay(ref BoardDisplay);
                            MessageBox.Show((playerSwitch) ? "Player 1's turn" : "Player 2's turn");
                            if (CheckForCheck())
                            {
                                //MessageBox.Show((playerSwitch) ? "Player 1 is in check" : "Player 2 is check");
                                //MessageBox.Show("You sir are in check");
                                if (CheckForCheckMate())
                                {
                                    MessageBox.Show("Checkmate");
                                    //Application.Current.Shutdown();
                                }
                                else
                                {
                                    MessageBox.Show("You sir are in check");
                                }
                            }

                        }
                    }
                }
            }
            //MessageBox.Show("Is it me you're looking for");
        }

        private int[] GetKingLocation()
        {
            int[] cord = new int[2];
            int cond = (playerSwitch) ? 0 : 1;
            for (int i = 0; i < BoardArray.GetLength(0); i++)
            {
                for (int x = 0; x < BoardArray.GetLength(0); x++)
                {
                    if (BoardArray[i, x] != null)
                    {
                        if (playerSwitch && BoardArray[i, x].Color == cond)
                        {
                            if ((string)BoardDisplay[i, x].Content == "K")
                            {
                                cord[0] = i;
                                cord[1] = x;
                            }
                        }
                        else if (!playerSwitch && BoardArray[i, x].Color == cond)
                        {
                            if ((string)BoardDisplay[i, x].Content == "k")
                            {
                                cord[0] = i;
                                cord[1] = x;
                            }
                        }
                    }
                }
            }

            return cord;
        }

        private bool CheckForCheck()
        {
            bool check = false;
            int cond = (playerSwitch) ? 1 : 0;
            int[] temp = GetKingLocation();
            // go through all the pieces and see if they can move to the opposite color king.
            for (int i = 0; i < BoardArray.GetLength(0); i++)
            {
                for (int x = 0; x < BoardArray.GetLength(0); x++)
                {
                    if (BoardArray[i, x] != null && BoardArray[i, x].Color == cond) // checking to see if it is the opposite color
                    {
                        if (BoardArray[i, x].CanMove(ref BoardArray, i, x, temp[0], temp[1])) // checks to see if it can move to the opposite color king
                        {
                            check = true;
                            //MessageBox.Show("You sir are in check");
                        }
                    }
                }
            }
            return check;
        }

        private bool CheckForCheckMate()
        {
            bool checkMate = true;
            int[] kp = GetKingLocation();

            //CheckMove(ref BoardDisplay, BoardDisplay[kp[0], kp[1]]);
            //foreach (var location in locate)
            //{
            //    BoardArray[kp[0], kp[1]].Move(ref BoardArray, kp[0], kp[1], location[0], location[1]);
            //    if(CheckForCheck() == false)
            //    {
            //        checkMate = false;
            //    }
            //    BoardArray[location[0], location[1]].Move(ref BoardArray, location[0], location[1], kp[0], kp[1]);
            //}
            // if you get into this method, the kind is already in check. Check to see if the king can move out of check or if another piece can move in the way of the king to protect it.

            
            if ((BoardArray[kp[0], kp[1]].CanMove(ref BoardArray, kp[0], kp[1], kp[0] + 1, kp[1]) && !CheckForCheck()) ||
                (BoardArray[kp[0], kp[1]].CanMove(ref BoardArray, kp[0], kp[1], kp[0], kp[1] + 1) && !CheckForCheck()) ||
                (BoardArray[kp[0], kp[1]].CanMove(ref BoardArray, kp[0], kp[1], kp[0] + 1, kp[1] + 1) && !CheckForCheck()) ||
                (BoardArray[kp[0], kp[1]].CanMove(ref BoardArray, kp[0], kp[1], kp[0] - 1, kp[1]) && !CheckForCheck()) ||
                (BoardArray[kp[0], kp[1]].CanMove(ref BoardArray, kp[0], kp[1], kp[0], kp[1] - 1) && !CheckForCheck()) ||
                (BoardArray[kp[0], kp[1]].CanMove(ref BoardArray, kp[0], kp[1], kp[0] - 1, kp[1] - 1) && !CheckForCheck()) ||
                (BoardArray[kp[0], kp[1]].CanMove(ref BoardArray, kp[0], kp[1], kp[0] - 1, kp[1] + 1) && !CheckForCheck()) ||
                (BoardArray[kp[0], kp[1]].CanMove(ref BoardArray, kp[0], kp[1], kp[0] + 1, kp[1] - 1) && !CheckForCheck()))
            {
                for (int i = 0; i < BoardArray.GetLength(0); i++)
                {
                    for (int x = 0; x < BoardArray.GetLength(1); x++)
                    {
                        // Check the camMove for all pieces of the matching color of the king that is in check.
                        // Check to see if any of those can block the king from being put into check. 
                    }
                }
            }
            else
            {
                for (int i = 0; i < BoardArray.GetLength(0); i++)
                {
                    for (int x = 0; x < BoardArray.GetLength(1); x++)
                    {
                        // Check the camMove for all pieces of the matching color of the king that is in check.
                        // Check to see if any of those can block the king from being put into check mate. 

                        // If nothing can block the checkMate = true; 
                    }
                }
                checkMate = true;
            } 

            return checkMate;
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            MessageBox.Show((playerSwitch) ? "Player 1's turn" : "Player 2's turn");
        }

        public MainWindow()
        {
            InitializeComponent();
            InitializePieces(ref BoardArray);
            SetupDisplay(ref BoardDisplay);
            UpdateDisplay(ref BoardDisplay);
        }


    }
}
