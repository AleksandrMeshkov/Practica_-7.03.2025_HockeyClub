using System;
using System.Linq;
using System.Windows;
using AppHockeyClub.listpage;
using AppHockeyClub.models;
using Microsoft.EntityFrameworkCore;

namespace AppHockeyClub.crud.teams
{
    public partial class EditT : Window
    {
        private readonly Team _teamToEdit;
        private readonly MyDbContext _db;

        public EditT(Team team)
        {
            InitializeComponent();
            _db = new MyDbContext();
            _teamToEdit = _db.Teams
                .Include(t => t.Coach)
                .FirstOrDefault(t => t.TeamId == team.TeamId);

            LoadData();
        }

        private void LoadData()
        {
            TeamIdTextBox.Text = _teamToEdit.TeamId.ToString();
            NameTextBox.Text = _teamToEdit.Name;
            QuantityPlayersTextBox.Text = _teamToEdit.QuantityPlayers.ToString();

            var coaches = _db.Coaches
                .Select(c => new
                {
                    c.CoachId,
                    FullName = $"{c.Surname} {c.Name}"
                })
                .ToList();

            CoachComboBox.ItemsSource = coaches;
            CoachComboBox.DisplayMemberPath = "FullName";
            CoachComboBox.SelectedValuePath = "CoachId";
            CoachComboBox.SelectedValue = _teamToEdit.CoachId;
        }

        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(NameTextBox.Text))
            {
                MessageBox.Show("Введите название команды");
                return;
            }

            if (!int.TryParse(QuantityPlayersTextBox.Text, out _))
            {
                MessageBox.Show("Введите число игроков");
                return;
            }

            if (CoachComboBox.SelectedValue == null)
            {
                MessageBox.Show("Выберите тренера");
                return;
            }

            _teamToEdit.Name = NameTextBox.Text;
            _teamToEdit.QuantityPlayers = int.Parse(QuantityPlayersTextBox.Text);
            _teamToEdit.CoachId = (int)CoachComboBox.SelectedValue;

            try
            {
                _db.SaveChanges();
                MessageBox.Show("Данные сохранены!");

                TeamsWindow teamsWindow = new TeamsWindow();
                teamsWindow.Show();
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка сохранения: {ex.Message}");
            }
        }

        private void BackButton_Click(object sender, RoutedEventArgs e)
        {
            TeamsWindow teamsWindow = new TeamsWindow();
            teamsWindow.Show();
            this.Close();
        }
    }
}