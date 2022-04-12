using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Hangman.Commands
{
    class RelayCommand : ICommand
    {
        //private Action<object> _execute;
        //private Func<object, bool> _canExecute;
        //private Action addPlayer;

        //public event EventHandler CanExecuteChanged
        //{
        //    add { CommandManager.RequerySuggested += value; }
        //    remove { CommandManager.RequerySuggested -= value; }
        //}

        //public RelayCommand(Action<object> execute, Func<object, bool> canExecute = null)
        //{
        //    _execute = execute;
        //    _canExecute = canExecute;
        //}

        //public RelayCommand(Action addPlayer)
        //{
        //    this.addPlayer = addPlayer;
        //}

        //public bool CanExecute(object parameter)
        //{
        //    return _canExecute == null || _canExecute(parameter);
        //}

        //public void Execute(object parameter)
        //{
        //    _execute(parameter);
        //}

        private Action commandTask;

        public RelayCommand(Action workToDo)
        {
            commandTask = workToDo;
        }

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public event EventHandler CanExecuteChanged
        {
            add
            {
                CommandManager.RequerySuggested += value;
            }

            remove
            {
                CommandManager.RequerySuggested -= value;
            }
        }

        public void Execute(object parameter)
        {
            commandTask();
        }
    }
}
