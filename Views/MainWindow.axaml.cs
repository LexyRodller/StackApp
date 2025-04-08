using System;
using Avalonia.Controls;
using Avalonia.Interactivity;
using StackApp.ViewModels;

namespace StackApp
{
    public partial class MainWindow : Window
    {
        private StackViewModel viewModel;

        public MainWindow()
        {
            try
            {
                InitializeComponent();
                viewModel = new StackViewModel();
                DataContext = viewModel;
            }
            catch (Exception ex)
            {
                ShowErrorMessage($"Ошибка: {ex.Message}");
                viewModel = new StackViewModel();
            }
        }

        private void Push_Click(object sender, RoutedEventArgs e)
        {
            if (!string.IsNullOrEmpty(InputBox.Text))
            {
                viewModel.Push(InputBox.Text);
            }
            else
            {
                ShowErrorMessage("Поле ввода не может быть пустым.");
            }
        }

        private void Pop_Click(object sender, RoutedEventArgs e)
        {
            viewModel.Pop();
        }

        private void Clear_Click(object sender, RoutedEventArgs e)
        {
            viewModel.Clear();
        }

        private async void ShowErrorMessage(string message)
        {
            var dialog = new Window
            {
                Title = "Ошибка",
                Content = new TextBlock { Text = message },
                SizeToContent = SizeToContent.WidthAndHeight
            };
            await dialog.ShowDialog(this);
        }
    }
}