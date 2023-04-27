using StudyCardApplication.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace StudyCardApplication.ViewModel.Commands
{
    public class DeleteCardGroupCommand : ICommand
    {
        public MainMenuViewModel VM { get; set; }

        public event EventHandler? CanExecuteChanged
        {
            add { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested -= value; }
        }

        public DeleteCardGroupCommand(MainMenuViewModel vm)
        {
            VM = vm;
        }

        public bool CanExecute(object? parameter)
        {
            var selectedCardGroup = (CardGroup)parameter;
            return selectedCardGroup != null;
        }

        public void Execute(object? parameter)
        {
            var selectedCardGroup = (CardGroup)parameter;
            VM.DeleteCardGroup(selectedCardGroup);
        }
    }
}
