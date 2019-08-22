using BoardDisplay.Pieces;
using BoardDisplay.Models;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Shapes;

namespace BoardDisplay
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        #region Properties
        readonly int MaxRows = 8;
        readonly int MaxColumns = 8;
        PieceColor CurrentPieceColorTurn = PieceColor.WHITE;
        bool IsTryingToMove;
        Piece[,] PieceArray;
        #endregion
        #region Constructor
        public MainWindow()
        {
            InitializeComponent();
            CreateStandardPieces();
            CreateBoard();
        }
        private void Window_Loaded(object sender, RoutedEventArgs e){}
        #endregion
        #region Initialization Methods
        private void CreateStandardPieces()
        {
            PieceArray = new Piece[8, 8];
            Piece[] pieces = {
                new Rook(PieceColor.BLACK, new Models.BoardPosition(0, 0)),
                new Knight(PieceColor.BLACK, new Models.BoardPosition(0, 1)),
                new Bishop(PieceColor.BLACK, new Models.BoardPosition(0, 2)),
                new King(PieceColor.BLACK, new Models.BoardPosition(0, 3)),
                new Queen(PieceColor.BLACK, new Models.BoardPosition(0, 4)),
                new Bishop(PieceColor.BLACK, new Models.BoardPosition(0, 5)),
                new Knight(PieceColor.BLACK, new Models.BoardPosition(0, 6)),
                new Rook(PieceColor.BLACK, new Models.BoardPosition(0, 7)),

                new Pawn(PieceColor.BLACK, new Models.BoardPosition(1, 0)),
                new Pawn(PieceColor.BLACK, new Models.BoardPosition(1, 1)),
                new Pawn(PieceColor.BLACK, new Models.BoardPosition(1, 2)),
                new Pawn(PieceColor.BLACK, new Models.BoardPosition(1, 3)),
                new Pawn(PieceColor.BLACK, new Models.BoardPosition(1, 4)),
                new Pawn(PieceColor.BLACK, new Models.BoardPosition(1, 5)),
                new Pawn(PieceColor.BLACK, new Models.BoardPosition(1, 6)),
                new Pawn(PieceColor.BLACK, new Models.BoardPosition(1, 7)),

                new Pawn(PieceColor.WHITE, new Models.BoardPosition(6, 0)),
                new Pawn(PieceColor.WHITE, new Models.BoardPosition(6, 1)),
                new Pawn(PieceColor.WHITE, new Models.BoardPosition(6, 2)),
                new Pawn(PieceColor.WHITE, new Models.BoardPosition(6, 3)),
                new Pawn(PieceColor.WHITE, new Models.BoardPosition(6, 4)),
                new Pawn(PieceColor.WHITE, new Models.BoardPosition(6, 5)),
                new Pawn(PieceColor.WHITE, new Models.BoardPosition(6, 6)),
                new Pawn(PieceColor.WHITE, new Models.BoardPosition(6, 7)),

                new Rook(PieceColor.WHITE, new Models.BoardPosition(7, 0)),
                new Knight(PieceColor.WHITE, new Models.BoardPosition(7, 1)),
                new Bishop(PieceColor.WHITE, new Models.BoardPosition(7, 2)),
                new King(PieceColor.WHITE, new Models.BoardPosition(7, 3)),
                new Queen(PieceColor.WHITE, new Models.BoardPosition(7, 4)),
                new Bishop(PieceColor.WHITE, new Models.BoardPosition(7, 5)),
                new Knight(PieceColor.WHITE, new Models.BoardPosition(7, 6)),
                new Rook(PieceColor.WHITE, new Models.BoardPosition(7, 7))
            };

            foreach (var piece in pieces)
            {
                PieceArray[piece.Position.Row, piece.Position.Column] = piece;
            }

        }
        private void CreateBoard()
        {

            DisplayBoard.Height = Canvas_Main.Height;
            DisplayBoard.Width = Canvas_Main.Width;
            PieceBoard.Height = Canvas_Main.Height;
            PieceBoard.Width = Canvas_Main.Width;
            MoveBoard.Height = Canvas_Main.Height;
            MoveBoard.Width = Canvas_Main.Width;
            for (int rows = 0; rows < MaxRows; rows++)
            {
                DisplayBoard.RowDefinitions.Add(new RowDefinition());
                PieceBoard.RowDefinitions.Add(new RowDefinition());
                MoveBoard.RowDefinitions.Add(new RowDefinition());
            }
            for (int columns = 0; columns < MaxRows; columns++)
            {
                DisplayBoard.ColumnDefinitions.Add(new ColumnDefinition());
                PieceBoard.ColumnDefinitions.Add(new ColumnDefinition());
                MoveBoard.ColumnDefinitions.Add(new ColumnDefinition());
            }

            ColorBoard();
            FilleBoardWithPieces();
        }
        private void FilleBoardWithPieces()
        {
            for (int row = 0; row < MaxRows; row++)
            {
                for (int column = 0; column < MaxColumns; column++)
                {
                    Piece p;
                    if((p = PieceArray[row,column]) != null)
                    {
                        Label r = new Label()
                        {
                            Width = 25,
                            Height = 25,
                            Content = p.ToString(),
                            VerticalAlignment = VerticalAlignment.Center,
                            HorizontalAlignment = HorizontalAlignment,
                            Foreground = new SolidColorBrush(p.PieceColor == PieceColor.WHITE ? Colors.Black : Colors.White),
                            Background = new SolidColorBrush(p.PieceColor == PieceColor.WHITE ? Colors.White : Colors.Black)
                        };

                        r.MouseLeftButtonUp += PieceClick;

                        Grid.SetColumn(r, column);
                        Grid.SetRow(r, row);

                        PieceBoard.Children.Add(r);
                    }
                }
            }
        }
        private void ColorBoard()
        {
            for (int row = 0; row < MaxRows; row++)
            {
                for (int column = 0; column < MaxColumns; column++)
                {
                    Border b = new Border()
                    {
                        Background = (row + column) % 2 == 0 ? new SolidColorBrush(Colors.Red) : new SolidColorBrush(Colors.Blue),
                        Width = DisplayBoard.Width / DisplayBoard.ColumnDefinitions.Count,
                        Height = DisplayBoard.Height / DisplayBoard.RowDefinitions.Count,
                        BorderThickness = new Thickness(2),
                        BorderBrush = new SolidColorBrush(Colors.Orange)
                    };

                    Grid.SetRow(b, row);
                    Grid.SetColumn(b, column);
                    DisplayBoard.Children.Add(b);
                }
            }
        }

        #endregion
        #region Events
        private void PieceClick(object sender, RoutedEventArgs e)
        {
            if (sender is Label)
            {
                var piece = GetPieceFromLabel(sender as Label);
                if (IsTryingToMove && piece.PieceColor == CurrentPieceColorTurn)
                {
                    ResetMoveBoard();
                    IsTryingToMove = false;
                }
                else if(piece.PieceColor == CurrentPieceColorTurn)
                {
                    DrawMoveSets(piece);
                    IsTryingToMove = true;
                }
            }
        }
        private void MoveSetClick(object sender, RoutedEventArgs e)
        {
            if (sender is Border && IsTryingToMove)
            {
                Models.BoardPosition b = GetPositionFromMoveSet(sender as Border);
                MessageBox.Show($"Trying to move to\nrow=[{b.Row}]\ncolumn=[{b.Column}] ");
                IsTryingToMove = false;
                ResetMoveBoard();
            }
        }
        #endregion
        #region Methods
        private BoardPosition GetPositionFromMoveSet(Border b)
        {
            int row = Grid.GetRow(b);
            int colum = Grid.GetColumn(b);

            return new Models.BoardPosition(row, colum);
        }
        private void ResetMoveBoard()
        {
            MoveBoard.Children.Clear();
        }
        private Piece GetPieceFromLabel(Label l)
        {
            int row = Grid.GetRow(l);
            int column = Grid.GetColumn(l);
            return PieceArray[row,column];
        }
        private void DrawMoveSets(Piece p)
        {
            for (int row = 0; row < MaxRows; row++)
            {
                for (int column = 0; column < MaxColumns; column++)
                {
                    if (p.CanMove(new Models.BoardPosition(row,column)))
                    {
                        CreateMoveTile(row, column);
                    }
                }
            }
        }
        private void CreateMoveTile(int row,int column)
        {
            Border b = new Border()
            {
                Background = new SolidColorBrush(Colors.Green),
                Width = DisplayBoard.Width / DisplayBoard.ColumnDefinitions.Count,
                Height = DisplayBoard.Height / DisplayBoard.RowDefinitions.Count,
                BorderThickness = new Thickness(2),
                BorderBrush = new SolidColorBrush(Colors.Orange)
            };

            b.MouseLeftButtonDown += MoveSetClick;

            Grid.SetRow(b, row);
            Grid.SetColumn(b, column);
            MoveBoard.Children.Add(b);
        }
        private King GetCurrentColorKing()
        {
            //PieceColor colorToFind = IsPlayerOneTurn ? PieceColor.WHITE : PieceColor.BLACK;
            //for (int searchRow = 0; searchRow < BoardArray.GetLength(0); searchRow++)
            //{
            //    for (int searchColumn = 0; searchColumn < BoardArray.GetLength(0); searchColumn++)
            //    {
            //        var pieceFound = BoardArray[searchRow, searchColumn];
            //        if (pieceFound != null && pieceFound.PieceColor == colorToFind && pieceFound is King)
            //        {
            //            return BoardArray[searchRow, searchColumn] as King;
            //        }
            //    }
            //}


            throw new System.Exception("Could not Find King");
        }
        private bool CheckForCheck()
        {
            bool check = false;
            //PieceColor cond = (IsPlayerOneTurn) ? PieceColor.WHITE : PieceColor.BLACK;
            //King king = GetCurrentColorKing();
            //// go through all the pieces and see if they can move to the opposite color king.
            //for (int i = 0; i < BoardArray.GetLength(0); i++)
            //{
            //    for (int x = 0; x < BoardArray.GetLength(0); x++)
            //    {
            //        // checking to see if it is the opposite color
            //        if (BoardArray[i, x] != null && BoardArray[i, x].PieceColor == cond)
            //        {
            //            // checks to see if it can move to the opposite color king
            //            if (BoardArray[i, x].CanMove(new Models.BoardPosition(king.Position.Row, king.Position.Column)))
            //            {
            //                check = true;
            //            }
            //        }
            //    }
            //}
            return check;
        }
        private bool CheckForCheckMate()
        {
            bool checkMate = true;
            //var king = GetCurrentColorKing();

            ////CheckMove(ref BoardDisplay, BoardDisplay[kp[0], kp[1]]);
            ////foreach (var location in locate)
            ////{
            ////    BoardArray[kp[0], kp[1]].Move(ref BoardArray, kp[0], kp[1], location[0], location[1]);
            ////    if(CheckForCheck() == false)
            ////    {
            ////        checkMate = false;
            ////    }
            ////    BoardArray[location[0], location[1]].Move(ref BoardArray, location[0], location[1], kp[0], kp[1]);
            ////}
            //// if you get into this method, the kind is already in check. Check to see if the king can move out of check or if another piece can move in the way of the king to protect it.




            //if ((king.CanMove(new Models.BoardPosition(king.Position.Row + 1, king.Position.Column)) && !CheckForCheck()) ||
            //    (king.CanMove(new Models.BoardPosition(king.Position.Row, king.Position.Column + 1)) && !CheckForCheck()) ||
            //    (king.CanMove(new Models.BoardPosition(king.Position.Row + 1, king.Position.Column + 1)) && !CheckForCheck()) ||
            //    (king.CanMove(new Models.BoardPosition(king.Position.Row - 1, king.Position.Column)) && !CheckForCheck()) ||
            //    (king.CanMove(new Models.BoardPosition(king.Position.Row, king.Position.Column - 1)) && !CheckForCheck()) ||
            //    (king.CanMove(new Models.BoardPosition(king.Position.Row - 1, king.Position.Column - 1)) && !CheckForCheck()) ||
            //    (king.CanMove(new Models.BoardPosition(king.Position.Row - 1, king.Position.Column + 1)) && !CheckForCheck()) ||
            //    (king.CanMove(new Models.BoardPosition(king.Position.Row + 1, king.Position.Column - 1)) && !CheckForCheck()))
            //{
            //    for (int i = 0; i < BoardArray.GetLength(0); i++)
            //    {
            //        for (int x = 0; x < BoardArray.GetLength(1); x++)
            //        {
            //            // Check the camMove for all pieces of the matching color of the king that is in check.
            //            // Check to see if any of those can block the king from being put into check. 
            //        }
            //    }
            //}
            //else
            //{
            //    for (int i = 0; i < BoardArray.GetLength(0); i++)
            //    {
            //        for (int x = 0; x < BoardArray.GetLength(1); x++)
            //        {
            //            // Check the camMove for all pieces of the matching color of the king that is in check.
            //            // Check to see if any of those can block the king from being put into check mate. 

            //            // If nothing can block the checkMate = true; 
            //        }
            //    }
            //    checkMate = true;
            //}

            return checkMate;
        }
        #endregion

    }
}
