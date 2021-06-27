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
using System.Windows.Shapes;

namespace Projekt_Programowanie_w61933
{
    /// <summary>
    /// Interaction logic for GameWindow.xaml
    /// </summary>
    public partial class GameWindow : Window
    {
        public string word;
        int countError = 0;
        public GameWindow()
        {
            InitializeComponent();
        }
        private void checkLetter(Button button, char content)
        {
            //button.IsEnabled = false;

            int x = 2;
            bool checkLetter = false;
            for (int i = 0; i < word.Length; i++)
            {

                if (word[i] == content)
                {
                    char[] chars = Convert.ToString(lWord.Content).ToCharArray();
                    chars[x] = content;
                    string temp = new string(chars);
                    lWord.Content = temp;
                    checkLetter = true;
                }
                x += 2;
            }
            if (checkLetter)
            {
                button.Background = Brushes.Green;
            }
            else
            {
                //tutaj dodać funkcję, która wyświetli labele
                l1.Visibility = Visibility.Visible;
                countError++;
                button.Background = Brushes.Red;
            }
        }
        private void bA_Click(object sender, RoutedEventArgs e)
        {
            
            checkLetter(bA, 'A');
        }

        private void bA1_Click(object sender, RoutedEventArgs e)
        {
            checkLetter(bA1, 'Ą');
        }

        private void bB_Click(object sender, RoutedEventArgs e)
        {
            checkLetter(bB, 'B');
        }

        private void bC_Click(object sender, RoutedEventArgs e)
        {
            checkLetter(bC, 'C');
        }

        private void bC1_Click(object sender, RoutedEventArgs e)
        {
            checkLetter(bC1, 'C');
        }

        private void bD_Click(object sender, RoutedEventArgs e)
        {
            checkLetter(bD, 'D');
        }

        private void bE_Click(object sender, RoutedEventArgs e)
        {
            checkLetter(bE, 'E');
        }

        private void BE1_Click(object sender, RoutedEventArgs e)
        {
            checkLetter(BE1, 'Ę');
        }

        private void BF_Click(object sender, RoutedEventArgs e)
        {
            checkLetter(BF, 'F');
        }

        private void BG_Click(object sender, RoutedEventArgs e)
        {
            checkLetter(BG, 'G');
        }

        private void BH_Click(object sender, RoutedEventArgs e)
        {
            checkLetter(BH, 'H');
        }

        private void BI_Click(object sender, RoutedEventArgs e)
        {
            checkLetter(BI, 'I');
        }

        private void BJ_Click(object sender, RoutedEventArgs e)
        {
            checkLetter(BJ, 'J');
        }

        private void BK_Click(object sender, RoutedEventArgs e)
        {
            checkLetter(BK, 'K');
        }

        private void BL_Click(object sender, RoutedEventArgs e)
        {
            checkLetter(BL, 'L');
        }

        private void BL1_Click(object sender, RoutedEventArgs e)
        {
            checkLetter(BL1, 'Ł');
        }

        private void BM_Click(object sender, RoutedEventArgs e)
        {
            checkLetter(BM, 'M');
        }

        private void BN_Click(object sender, RoutedEventArgs e)
        {
            checkLetter(BN, 'N');
        }

        private void BN1_Click(object sender, RoutedEventArgs e)
        {
            checkLetter(BN1, 'Ń');
        }

        private void BO_Click(object sender, RoutedEventArgs e)
        {
            checkLetter(BO, 'O');
        }

        private void BO1_Click(object sender, RoutedEventArgs e)
        {
            checkLetter(BO1, 'O');
        }

        private void BP_Click(object sender, RoutedEventArgs e)
        {
            checkLetter(BP, 'P');
        }

        private void BR_Click(object sender, RoutedEventArgs e)
        {
            checkLetter(BR, 'R');
        }

        private void BS_Click(object sender, RoutedEventArgs e)
        {
            checkLetter(BS, 'S');
        }

        private void BS1_Click(object sender, RoutedEventArgs e)
        {
            checkLetter(BS1, 'Ś');
        }

        private void BT_Click(object sender, RoutedEventArgs e)
        {
            checkLetter(BT, 'T');
        }

        private void BU_Click(object sender, RoutedEventArgs e)
        {
            checkLetter(BU, 'U');
        }

        private void BW_Click(object sender, RoutedEventArgs e)
        {
            checkLetter(BW, 'W');
        }

        private void BY_Click(object sender, RoutedEventArgs e)
        {
            checkLetter(BY, 'Y');
        }

        private void BZ_Click(object sender, RoutedEventArgs e)
        {
            checkLetter(BZ, 'Z');
        }

        private void BZ1_Click(object sender, RoutedEventArgs e)
        {
            checkLetter(BZ1, 'Ż');
        }

        private void BZ2_Click(object sender, RoutedEventArgs e)
        {
            checkLetter(BZ2, 'Ź');
        }
    }
}
