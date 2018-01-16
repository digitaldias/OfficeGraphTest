using System;
using System.Windows.Input;

namespace OfficeGraphExplorer.ViewModels
{
    public class RelayCommand : ICommand
    {
        public event EventHandler CanExecuteChanged;

        private readonly Action _executeAction;
        private readonly Func<bool> _canExecuteFunction;

        
        public RelayCommand(Action executeAction, Func<bool> canExecuteFunction = null)
        {
            _executeAction = executeAction;
            _canExecuteFunction = canExecuteFunction;
        }


        public bool CanExecute(object parameter)
        {
            if (_canExecuteFunction == null)
                return true;

            return _canExecuteFunction.Invoke();
        }


        /// <summary>
        /// </summary>
        /// <param name="parameter">Always ignored, do nothing with this</param>
        public void Execute(object parameter)
        {
            _executeAction.Invoke();
        }
    }
}
