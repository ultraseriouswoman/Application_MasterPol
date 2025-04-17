using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace FinalExamVariation.Utilities
{
    public class ViewModelCommand : ICommand
    {
        private Action<object> _execute;
        private Predicate<object>? _canexecute;

        public ViewModelCommand(Action<object> execute)
        {
            _execute = execute;
            _canexecute = null;
        }
        public ViewModelCommand(Action<object> execute, Predicate<object> canexecute)
        {
            _execute = execute;
            _canexecute = canexecute;
        }

        public event EventHandler? CanExecuteChanged
        {
            add { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested -= value; }
        }

        public bool CanExecute(object? parameter) => _canexecute == null?true: _canexecute(parameter);

        public void Execute(object? parameter) => _execute(parameter);
    }
}
