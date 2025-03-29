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

namespace AppHockeyClub.user_active
{
    /// <summary>
    /// Логика взаимодействия для UserMenu.xaml
    /// </summary>
    public partial class UserMenu : Window
    {
        public UserMenu()
        {
            InitializeComponent();
        }

        private void TeamButton_Click(object sender, RoutedEventArgs e)
        {
            TeamUsers tu = new TeamUsers();
            tu.Show();
            this.Close();
        }

        private void PlayersButton_Click(object sender, RoutedEventArgs e)
        {
            PlayersUsers pu = new PlayersUsers();
            pu.Show();
            this.Close();
        }

        private void CoachButton_Click(object sender, RoutedEventArgs e)
        {
            CouchUser cu = new CouchUser();
            cu.Show();
            this.Close();
        }

        private void PlayButton_Click(object sender, RoutedEventArgs e)
        {
            PlayUsers pus = new PlayUsers();
            pus.Show();
            this.Close();
        }

        private void StatButton_Click(object sender, RoutedEventArgs e)
        {
            StaticticsUsers su = new StaticticsUsers();
            su.Show();
            this.Close();
        }
    }
}
