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
    /// Логика взаимодействия для StaticticsUsers.xaml
    /// </summary>
    public partial class StaticticsUsers : Window
    {
        private MyDbContext _context = new MyDbContext();
        public StaticticsUsers()
        {
            InitializeComponent();
            LoadStatisticsData();
        }


        private void LoadStatisticsData()
        {

            var stats = _context.Statistics
        .Include(s => s.CompositionTeams)
            .ThenInclude(ct => ct.Players)
        .Select(s => new
        {
            s.StatisticsId,
            PlayersId = s.CompositionTeams.FirstOrDefault().Players.PlayersId,
            PlayerFullName = $"{s.CompositionTeams.FirstOrDefault().Players.Surname} " +
                           $"{s.CompositionTeams.FirstOrDefault().Players.Name}",
            s.NumberHeads,
            s.Assist,
            GameTimeMinutes = $"{s.GameTime.TotalMinutes:0} мин",
            PenaltyTimeMinutes = $"{s.PenaltyTime.TotalMinutes:0} мин"
        })
        .ToList();

            StatisticsDataGrid.ItemsSource = stats;


        }

        private void BackButton_Click(object sender, RoutedEventArgs e)
        {
            UserMenu mw = new UserMenu();
            mw.Show();
            this.Close();
        }
    }
}
