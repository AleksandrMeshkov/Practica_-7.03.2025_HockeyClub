using System;
using System.Globalization;
using System.Windows;
using AppHockeyClub.models;
using Microsoft.EntityFrameworkCore;

namespace AppHockeyClub.crud.coaches
{
    public partial class EditC : Window
    {
        private readonly MyDbContext _context = new MyDbContext();
        private readonly Coach _coach;

        public bool IsSaved { get; private set; } = false;

        public EditC(Coach coachToEdit)
        {
            InitializeComponent();

            _coach = coachToEdit;
            DataContext = _coach;

            txtBirthday.Text = $"{_coach.DateBirthday.Year}-{_coach.DateBirthday.Month:D2}-{_coach.DateBirthday.Day:D2}";
        }

        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(_coach.Surname) ||
                    string.IsNullOrWhiteSpace(_coach.Name) ||
                    string.IsNullOrWhiteSpace(txtBirthday.Text))
                {
                    MessageBox.Show("Заполните обязательные поля (Фамилия, Имя, Дата рождения)!",
                                 "Ошибка", MessageBoxButton.OK, MessageBoxImage.Warning);
                    return;
                }

                if (!DateOnly.TryParseExact(txtBirthday.Text, "yyyy-MM-dd",
                    CultureInfo.InvariantCulture, DateTimeStyles.None, out DateOnly birthDate))
                {
                    MessageBox.Show("Введите дату в формате ГГГГ-ММ-ДД!",
                                 "Ошибка", MessageBoxButton.OK, MessageBoxImage.Warning);
                    return;
                }
                _coach.DateBirthday = birthDate;

                if (!int.TryParse(_coach.ExperienceYears.ToString(), out int experience) || experience < 0)
                {
                    MessageBox.Show("Опыт работы должен быть положительным числом!",
                                 "Ошибка", MessageBoxButton.OK, MessageBoxImage.Warning);
                    return;
                }

                _context.Entry(_coach).State = EntityState.Modified;
                _context.SaveChanges();

                IsSaved = true;
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при сохранении: {ex.Message}",
                              "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void CancelButton_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}