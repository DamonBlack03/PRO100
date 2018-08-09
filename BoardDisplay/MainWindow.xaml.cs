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
        public MainWindow()
        {
            InitializeComponent();
            //remove first 17 items
            UIElement[] ue = Board.Children.Cast<UIElement>().ToArray<UIElement>();
            UIElement[] buttonsTemp = new UIElement[64];
            Button[,] buttons = new Button[8,8];

            for (int i = 0; i < ue.Length; i++)
            {
                if(i > 16)
                {
                    buttonsTemp[i - 17] = ue[i];
                }
            }
            int count = 0;
            for (int i = 0; i < 8; i++)
            {
                for(int x = 0; x < 8; x++)
                {
                    buttons[i, x] = (Button)buttonsTemp[count++];
                    //string s = buttons[i,x]
                    //Console.Write(buttons[i,x].Name + " ");
                }
                //Console.WriteLine("");
            }
        }
    }
}
