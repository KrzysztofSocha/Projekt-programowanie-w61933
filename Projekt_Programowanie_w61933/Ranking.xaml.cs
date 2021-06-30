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
    /// Okno rankingu graczy
    /// Wyświetla 7 najlepszy graczy dla danego słowa
    /// </summary>
    
    public partial class Ranking : Window
    {
        public string playerName;
        public Ranking()
        {
            InitializeComponent();
        }
       
 
        private void BNewGame_Click(object sender, RoutedEventArgs e)
        {
            this.DialogResult = true;
            var dialog = new GameWindow();
            dialog.randomWord();
            dialog.playerName = playerName;
            dialog.ShowDialog();
            
        }

        private void bReturn_Click(object sender, RoutedEventArgs e)
        {
            this.DialogResult = true;
            Application.Current.MainWindow.Show();
        }
    }
}
