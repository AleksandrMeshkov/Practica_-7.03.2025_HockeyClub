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
using AppHockeyClub.listpage;

namespace AppHockeyClub
{
    /// <summary>
    /// Логика взаимодействия для MenuWindow.xaml
    /// </summary>
    public partial class MenuWindow : Window
    {
        public MenuWindow()
        {
            InitializeComponent();
        }

       

        private void TeamButton_Click(object sender, RoutedEventArgs e)
        {
            TeamsWindow tw = new TeamsWindow();
            tw.Show();
            this.Close();
        }

        private void PlayersButton_Click(object sender, RoutedEventArgs e)
        {
            PlayersWindow pw = new PlayersWindow();
            pw.Show();
            this.Close();
        }

        private void CoachButton_Click(object sender, RoutedEventArgs e)
        {
            CoachesWindow cw = new CoachesWindow();
            cw.Show();
            this.Close();
        }

        private void PlayButton_Click(object sender, RoutedEventArgs e)
        {
            PlayWindow plw = new PlayWindow();
            plw.Show();
            this.Close();
        }

        private void StatButton_Click(object sender, RoutedEventArgs e)
        {
            StatiscticsWindow sw = new StatiscticsWindow();
            sw.Show();
            this.Close();
        }
    }
}
