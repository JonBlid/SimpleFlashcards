using StudyCardApplication.Model;
using StudyCardApplication.ViewModel.Commands;
using StudyCardApplication.ViewModel.Helpers;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows;
using System.Windows.Media;

namespace StudyCardApplication.ViewModel
{

    public class QuizViewModel : ViewModelBase
    {
        public MainMenuViewModel ParentVMContext { get; set; }

        public ObservableCollection<Card> Cards { get; set; }

        public CardGroup CurrentCardGroup { get; set; }

        public List<Card> questions;

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

        private string givenAnswer;
        public string GivenAnswer
        {
            get { return givenAnswer; }
            set 
            {
                givenAnswer = value;
                OnPropertyChanged(nameof(GivenAnswer));
                // Removes the "Incorrect!" message when the user starts typing.
                if (givenAnswer != string.Empty)
                    AnswerNotice = string.Empty;
            }
        }

        private string answerNotice;
        public string AnswerNotice
        {
            get { return answerNotice; }
            set 
            { 
                answerNotice = value;
                OnPropertyChanged(nameof(AnswerNotice));
            }
        }

        private SolidColorBrush answersColor;
        public SolidColorBrush AnswersColor
        {
            get { return answersColor; }
            set 
            { 
                answersColor = value; 
                OnPropertyChanged(nameof(AnswersColor));
            }
        }

        private bool cardCompleted;
        public bool CardCompleted
        {
            get { return cardCompleted; }
            set 
            { 
                cardCompleted = value;
                OnPropertyChanged(nameof(CardCompleted));
            }
        }

        private Visibility answerBoxVisibility;
        public Visibility AnswerBoxVisibility
        {
            get { return answerBoxVisibility; }
            set 
            { 
                answerBoxVisibility = value;
                OnPropertyChanged(nameof(AnswerBoxVisibility));
            }
        }


        private string nextButtonText;
        public string NextButtonText
        {
            get { return nextButtonText; }
            set 
            { 
                nextButtonText = value;
                OnPropertyChanged(nameof(NextButtonText));
            }
        }

        #region Commands
        public CheckAnswerCommand CheckAnswerCommand { get; set; }
        public NextCardCommand NextCardCommand { get; set; }
        public NavExitQuizCommand NavExitQuizCommand { get; set; }
        #endregion

        public QuizViewModel(CardGroup cardGroup, MainMenuViewModel parentVMContext)
        {
            ParentVMContext = parentVMContext;
            CurrentCardGroup = cardGroup;
            Cards = new ObservableCollection<Card>();
            questions = new List<Card>();

            CheckAnswerCommand = new CheckAnswerCommand(this);
            NextCardCommand = new NextCardCommand(this);
            NavExitQuizCommand = new NavExitQuizCommand(this);

            GetCards();
            RandomizeNewCard();
        }

        public void RandomizeNewCard()
        {
            if(Cards.Count > 0)
            {
                // Copy Cards into a list to pick from then remove picked card
                // so that its less likely the same cards will be picked over and over.
                if (questions.Count == 0) 
                {
                    questions = Cards.ToList<Card>();
                }
                AnswerNotice = string.Empty;

                Random rand = new Random();
                int randomIndex = rand.Next(0, questions.Count);
                SelectedCard = questions[randomIndex];
                questions.RemoveAt(randomIndex);

                CardCompleted = false;
                NextButtonText = "Skip";
                AnswerBoxVisibility = Visibility.Visible;
            }
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

        public void CheckAnswer()
        {
            if(CardCompleted)
            {
                RandomizeNewCard();
                return;
            }

            string[] acceptableAnswers = StringHelper.ConvertStringToArray(selectedCard.AcceptableAnswers);

            foreach (string answer in acceptableAnswers) 
            {
                if(answer.ToLower().Trim() == GivenAnswer.ToLower().Trim())
                {
                    // Correct Answer
                    GivenAnswer = string.Empty;
                    DisplayCorrectAnswers(acceptableAnswers);
                    CardCompleted = true;
                    NextButtonText = "Next";
                    AnswerBoxVisibility = Visibility.Collapsed;
                    return;
                } 
                else
                {
                    // Incorrect Answer
                    DisplayIncorrectAnswer();
                }
            }

            GivenAnswer = string.Empty;
        }

        public void DisplayIncorrectAnswer()
        {
            AnswersColor = new SolidColorBrush(Colors.Red);
            AnswerNotice = "Incorrect!";
        }

        public void DisplayCorrectAnswers(string[] correctAnswers)
        {
            string concatenatedAnswers = string.Empty;

            foreach(string answer in correctAnswers)
            {
                concatenatedAnswers = string.Join(", ", correctAnswers);
            }

            AnswersColor = new SolidColorBrush(Colors.Green);
            AnswerNotice = concatenatedAnswers;
        }

        public void NavigateToMainMenu()
        {
            ParentVMContext.ReturnToMainMenu();
        }
    }
}
