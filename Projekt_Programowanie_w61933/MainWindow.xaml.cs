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

namespace Projekt_Programowanie_w61933
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        string[] words = { "ZAMEK", "DOM","KOMIN" };
        public MainWindow()
        {
            InitializeComponent();
        }

        private void bStart_Click(object sender, RoutedEventArgs e)
        {
            Random rand = new Random();
            string word;
            int random = rand.Next(words.Length);
            word = words[random];
            var dialog = new GameWindow();
            for(int i=0; i <word.Length; i++)
            {
                dialog.lWord.Content += "_ ";
            }
            dialog.word = word;

            dialog.ShowDialog();
        }
    }
}
