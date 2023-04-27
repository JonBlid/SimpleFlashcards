using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace StudyCardApplication.ViewModel.Commands
{
    public class NavExitEditCommand : ICommand
    {
        public EditCardsViewModel VM { get; set; }

        public event EventHandler? CanExecuteChanged;

        public NavExitEditCommand(EditCardsViewModel vm)
        {
            VM = vm;
        }

        public bool CanExecute(object? parameter)
        {
            return true;
        }

        public void Execute(object? parameter)
        {
            VM.NavigateToMainMenu();
        }
    }
}
