using System;
using System.Windows.Input;

namespace StudyCardApplication.ViewModel.Commands
{
    public class NavCardViewCommand : ICommand
    {
        public MainMenuViewModel VM { get; set; }

        public event EventHandler? CanExecuteChanged
        {
            add { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested -= value; }
        }

        public NavCardViewCommand(MainMenuViewModel vm)
        {
            VM = vm;
        }

        public bool CanExecute(object? parameter)
        {
            return VM.SelectedCardGroup != null;
        }

        public void Execute(object? parameter)
        {
            VM.NavigateToCardView();
        }
    }
}
