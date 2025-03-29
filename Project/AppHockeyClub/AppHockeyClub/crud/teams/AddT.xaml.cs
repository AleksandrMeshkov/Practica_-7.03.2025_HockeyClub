using System;
using System.Linq;
using System.Windows;
using AppHockeyClub.listpage;
using AppHockeyClub.models;
using Microsoft.EntityFrameworkCore;

namespace AppHockeyClub.crud.teams
{
    public partial class AddT : Window
    {
        private readonly MyDbContext _context = new MyDbContext();

        public AddT()
        {
            InitializeComponent();
        }

        private async void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            
                
                if (string.IsNullOrWhiteSpace(txtName.Text))
                {
                    MessageBox.Show("Введите название команды!", "Ошибка",
                                MessageBoxButton.OK, MessageBoxImage.Warning);
                    return;
                }

               
                if (!int.TryParse(txtCoachId.Text, out int coachId) ||
                    !int.TryParse(txtTrainingScheduleId.Text, out int trainingId) ||
                    !int.TryParse(txtStaffId.Text, out int staffId) ||
                    !int.TryParse(txtQuantityPlayers.Text, out int playersCount) ||
                    !int.TryParse(txtGameScheduleId.Text, out int gameId))
                {
                    MessageBox.Show("Все ID и количества должны быть числами!", "Ошибка",
                                MessageBoxButton.OK, MessageBoxImage.Warning);
                    return;
                }

                
                
                var newTeam = new Team
                {
                    Name = txtName.Text,
                    CoachId = coachId,
                    TrainingScheduleId = trainingId,
                    StaffId = staffId,
                    QuantityPlayers = playersCount,
                    GameScheduleId = gameId
                };

                _context.Teams.Add(newTeam);
                await _context.SaveChangesAsync();

                MessageBox.Show("Команда успешно добавлена!", "Успех",
                             MessageBoxButton.OK, MessageBoxImage.Information);

            TeamsWindow teamsWindow = new TeamsWindow();
            teamsWindow.Show();
            this.Close();

        }

        private void CancelButton_Click(object sender, RoutedEventArgs e)
        {
            TeamsWindow teamsWindow = new TeamsWindow();
            teamsWindow.Show();
            this.Close();
        }

        private void txtName_TextChanged(object sender, System.Windows.Controls.TextChangedEventArgs e)
        {

        }
    }
}