using System;
using System.Globalization;
using System.Windows;
using AppHockeyClub.models;
using Microsoft.EntityFrameworkCore;

namespace AppHockeyClub.crud.players
{
    public partial class EditP : Window
    {
        private readonly MyDbContext _context = new MyDbContext();
        private readonly Player _player;

        public bool IsSaved { get; private set; } = false;

        public EditP(Player playerToEdit)
        {
            InitializeComponent();

            _player = playerToEdit;

            txtSurname.Text = _player.Surname;
            txtName.Text = _player.Name;
            txtPatronymic.Text = _player.Patronymic;
            txtBirthDate.Text = _player.DateBirthday.ToString("yyyy-MM-dd");
            txtHeight.Text = _player.Height.ToString();
            txtWeight.Text = _player.Weight.ToString();
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

                _player.Surname = txtSurname.Text;
                _player.Name = txtName.Text;
                _player.Patronymic = string.IsNullOrWhiteSpace(txtPatronymic.Text) ? null : txtPatronymic.Text;
                _player.DateBirthday = birthDate;
                _player.Height = height;
                _player.Weight = weight;

                _context.Entry(_player).State = EntityState.Modified;
                _context.SaveChanges();

                IsSaved = true;
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
            this.Close();
        }
    }
}