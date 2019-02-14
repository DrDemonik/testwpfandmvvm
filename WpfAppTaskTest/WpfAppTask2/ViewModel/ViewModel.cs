using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Windows.Input;
using System.Collections.ObjectModel;

using System.Data.Entity;
using WpfAppTask2.Model;

namespace WpfAppTask2
{
    class MyViewModel
    {
        TestDB3Entities context = new TestDB3Entities();

        private System.Windows.Data.CollectionViewSource _viewSource;
        public System.Windows.Data.CollectionViewSource ViewSource
        {
            get
            {
                return _viewSource;
            }
            set
            {
                context.tableForWPFapp.Load();
                _viewSource.Source = context.tableForWPFapp.Local;
            }
        }


    }

    public class RelayCommand : ICommand
    {
        private Action<object> execute;
        private Func<object, bool> canExecute;

        public event EventHandler CanExecuteChanged
        {
            add { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested -= value; }
        }

        public RelayCommand(Action<object> execute, Func<object, bool> canExecute = null)
        {
            this.execute = execute;
            this.canExecute = canExecute;
        }

        public bool CanExecute(object parameter)
        {
            return this.canExecute == null || this.canExecute(parameter);
        }

        public void Execute(object parameter)
        {
            this.execute(parameter);
        }
    }
}
