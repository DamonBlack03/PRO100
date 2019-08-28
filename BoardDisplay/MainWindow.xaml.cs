using BoardDisplay.Pieces;
using BoardDisplay.Models;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using BoardDisplay.Controllers;
using System.Collections.Generic;

namespace BoardDisplay
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        #region Properties
        #region Board Colors
        readonly SolidColorBrush TilePattern1Color = new SolidColorBrush(Colors.Purple);
        readonly SolidColorBrush TilePattern2Color = new SolidColorBrush(Colors.Green);
        readonly SolidColorBrush PatternBorderColor = new SolidColorBrush(Colors.Yellow);
        readonly SolidColorBrush MoveSquareColor = new SolidColorBrush(Colors.DodgerBlue);
        readonly SolidColorBrush MoveSquareBorderColor = new SolidColorBrush(Colors.Black);
        new readonly Thickness BorderThickness = new Thickness(2);
        readonly Thickness MoveSquareBorderThickness = new Thickness(2);
        #endregion
        readonly MainController controller = new MainController();
        private GameController gameController = null;
        readonly int MaxRows = 8;
        readonly int MaxColumns = 8;
        PieceColor CurrentPieceColorTurn = PieceColor.WHITE;
        BoardPosition PositionTryingToMove = null;
        bool IsTryingToMove;
        Piece[,] PieceArray;
        #endregion
        #region Constructor
        public MainWindow()
        {
            InitializeComponent();
            CreateStandardPieces();
            CreateBoard();
            gameController = new GameController(PieceArray);
        }
        private void Window_Loaded(object sender, RoutedEventArgs e) { }
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
            DisplayBoard.MouseLeftButtonDown += PieceClick;

            ColorBoard();
            FilleBoardWithPieces();
        }
        private void FilleBoardWithPieces()
        {
            PieceBoard.Children.Clear();
            for (int row = 0; row < MaxRows; row++)
            {
                for (int column = 0; column < MaxColumns; column++)
                {
                    Piece p;
                    if ((p = PieceArray[row, column]) != null)
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
                        Background = (row + column) % 2 == 0 ? TilePattern1Color : TilePattern2Color,
                        Width = DisplayBoard.Width / DisplayBoard.ColumnDefinitions.Count,
                        Height = DisplayBoard.Height / DisplayBoard.RowDefinitions.Count,
                        BorderThickness = BorderThickness,
                        BorderBrush = PatternBorderColor
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
                var newPosition = GetPositionOfElement(sender as Label);

                if (piece.PieceColor == CurrentPieceColorTurn && (PositionTryingToMove == null || !PositionTryingToMove.Equals(newPosition)))
                {
                    ResetMoveBoard();
                    DrawMoveSets(piece);
                    IsTryingToMove = true;
                    PositionTryingToMove = newPosition;
                }
                else
                {
                    ResetMoveBoard();
                }
            }
            else
            {
                ResetMoveBoard();
            }
        }
        private void MoveSetClick(object sender, RoutedEventArgs e)
        {
            if (sender is Border && IsTryingToMove)
            {
                BoardPosition newPosition = GetPositionOfElement(sender as Border);
                if (controller.MoveSelectedPiece(PositionTryingToMove, newPosition, PieceArray))
                {
                    FilleBoardWithPieces();
                    IsTryingToMove = false;
                    CurrentPieceColorTurn = CurrentPieceColorTurn == PieceColor.WHITE ? PieceColor.BLACK : PieceColor.WHITE;
                    ResetMoveBoard();
                }
            }
        }
        #endregion
        #region Methods
        private BoardPosition GetPositionOfElement(UIElement b)
        {
            int row = Grid.GetRow(b);
            int colum = Grid.GetColumn(b);

            return new Models.BoardPosition(row, colum);
        }
        private void ResetMoveBoard()
        {
            IsTryingToMove = false;
            MoveBoard.Children.Clear();
            PositionTryingToMove = null;

        }
        private Piece GetPieceFromLabel(Label l)
        {
            int row = Grid.GetRow(l);
            int column = Grid.GetColumn(l);
            return PieceArray[row, column];
        }
        private void DrawMoveSets(Piece p)
        {
            List<BoardPosition> list = p.GetMoveSet(PieceArray);
            foreach (var item in list)
            {
                CreateMoveTile(item.Row, item.Column);
            }
        }
        private void CreateMoveTile(int row, int column)
        {
            Border b = new Border()
            {
                Background = MoveSquareColor,
                Width = DisplayBoard.Width / DisplayBoard.ColumnDefinitions.Count,
                Height = DisplayBoard.Height / DisplayBoard.RowDefinitions.Count,
                BorderThickness = MoveSquareBorderThickness,
                BorderBrush = MoveSquareBorderColor
            };

            b.MouseLeftButtonDown += MoveSetClick;

            Grid.SetRow(b, row);
            Grid.SetColumn(b, column);
            MoveBoard.Children.Add(b);
        }
        #endregion
    }
}
