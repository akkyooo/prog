
using System;
using System.Linq;
using System.Windows;
using lb8.Models;
using lb8.Services;

namespace lb8.Views
{
    public partial class CandidateWindow : Window
    {
        private readonly Candidate candidate;
        public Candidate Result => candidate;
        public CandidateWindow(Candidate? source = null)
        {
            InitializeComponent();
            candidate = source?.Copy() ?? new Candidate();
            DataContext = candidate;
            ExperienceBox.ItemsSource = Enumerable.Range(0, 61);
            BirthDatePicker.DisplayDateStart = new DateTime(1940, 1, 1);
            BirthDatePicker.DisplayDateEnd = DateTime.Today;
            Title = source == null ? "Додавання кандидата" : "Редагування кандидата";
        }

        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            string? error = CandidateValidation.Validate(candidate);
            if (error != null)
            {
                MessageBox.Show(error, "Помилка введення",
                    MessageBoxButton.OK,
                    MessageBoxImage.Warning);
                return;
            }

            candidate.FullName = candidate.FullName.Trim();
            DialogResult = true;
        }
    }
}
