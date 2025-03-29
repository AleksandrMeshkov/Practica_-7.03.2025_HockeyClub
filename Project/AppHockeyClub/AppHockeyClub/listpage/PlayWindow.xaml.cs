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

namespace AppHockeyClub.listpage
{
    /// <summary>
    /// Логика взаимодействия для PlayWindow.xaml
    /// </summary>
    public partial class PlayWindow : Window
    {
        private MyDbContext _context = new MyDbContext();
        public PlayWindow()
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
            MenuWindow mw = new MenuWindow();
            mw.Show();
            this.Close();
        }

        private void GamesScheduleDataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }
}
