
using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Data;
using lb8.Models;

namespace lb8.ViewModels
{
    public class CandidateViewModel : INotifyPropertyChanged
    {
        public ObservableCollection<Candidate> Candidates { get; set; }
        public ICollectionView CandidatesView { get; }
        private Candidate? selectedCandidate;
        private string searchText = "";
        private string selectedEducation = "Усі";
        private string selectedLanguage = "Усі";
        private string selectedComputer = "Усі";
        private string selectedRecommendations = "Усі";
        private string selectedMinimumExperience = "0";

        public Candidate? SelectedCandidate
        {
            get => selectedCandidate;
            set
            {
                selectedCandidate = value;
                OnPropertyChanged();
            }
        }

        public string SearchText
        {
            get => searchText;
            set
            {
                searchText = value;
                OnPropertyChanged();
                RefreshFilter();
            }
        }

        public string SelectedEducation
        {
            get => selectedEducation;
            set
            {
                selectedEducation = value;
                OnPropertyChanged();
                RefreshFilter();
            }
        }

        public string SelectedLanguage
        {
            get => selectedLanguage;
            set
            {
                selectedLanguage = value;
                OnPropertyChanged();
                RefreshFilter();
            }
        }

        public string SelectedComputer
        {
            get => selectedComputer;
            set
            {
                selectedComputer = value;
                OnPropertyChanged();
                RefreshFilter();
            }
        }

        public string SelectedRecommendations
        {
            get => selectedRecommendations;
            set
            {
                selectedRecommendations = value;
                OnPropertyChanged();
                RefreshFilter();
            }
        }

        public string SelectedMinimumExperience
        {
            get => selectedMinimumExperience;
            set
            {
                selectedMinimumExperience = value;
                OnPropertyChanged();
                RefreshFilter();
            }
        }

        public CandidateViewModel()
        {
            Candidates = new ObservableCollection<Candidate>();
            CandidatesView = CollectionViewSource.GetDefaultView(Candidates);
            CandidatesView.Filter = FilterCandidates;
        }

        private bool FilterCandidates(object obj)
        {
            if (obj is not Candidate candidate)
                return false;

            if (!string.IsNullOrWhiteSpace(SearchText) && !candidate.FullName.Contains(SearchText.Trim(), StringComparison.OrdinalIgnoreCase))
            {
                return false;
            }

            if (SelectedEducation != "Усі" && candidate.Education != SelectedEducation)
            {
                return false;
            }

            if (SelectedLanguage != "Усі")
            {
                bool hasLanguage = SelectedLanguage switch
                {
                    "Англійська" => candidate.English,
                    "Німецька" => candidate.German,
                    "Французька" => candidate.French,
                    _ => true
                };

                if (!hasLanguage)
                    return false;
            }

            if (SelectedComputer == "Так" && !candidate.ComputerSkills)
            {
                return false;
            }

            if (SelectedComputer == "Ні" && candidate.ComputerSkills)
            {
                return false;
            }

            if (SelectedRecommendations == "Так" && !candidate.Recommendations)
            {
                return false;
            }

            if (SelectedRecommendations == "Ні" && candidate.Recommendations)
            {
                return false;
            }

            if (int.TryParse(SelectedMinimumExperience, out int experience))
            {
                if (candidate.WorkExperience < experience)
                    return false;
            }
            return true;
        }

        public void RefreshFilter()
        {
            CandidatesView.Refresh();
        }

        public event PropertyChangedEventHandler? PropertyChanged;
        private void OnPropertyChanged([CallerMemberName] string? propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
