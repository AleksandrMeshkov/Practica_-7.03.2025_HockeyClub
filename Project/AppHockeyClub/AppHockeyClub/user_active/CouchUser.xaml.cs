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

namespace AppHockeyClub.user_active
{
    /// <summary>
    /// Логика взаимодействия для CouchUser.xaml
    /// </summary>
    public partial class CouchUser : Window
    {
        private MyDbContext _context = new MyDbContext();
        public CouchUser()
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
            UserMenu mw = new UserMenu();
            mw.Show();
            this.Close();
        }
    }
}
