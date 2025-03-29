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
using AppHockeyClub.models;
using Microsoft.EntityFrameworkCore;

namespace AppHockeyClub.user_active
{
    /// <summary>
    /// Логика взаимодействия для PlayersUsers.xaml
    /// </summary>
    public partial class PlayersUsers : Window
    {
        private MyDbContext _context = new MyDbContext();
        public PlayersUsers()
        {
            InitializeComponent();
            LoadPlayersData();
        }


        private void LoadPlayersData()
        {

            var players = _context.Players
                .Select(p => new
                {
                    p.PlayersId,
                    p.Surname,
                    p.Name,
                    p.Patronymic,
                    p.DateBirthday,
                    p.Height,
                    p.Weight
                })
                .ToList();

            PlayersDataGrid.ItemsSource = players;

        }

        private void BackButton_Click(object sender, RoutedEventArgs e)
        {
            UserMenu mw = new UserMenu();
            mw.Show();
            this.Close();
        }
    }


}
