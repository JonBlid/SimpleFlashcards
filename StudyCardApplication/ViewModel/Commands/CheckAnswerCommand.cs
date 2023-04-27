using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace StudyCardApplication.ViewModel.Commands
{
    public class CheckAnswerCommand : ICommand
    {
        public QuizViewModel VM { get; set; }

        public event EventHandler? CanExecuteChanged
        {
            add { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested -= value; }
        }

        public CheckAnswerCommand(QuizViewModel vm)
        {
            VM = vm;
        }

        public bool CanExecute(object? parameter)
        {
            string givenAnswer = (string)parameter;
            return !string.IsNullOrEmpty(givenAnswer);
        }

        public void Execute(object? parameter)
        {
            VM.CheckAnswer();
        }
    }
}
