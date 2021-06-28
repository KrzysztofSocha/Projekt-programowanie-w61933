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
        
        public MainWindow()
        {
            InitializeComponent();
        }

        private void bStart_Click(object sender, RoutedEventArgs e)
        {
            if (tbPlayerName.Text == "")
            {
                MessageBox.Show("Uzupełnij nazwę gracza");
            }
            else if(tbPlayerName.Text.Contains(" ") == true)
            {
                MessageBox.Show("Nazwa gracza nie może zawierać spacji");
            }
            else
            {
                this.Hide();
                var dialog = new GameWindow();
                dialog.playerName = tbPlayerName.Text;
                dialog.randomWord();
                dialog.ShowDialog();
            }
            
            
        }

        private void bEnd_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }
    }
}
