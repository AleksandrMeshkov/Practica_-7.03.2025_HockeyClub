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
using AppHockeyClub.crud.players;
using AppHockeyClub.crud.coaches;

namespace AppHockeyClub.listpage
{
    /// <summary>
    /// Логика взаимодействия для PlayersWindow.xaml
    /// </summary>
    public partial class PlayersWindow : Window
    {

        private MyDbContext _context = new MyDbContext();

        public PlayersWindow()
        {
            InitializeComponent();
            LoadPlayersData();
        }

        private void LoadPlayersData()
        {

            var players  = _context.Players
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

        private void AddButton_Click(object sender, RoutedEventArgs e)
        {
            AddP ap = new AddP();
            ap.Show();
            this.Close();
        }

        private void EditButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (PlayersDataGrid.SelectedItem == null)
                {
                    MessageBox.Show("Выберите игрока для редактирования",
                                  "Предупреждение", MessageBoxButton.OK, MessageBoxImage.Warning);
                    return;
                }

                dynamic selectedPlayer = PlayersDataGrid.SelectedItem;
                int playerId = selectedPlayer.PlayersId;

                var playerToEdit = _context.Players.FirstOrDefault(p => p.PlayersId == playerId);
                if (playerToEdit != null)
                {
                    var editWindow = new EditP(playerToEdit);
                    editWindow.ShowDialog();

                    LoadPlayersData();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при редактировании игрока: {ex.Message}",
                               "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void DeleteButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (PlayersDataGrid.SelectedItem == null)
                {
                    MessageBox.Show("Выберите команду для удаления", "Предупреждение", MessageBoxButton.OK, MessageBoxImage.Warning);
                    return;
                }

                dynamic selectedTeams = PlayersDataGrid.SelectedItem;
                int playerid = selectedTeams.PlayersId;

                var result = MessageBox.Show("Вы уверены, что хотите удалить эту команду?", "Подтверждение удаления",
                    MessageBoxButton.YesNo, MessageBoxImage.Question);

                if (result == MessageBoxResult.Yes)
                {
                    var playerToDelete = _context.Players.FirstOrDefault(c => c.PlayersId == playerid);
                    if (playerToDelete != null)
                    {
                        _context.Players.Remove(playerToDelete);
                        _context.SaveChanges();
                        LoadPlayersData();
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
    }
}
