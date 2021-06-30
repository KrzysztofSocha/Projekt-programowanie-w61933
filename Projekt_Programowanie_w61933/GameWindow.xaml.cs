using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
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
    /// Okno gry
    /// zawiera procedury potrzebne do rozgrywki
    /// </summary>
    public partial class GameWindow : Window
    {
        string[] words = { "ZAMEK", "DOM", "KOMIN","BÓBR","DWORZEC","MUZEUM","ĆMA","ŹREBIĘ","TRAWNIK","KOMPUTER" };
        public string word;
        public string playerName;
        int countError = 0;
        int countCorrect = 0;
        List<string> rankingTop7 = new List<string>();
        
        
        public GameWindow()
        {
            InitializeComponent();
        }
        /// <summary>
        /// Procedura generowania rankingu dla danego słowa
        ///Wybiera 7 najlepszych graczy, na podsatwie ilości błędów przez nich wykonanych
        /// </summary>
        private void generateRanking()
        {
            StreamReader srScore = File.OpenText("ScorePlayer.TXT");

            string scoreLine;
            rankingTop7.Add("Nazwa gracza: Ilość błędów:");
            for (int x = 0; x <=7; x++)
            {
                while ((scoreLine = srScore.ReadLine()) != null)
                {

                    ScorePlayer scorePlayer = new ScorePlayer(scoreLine);
                    if (scorePlayer.word ==word && scorePlayer.countError == x)
                    {
                        rankingTop7.Add(scorePlayer.playerName + " " + scorePlayer.countError);
                        
                        if (rankingTop7.Count==8)
                        {
                            break;
                        }
                    }
                }
                if (rankingTop7.Count==8)
                {
                    break;
                }
                srScore = File.OpenText("ScorePlayer.TXT");
            }
            srScore.Close();
            
        }
        /// <summary>
        /// Procedura generowania lososowego słowa z tabeli words[]
        ///Wylosowane słowo trafia do rozgrywki
        /// </summary>
        public void randomWord()
        {
            Random rand = new Random();
            
            int random = rand.Next(words.Length);
            word = words[random];
            
            for (int i = 0; i < word.Length; i++)
            {
                lWord.Content += "_ ";
            }
            
        }
        /// <summary>
        /// Procedura odpowiedzialna za rysowanie wisielca
        /// </summary>
        /// <param name="countError"> Używany do wyznaczenia, który fragment wisielca ma byc widoczny </param>
        private void drawError(int countError)
        {
            if (countError == 1)
            {
                l1.Visibility = Visibility.Visible;
            }
            else if (countError == 2)
            {
                l2.Visibility = Visibility.Visible;
            }
            else if (countError == 3)
            {
                l3.Visibility = Visibility.Visible;
            }
            else if (countError == 4)
            {
                l4.Visibility = Visibility.Visible;
            } 
            else if (countError == 5)
            {
                l5.Visibility = Visibility.Visible;
            } else if (countError == 6)
            {
                l6.Visibility = Visibility.Visible;
            } else if (countError == 7)
            {
                l7.Visibility = Visibility.Visible;
            }
            else if (countError == 8)
            {
                l8.Visibility = Visibility.Visible;
                
                MessageBoxResult result = MessageBox.Show("Koniec gry, przegrałeś. Słowo do odganięcia to: "+word+" Chcesz spróbować jeszcze raz?", "",
                                     MessageBoxButton.YesNo,
                                     MessageBoxImage.Question);
                if(result == MessageBoxResult.Yes)
                {
                    this.DialogResult = true;
                    var dialog = new GameWindow();
                    dialog.randomWord();
                    dialog.playerName = playerName;
                    dialog.ShowDialog();
                }
                else
                {
                    this.DialogResult = true;
                    Application.Current.MainWindow.Show();
                }
            }
        }
        /// <summary>
        /// Procedura odpowiedzialna za sprawdzenie czy dana litera zawiera się w zgadywanym słowie
        /// </summary>
        /// <param name="button">Potrzebny do operacji na przycisku</param>
        /// <param name="content">Zawiera znak, który przekazuje przycisk, wykorzystywany do sprawdzenia</param>
        private void checkLetter(Button button, char content)
        {
            button.IsEnabled = false;

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
                    countCorrect++;
                    if (countCorrect == word.Length)
                    {
                        MessageBox.Show("Koniec gry, wygrałeś");
                        ScorePlayer scorePlayer = new ScorePlayer(word, playerName, countError);
                        generateRanking();                        
                        var dialog = new Ranking();
                        dialog.lbRanking.ItemsSource = rankingTop7;
                        dialog.playerName = playerName;
                        this.DialogResult = true;
                        dialog.ShowDialog();

                    }
                }
                x += 2;
            }
            if (checkLetter)
            {
                button.Foreground = Brushes.Green;
            }
            else
            {                                
                countError++;
                drawError(countError);
                button.Foreground = Brushes.Red;
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
            checkLetter(bC1, 'Ć');
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
            checkLetter(BO1, 'Ó');
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
