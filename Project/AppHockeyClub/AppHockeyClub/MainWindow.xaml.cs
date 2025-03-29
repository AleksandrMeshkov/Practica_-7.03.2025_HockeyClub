using AppHockeyClub.models;
using AppHockeyClub.service;
using AppHockeyClub.user_active;
using Microsoft.EntityFrameworkCore;
using System;
using System.Windows;

namespace AppHockeyClub
{
    public partial class MainWindow : Window
    {
        private readonly MyDbContext _context = new MyDbContext();

        public MainWindow()
        {
            InitializeComponent();
        }

        private async void btnLogin_Click_1(object sender, RoutedEventArgs e)
        {
            try
            {
                if (txtUsername.Text.Trim().ToLower() == "admin" &&
                    txtPassword.Password.Trim().ToLower() == "admin")
                {
                    MessageBox.Show($"Добро пожаловать, Администратор!", "Успех",
                        MessageBoxButton.OK, MessageBoxImage.Information);

                    MenuWindow menuw = new MenuWindow();
                    menuw.Show();
                    this.Close();
                    return;
                }

                if (string.IsNullOrWhiteSpace(txtUsername.Text) ||
                    string.IsNullOrWhiteSpace(txtPassword.Password))
                {
                    MessageBox.Show("Введите логин и пароль!", "Ошибка",
                        MessageBoxButton.OK, MessageBoxImage.Warning);
                    return;
                }

                var user = await _context.Users
                    .FirstOrDefaultAsync(u => u.Email == txtUsername.Text.Trim());

                if (user == null)
                {
                    MessageBox.Show("Пользователь не найден!", "Ошибка",
                        MessageBoxButton.OK, MessageBoxImage.Warning);
                    return;
                }

                if (!hash.Verify(txtPassword.Password, user.Password))
                {
                    MessageBox.Show("Неверный пароль!", "Ошибка",
                        MessageBoxButton.OK, MessageBoxImage.Warning);
                    return;
                }

                MessageBox.Show($"Добро пожаловать, {user.Name}!", "Успех",
                    MessageBoxButton.OK, MessageBoxImage.Information);

                UserMenu mw = new UserMenu();
                mw.Show();
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка авторизации: {ex.Message}", "Ошибка",
                    MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void RegisterHyperlink_Click(object sender, RoutedEventArgs e)
        {
            RegWindow regWindow = new RegWindow();
            regWindow.Show();
            this.Close();
        }
    }
}