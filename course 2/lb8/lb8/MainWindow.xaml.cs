
using System.Windows;
using System.Windows.Input;
using lb8.Models;
using lb8.ViewModels;
using lb8.Views;

namespace lb8
{
    public partial class MainWindow : Window
    {
        private readonly CandidateViewModel viewModel;
        public MainWindow()
        {
            InitializeComponent();
            viewModel = new CandidateViewModel();
            DataContext = viewModel;
        }

        private void AddButton_Click(object sender, RoutedEventArgs e)
        {
            CandidateWindow window = new CandidateWindow
            {
                Owner = this
            };

            if (window.ShowDialog() == true)
            {
                viewModel.Candidates.Add(window.Result);
                viewModel.RefreshFilter();
            }
        }

        private void EditButton_Click(object sender, RoutedEventArgs e)
        {
            EditSelectedCandidate();
        }

        private void CandidatesGrid_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            if (viewModel.SelectedCandidate != null)
                EditSelectedCandidate();
        }

        private void EditSelectedCandidate()
        {
            Candidate? selected = viewModel.SelectedCandidate;
            if (selected == null)
            {
                MessageBox.Show("Оберіть кандидата для редагування.", "Повідомлення",
                    MessageBoxButton.OK,
                    MessageBoxImage.Information);

                return;
            }

            CandidateWindow window = new CandidateWindow(selected)
            {
                Owner = this
            };

            if (window.ShowDialog() == true)
            {
                selected.CopyFrom(window.Result);
                viewModel.RefreshFilter();
            }
        }

        private void DeleteButton_Click(object sender, RoutedEventArgs e)
        {
            Candidate? selected = viewModel.SelectedCandidate;
            if (selected == null)
            {
                MessageBox.Show("Оберіть кандидата для видалення.", "Повідомлення",
                    MessageBoxButton.OK,
                    MessageBoxImage.Information);

                return;
            }

            MessageBoxResult result = MessageBox.Show("Ви дійсно бажаєте видалити цього кандидата?", "Підтвердження видалення",
                MessageBoxButton.YesNo,
                MessageBoxImage.Question);

            if (result == MessageBoxResult.Yes)
            {
                viewModel.Candidates.Remove(selected);
                viewModel.SelectedCandidate = null;
            }
        }
    }
}
