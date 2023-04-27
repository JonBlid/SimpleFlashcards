using StudyCardApplication.Model;
using StudyCardApplication.ViewModel.Commands;
using StudyCardApplication.ViewModel.Helpers;
using System;
using System.Collections.ObjectModel;

namespace StudyCardApplication.ViewModel
{
    public class MainMenuViewModel : ViewModelBase
    {
        public ObservableCollection<CardGroup> CardGroups { get; set; }

        private CardGroup selectedCardGroup;
        public CardGroup SelectedCardGroup
        {
            get { return selectedCardGroup; }
            set 
            { 
                selectedCardGroup = value;
                OnPropertyChanged(nameof(SelectedCardGroup));
            }
        }

        private ViewModelBase selectedViewModel;
        public ViewModelBase SelectedViewModel
        {
            get { return selectedViewModel; }
            set 
            { 
                selectedViewModel = value; 
                OnPropertyChanged(nameof(SelectedViewModel));
            }
        }

        #region Commands
        public NavCardViewCommand NavCardViewCommand { get; set; }
        public NavEditCardsViewCommand NavEditCardsViewCommand { get; set; }
        public CreateCardGroupCommand CreateCardGroupCommand { get; set; }
        public DeleteCardGroupCommand DeleteCardGroupCommand { get; set; }
        #endregion

        public MainMenuViewModel()
        {
            SelectedViewModel = this;
            CardGroups = new ObservableCollection<CardGroup>();
            GetCardGroups();

            NavCardViewCommand = new NavCardViewCommand(this);
            NavEditCardsViewCommand = new NavEditCardsViewCommand(this);
            CreateCardGroupCommand = new CreateCardGroupCommand(this);
            DeleteCardGroupCommand = new DeleteCardGroupCommand(this);
        }

        public void NavigateToCardView()
        {
            SelectedViewModel = new QuizViewModel(SelectedCardGroup, this);
        }

        public void GetCardGroups()
        {
            var cardGroups = DatabaseHelper.Read<CardGroup>();

            CardGroups.Clear();
            foreach (var cardGroup in cardGroups)
            {
                CardGroups.Add(cardGroup);
            }
        }

        public void CreateNewCardGroup()
        {
            DatabaseHelper.Insert(
                new CardGroup() 
                { 
                    Name="Quiz Deck Name"
                });

            GetCardGroups();
            SelectedCardGroup = CardGroups[CardGroups.Count - 1];
            NavigateToEditView();
        }

        public void DeleteCardGroup(CardGroup selectedCardGroup)
        {
            DatabaseHelper.Delete(selectedCardGroup);
            GetCardGroups();
        }

        public void NavigateToEditView()
        {
            SelectedViewModel = new EditCardsViewModel(SelectedCardGroup, this);
        }

        public void ReturnToMainMenu()
        {
            SelectedViewModel = this;
            GetCardGroups();
        }
    }
}
