using StudyCardApplication.Model;
using StudyCardApplication.ViewModel.Commands;
using StudyCardApplication.ViewModel.Helpers;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudyCardApplication.ViewModel
{
    public class EditCardsViewModel : ViewModelBase
    {
        public MainMenuViewModel ParentVMContext { get; set; }

        public ObservableCollection<Card> Cards { get; set; }

        public CardGroup CurrentCardGroup { get; set; }

        private Card selectedCard;
        public Card SelectedCard
        {
            get { return selectedCard; }
            set 
            { 
                selectedCard = value; 
                OnPropertyChanged(nameof(SelectedCard));
            }
        }

        #region Commands
        public NewCardCommand NewCardCommand { get; set; }
        public SaveCardGroupCommand SaveCardGroupCommand { get; set; }
        public DeleteCardCommand DeleteCardCommand { get; set; }
        public NavExitEditCommand NavExitEditCommand { get; set; }
        #endregion

        public EditCardsViewModel(CardGroup cardGroup, MainMenuViewModel parentVMContext)
        {
            CurrentCardGroup = cardGroup;
            ParentVMContext = parentVMContext;
            Cards = new ObservableCollection<Card>();
            GetCards();

            NewCardCommand = new NewCardCommand(this);
            SaveCardGroupCommand = new SaveCardGroupCommand(this);
            DeleteCardCommand = new DeleteCardCommand(this);
            NavExitEditCommand = new NavExitEditCommand(this);
        }

        public void GetCards()
        {
            if (CurrentCardGroup != null)
            {
                var cards = DatabaseHelper.Read<Card>().Where(c => c.CardGroupID == CurrentCardGroup.ID).ToList();

                Cards.Clear();
                foreach (var card in cards)
                {
                    Cards.Add(card);
                }
            }
        }

        public void CreateNewCard()
        {
            // Creates temporary card. Must be explicitly saved to get stored in the database. 
            Cards.Add(new Card()
            {
                Question = "Question",
                AcceptableAnswers = "Answer1, Answer2, Answer3",
                CardGroupID = CurrentCardGroup.ID
            });
        }

        public void SaveCardGroup()
        {
            DatabaseHelper.Update(CurrentCardGroup);
            foreach (var card in Cards)
            {
                bool updatedSucessfully = DatabaseHelper.Update(card);
                if (!updatedSucessfully)
                {
                    DatabaseHelper.Insert(card);
                }

            }
            GetCards();
        }

        public void NavigateToMainMenu()
        {
            if (ParentVMContext != null)
            {
                ParentVMContext.ReturnToMainMenu();
            }
        }

        public void DeleteCard(Card selectedCard)
        {
            if (selectedCard != null)
            {
                DatabaseHelper.Delete(selectedCard);
                Cards.Remove(selectedCard);
            }
        }
    }
}
