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
            string[] pieces = System.IO.File.ReadAllLines(@"C:\Users\Damon Black\Desktop\Net\PRO100\FileIO\PiecePlacement.txt");
            for (int i = 0; i < pieces.Length; i++)
            {
                int x = (int)(pieces[i][3] - '0');
                int y = (int)(pieces[i][2] - 'A');
                bool light = (pieces[i][1] == 'l') ? true : false;
                char temp = pieces[i][0];

                switch (temp)
                {
                    case 'Q':
                        p[x, y] = new Queen(light);
                        break;
                    case 'K':
                        p[x, y] = new King(light);
                        break;
                    case 'B':
                        p[x, y] = new Bishop(light);
                        break;
                    case 'R':
                        p[x, y] = new Rook(light);
                        break;
                    case 'N':
                        p[x, y] = new Knight(light);
                        break;
                    default:
                        p[x, y] = null;
                        break;
                }
            }
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
        public void InitializeDisplay(ref Button[,] b)
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
            string[] tests = System.IO.File.ReadAllLines(@"C:\Users\Damon Black\Desktop\Net\PRO100\FileIO\MoveTests1.txt");

            int count = 0;
            for (int i = 0; i<tests.Length; i++)
            {
                count++;
                if (tests[i] != null && tests[i] != "")
                {
                    if (tests[i][0] >= 'a' && tests[i][0] <= 'h' &&
                        tests[i][3] >= 'a' && tests[i][3] <= 'h' &&
                        tests[i][1] >= '0' && tests[i][1] <= '7' &&
                        tests[i][4] >= '0' && tests[i][4] <= '7')
                    {
                        char temp_from_letter = tests[i].ToUpper()[0];
                        int temp_from_number = (int)(tests[i][1] - '0');
                        char temp_letter = tests[i].ToUpper()[3];
                        int temp_number = (int)(tests[i][4] - '0');

                        if (p[temp_from_number, temp_from_letter - 'A'] != null)
                        {
                            temp_from_letter -= 'A';
                            temp_letter -= 'A';
                            
                            p[(int)(tests[i][1] - '0'), (int)temp_from_letter].Move(ref p, temp_from_letter, (int)(tests[i][1] - '0'),
                                temp_letter,
                                (int) (tests[i][4] - '0'));
                        }
                    }                                             
                }
            }
            InitializeDisplay(ref BoardDisplay);
        }
        public MainWindow()
        {
            InitializeComponent();
            InitializePieces(ref BoardArray);
            SetupDisplay(ref BoardDisplay);
            InitializeDisplay(ref BoardDisplay);
            MoveSingle(ref BoardArray);
        }
    }
}
