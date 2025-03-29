using System;
using System.Globalization;
using System.Windows;
using AppHockeyClub.models;
using AppHockeyClub.listpage;

namespace AppHockeyClub.crud.coaches
{
    public partial class AddC : Window
    {
        private readonly MyDbContext _context = new MyDbContext();

        public AddC()
        {
            InitializeComponent();
            txtBirthDate.ToolTip = "Введите дату в формате ГГГГ-ММ-ДД (например: 2025-12-12)";
        }

        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(txtBirthDate.Text))
                {
                    MessageBox.Show("Укажите дату рождения", "Ошибка",
                                 MessageBoxButton.OK, MessageBoxImage.Warning);
                    return;
                }

                if (!DateOnly.TryParseExact(txtBirthDate.Text, "yyyy-MM-dd",
                    CultureInfo.InvariantCulture, DateTimeStyles.None, out DateOnly birthDate))
                {
                    MessageBox.Show("Неверный формат даты. Используйте формат ГГГГ-ММ-ДД", "Ошибка",
                                 MessageBoxButton.OK, MessageBoxImage.Warning);
                    return;
                }

                if (!int.TryParse(txtExperience.Text, out int experience) || experience < 0)
                {
                    MessageBox.Show("Опыт работы должен быть положительным числом", "Ошибка",
                                 MessageBoxButton.OK, MessageBoxImage.Warning);
                    return;
                }

                var newCoach = new Coach
                {
                    Name = txtName.Text,
                    Surname = txtSurname.Text,
                    Patronymic = string.IsNullOrWhiteSpace(txtPatronymic.Text) ? null : txtPatronymic.Text,
                    DateBirthday = birthDate,
                    ExperienceYears = experience
                };

                _context.Coaches.Add(newCoach);
                _context.SaveChanges();

                MessageBox.Show("Тренер успешно добавлен!", "Успех",
                              MessageBoxButton.OK, MessageBoxImage.Information);
                
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