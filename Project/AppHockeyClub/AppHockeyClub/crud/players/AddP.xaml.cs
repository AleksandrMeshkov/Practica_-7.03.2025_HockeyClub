using System;
using System.Globalization;
using System.Windows;
using AppHockeyClub.listpage;
using AppHockeyClub.models;
using Microsoft.EntityFrameworkCore;

namespace AppHockeyClub.crud.players
{
    public partial class AddP : Window
    {
        private readonly MyDbContext _context = new MyDbContext();

        public AddP()
        {
            InitializeComponent();
        }

        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(txtSurname.Text) ||
                    string.IsNullOrWhiteSpace(txtName.Text))
                {
                    MessageBox.Show("Заполните фамилию и имя игрока!",
                                 "Ошибка", MessageBoxButton.OK, MessageBoxImage.Warning);
                    return;
                }

                if (!DateOnly.TryParseExact(txtBirthDate.Text, "yyyy-MM-dd",
                    CultureInfo.InvariantCulture, DateTimeStyles.None, out DateOnly birthDate))
                {
                    MessageBox.Show("Введите дату в формате ГГГГ-ММ-ДД!",
                                 "Ошибка", MessageBoxButton.OK, MessageBoxImage.Warning);
                    return;
                }

                if (!int.TryParse(txtHeight.Text, out int height) || height <= 0)
                {
                    MessageBox.Show("Укажите корректный рост (положительное число)!",
                                 "Ошибка", MessageBoxButton.OK, MessageBoxImage.Warning);
                    return;
                }

                if (!int.TryParse(txtWeight.Text, out int weight) || weight <= 0)
                {
                    MessageBox.Show("Укажите корректный вес (положительное число)!",
                                 "Ошибка", MessageBoxButton.OK, MessageBoxImage.Warning);
                    return;
                }

                var newPlayer = new Player
                {
                    Surname = txtSurname.Text,
                    Name = txtName.Text,
                    Patronymic = string.IsNullOrWhiteSpace(txtPatronymic.Text) ? null : txtPatronymic.Text,
                    DateBirthday = birthDate,
                    Height = height,
                    Weight = weight
                };

                _context.Players.Add(newPlayer);
                _context.SaveChanges();

                MessageBox.Show("Игрок успешно добавлен!", "Успех",
                              MessageBoxButton.OK, MessageBoxImage.Information);
                PlayersWindow pw = new PlayersWindow();
                pw.Show();
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при сохранении: {ex.Message}", "Ошибка",
                              MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void CancelButton_Click(object sender, RoutedEventArgs e)
        {
            PlayersWindow pw = new PlayersWindow();
            pw.Show();
            this.Close();
        }
    }
}