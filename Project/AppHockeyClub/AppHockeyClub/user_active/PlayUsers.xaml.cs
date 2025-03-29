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
    /// Логика взаимодействия для PlayUsers.xaml
    /// </summary>
    public partial class PlayUsers : Window
    {
        private MyDbContext _context = new MyDbContext();
        public PlayUsers()
        {
            InitializeComponent();
            LoadPlayData();
        }

        private void LoadPlayData()
        {
            var gameSchedules = _context.GameSchedules
                .Include(gs => gs.Teams)
                .Include(gs => gs.Arena)
                .Select(gs => new
                {
                    gs.GameScheduleId,
                    TeamName = gs.Teams.FirstOrDefault()!.Name,
                    ArenaName = gs.Arena.Name,
                    gs.Date,
                    gs.TimeStart,
                    gs.TimeEnd
                })
                .ToList();

            GamesScheduleDataGrid.ItemsSource = gameSchedules;
        }

        private void BackButton_Click(object sender, RoutedEventArgs e)
        {
            UserMenu mw = new UserMenu();
            mw.Show();
            this.Close();
        }

        private void GamesScheduleDataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }
}
