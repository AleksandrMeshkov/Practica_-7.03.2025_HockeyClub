using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using AppHockeyClub.models;
using Microsoft.EntityFrameworkCore;
using AppHockeyClub.crud.coaches;

namespace AppHockeyClub.listpage
{
    public partial class CoachesWindow : Window
    {
        private MyDbContext _context = new MyDbContext();

        public CoachesWindow()
        {
            InitializeComponent();
            LoadCoachData();
        }

        private void LoadCoachData()
        {
            try
            {
                _context = new MyDbContext(); 
                var coaches = _context.Coaches
                    .Select(c => new
                    {
                        c.CoachId,
                        c.Surname,
                        c.Name,
                        c.Patronymic,
                        c.DateBirthday,
                        c.ExperienceYears
                    })
                    .ToList();

                CoachesDataGrid.ItemsSource = coaches;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при загрузке данных: {ex.Message}", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void BackButton_Click(object sender, RoutedEventArgs e)
        {
            MenuWindow mw = new MenuWindow();
            mw.Show();
            this.Close();
        }

        private void AddButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                 AddC aw = new AddC();
                if (aw.ShowDialog() == true)
                {
                    LoadCoachData(); 
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при добавлении тренера: {ex.Message}", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void EditButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (CoachesDataGrid.SelectedItem == null)
                {
                    MessageBox.Show("Выберите тренера для редактирования", "Предупреждение", MessageBoxButton.OK, MessageBoxImage.Warning);
                    return;
                }

                dynamic selectedCoach = CoachesDataGrid.SelectedItem;
                int coachId = selectedCoach.CoachId;

                var coachToEdit = _context.Coaches.FirstOrDefault(c => c.CoachId == coachId);
                if (coachToEdit != null)
                {
                    EditC editWindow = new EditC(coachToEdit);
                    if (editWindow.ShowDialog() == true)
                    {
                        LoadCoachData(); 
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при редактировании тренера: {ex.Message}", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void DeleteButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (CoachesDataGrid.SelectedItem == null)
                {
                    MessageBox.Show("Выберите тренера для удаления", "Предупреждение", MessageBoxButton.OK, MessageBoxImage.Warning);
                    return;
                }

                dynamic selectedCoach = CoachesDataGrid.SelectedItem;
                int coachId = selectedCoach.CoachId;

                var result = MessageBox.Show("Вы уверены, что хотите удалить этого тренера?", "Подтверждение удаления",
                    MessageBoxButton.YesNo, MessageBoxImage.Question);

                if (result == MessageBoxResult.Yes)
                {
                    var coachToDelete = _context.Coaches.FirstOrDefault(c => c.CoachId == coachId);
                    if (coachToDelete != null)
                    {
                        _context.Coaches.Remove(coachToDelete);
                        _context.SaveChanges();
                        LoadCoachData(); 
                        MessageBox.Show("Тренер успешно удален", "Успех", MessageBoxButton.OK, MessageBoxImage.Information);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при удалении тренера: {ex.Message}", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}