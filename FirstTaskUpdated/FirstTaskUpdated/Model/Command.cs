using FirstTaskUpdated;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace FirstTaskUpdated
{
  
        class RelayCommand : ICommand, INotifyPropertyChanged
        {

            Action<object> _execute;
            Predicate<object> _canExecute;

            public RelayCommand(Action<object> execute, Predicate<object> canExecute)
            {
                if (execute == null)
                    throw new ArgumentNullException("execute");

                _execute = execute;
                _canExecute = canExecute;
            }

            public RelayCommand(Action<object> execute) : this(execute, null)
            {

            }

            public event EventHandler CanExecuteChanged
            {
                add { CommandManager.RequerySuggested += value; }
                remove { CommandManager.RequerySuggested -= value; }
            }

            public bool CanExecute(object parameter)
            {

                return _canExecute == null ? true : _canExecute(parameter);
            }

            public void Execute(object parameter)
            {

                _execute(parameter);
            }
           


            public event PropertyChangedEventHandler PropertyChanged;
            public void OnPropertyChanged(string property)
            {
                if (PropertyChanged != null)
                    PropertyChanged(this, new PropertyChangedEventArgs(property));
            }

            private bool SetProperty<T>(ref T field, T newValue, [CallerMemberName] string propertyName = null)
            {
                if (!Equals(field, newValue))
                {
                    field = newValue;
                    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
                    return true;
                }

                return false;
            }
          



        }



    }
