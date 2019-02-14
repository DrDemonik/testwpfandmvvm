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
        TestDB3Entities2 context = new TestDB3Entities2();

        private ObservableCollection<tableForWPFapp> _viewSource { get; set; }
        public ObservableCollection<tableForWPFapp> ViewSource
        {
            get
            {
                return _viewSource;
            }
            set
            {                
                context.tableForWPFapp.Load();
                _viewSource = context.tableForWPFapp.Local;
            }
        }

        public MyViewModel()
        {
            
            //_viewSource = new System.Windows.Data.CollectionViewSource();
            _viewSource = new ObservableCollection<tableForWPFapp>();
            ViewSource = ViewSource;
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
