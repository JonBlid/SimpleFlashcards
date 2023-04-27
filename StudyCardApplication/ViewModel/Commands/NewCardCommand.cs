using System;
using System.Windows.Input;

namespace StudyCardApplication.ViewModel.Commands
{
    public class NewCardCommand : ICommand
    {
        public EditCardsViewModel VM { get; set; }

        public event EventHandler? CanExecuteChanged;

        public NewCardCommand(EditCardsViewModel vm)
        {
            VM = vm;
        }

        public bool CanExecute(object? parameter)
        {
            return true;
        }

        public void Execute(object? parameter)
        {
            VM.CreateNewCard();
        }
    }
}
