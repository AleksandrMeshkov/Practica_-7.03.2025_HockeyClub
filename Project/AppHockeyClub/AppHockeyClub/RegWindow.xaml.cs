using AppHockeyClub.models;
using AppHockeyClub.service;
using AppHockeyClub.user_active;
using Microsoft.EntityFrameworkCore;
using System;
using System.Windows;

namespace AppHockeyClub
{
    public partial class RegWindow : Window
    {
        private readonly MyDbContext _context = new MyDbContext();

        public RegWindow()
        {
            InitializeComponent();
        }

        private async void btnRegister_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                
                if (string.IsNullOrWhiteSpace(txtName.Text) ||
                    string.IsNullOrWhiteSpace(txtSurname.Text) ||
                    string.IsNullOrWhiteSpace(txtPhone.Text) ||
                    string.IsNullOrWhiteSpace(txtEmail.Text) ||
                    txtPassword.Password.Length < 6)
                {
                    MessageBox.Show("Пожалуйста, заполните все обязательные поля!\nПароль должен быть не менее 6 символов.",
                        "Ошибка", MessageBoxButton.OK, MessageBoxImage.Warning);
                    return;
                }

                
                if (await _context.Users.AnyAsync(u => u.Email == txtEmail.Text))
                {
                    MessageBox.Show("Пользователь с таким email уже зарегистрирован!",
                        "Ошибка", MessageBoxButton.OK, MessageBoxImage.Warning);
                    return;
                }

               
                var newUser = new User
                {
                    Name = txtName.Text,
                    Surname = txtSurname.Text,
                    Patronymic = string.IsNullOrWhiteSpace(txtPatronymic.Text) ? null : txtPatronymic.Text,
                    Phone = txtPhone.Text,
                    Email = txtEmail.Text,
                    Password = hash.HashPassword(txtPassword.Password)
                };

                
                _context.Users.Add(newUser);
                await _context.SaveChangesAsync();

                MessageBox.Show("Регистрация прошла успешно!", "Успех",
                    MessageBoxButton.OK, MessageBoxImage.Information);

                
                UserMenu mw = new UserMenu();
                mw.Show();
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Произошла ошибка: {ex.Message}", "Ошибка",
                    MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}