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
using AppHockeyClub.crud.teams;
using AppHockeyClub.crud.players;

namespace AppHockeyClub.listpage
{
    /// <summary>
    /// Логика взаимодействия для TeamsWindow.xaml
    /// </summary>
    public partial class TeamsWindow : Window
    {
        private MyDbContext _context = new MyDbContext();
        public TeamsWindow()
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


        private void AddButton_Click(object sender, RoutedEventArgs e)
        {
            AddT at = new AddT();
            at.Show();
            this.Close();
        }

        private void EditButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (TeamsDataGrid.SelectedItem == null)
                {
                    MessageBox.Show("Выберите команду для редактирования", "Предупреждение",
                        MessageBoxButton.OK, MessageBoxImage.Warning);
                    return;
                }

                dynamic selectedTeam = TeamsDataGrid.SelectedItem;
                int teamId = selectedTeam.TeamId;

                var teamToEdit = _context.Teams
                    .Include(t => t.Coach)
                    .FirstOrDefault(t => t.TeamId == teamId);

                if (teamToEdit != null)
                {
                    EditT editWindow = new EditT(teamToEdit);
                    editWindow.Show();
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Выбранная команда не найдена в базе данных", "Ошибка",
                        MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при открытии формы редактирования: {ex.Message}", "Ошибка",
                    MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void DeleteButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (TeamsDataGrid.SelectedItem == null)
                {
                    MessageBox.Show("Выберите команду для удаления", "Предупреждение", MessageBoxButton.OK, MessageBoxImage.Warning);
                    return;
                }

                dynamic selectedTeams = TeamsDataGrid.SelectedItem;
                int teamsid = selectedTeams.TeamId;

                var result = MessageBox.Show("Вы уверены, что хотите удалить эту команду?", "Подтверждение удаления",
                    MessageBoxButton.YesNo, MessageBoxImage.Question);

                if (result == MessageBoxResult.Yes)
                {
                    var teamToDelete = _context.Teams.FirstOrDefault(c => c.TeamId == teamsid);
                    if (teamToDelete != null)
                    {
                        _context.Teams.Remove(teamToDelete);
                        _context.SaveChanges();
                        LoadTeamsData(); 
                        MessageBox.Show("Команда успешно удалена", "Успех", MessageBoxButton.OK, MessageBoxImage.Information);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при удалении команды: {ex.Message}", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        
        private void BackButton_Click(object sender, RoutedEventArgs e)
        {
            MenuWindow mw = new MenuWindow();
            mw.Show();
            this.Close();
        }

        private void TeamsDataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }
}
