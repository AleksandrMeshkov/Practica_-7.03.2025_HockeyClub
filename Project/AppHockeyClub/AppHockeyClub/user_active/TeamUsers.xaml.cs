﻿using System;
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
    /// Логика взаимодействия для TeamUsers.xaml
    /// </summary>
    public partial class TeamUsers : Window
    {
        private MyDbContext _context = new MyDbContext();
        public TeamUsers()
        {
            InitializeComponent();
            LoadTeamsData();
        }

        private void LoadTeamsData()
        {

            var teams = _context.Teams
                .Include(t => t.Coach)
                .Select(t => new
                {
                    t.TeamId,
                    t.Name,
                    CoachName = t.Coach.Surname + " " + t.Coach.Name,
                    t.QuantityPlayers,
                    t.TrainingScheduleId,
                    t.GameScheduleId,
                    t.StaffId
                })
                .ToList();

            TeamsDataGrid.ItemsSource = teams;
        }

        private void BackButton_Click(object sender, RoutedEventArgs e)
        {
            UserMenu mw = new UserMenu();
            mw.Show();
            this.Close();
        }

        private void TeamsDataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }
}
