using StudyCardApplication.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace StudyCardApplication.ViewModel.Commands
{
    public class DeleteCardCommand : ICommand
    {
        public EditCardsViewModel VM { get; set; }

        public event EventHandler? CanExecuteChanged
        {
            add { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested -= value; }
        }

        public DeleteCardCommand(EditCardsViewModel vm)
        {
            VM = vm;
        }

        public bool CanExecute(object? parameter)
        {
            var selectedCard = (Card)parameter;
            return selectedCard != null;
        }

        public void Execute(object? parameter)
        {
            var selectedCard = (Card)parameter;
            VM.DeleteCard(selectedCard);
        }
    }
}
