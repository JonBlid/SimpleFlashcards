using StudyCardApplication.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace StudyCardApplication.ViewModel.Commands
{
    public class NavEditCardsViewCommand : ICommand
    {
        public MainMenuViewModel VM { get; set; }

        public event EventHandler? CanExecuteChanged
        {
            add { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested -= value; }
        }

        public NavEditCardsViewCommand(MainMenuViewModel vm)
        {
            VM = vm;
        }

        public bool CanExecute(object? parameter)
        {
            var param = (CardGroup)parameter;
            return (param != null);
        }

        public void Execute(object? parameter)
        {
            VM.NavigateToEditView();
        }
    }
}
