using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

using System.ComponentModel;
using System.Runtime.CompilerServices;


namespace WpfAppTask1.ViemModel
{
    public class MyViemModel /*: Application*/: INotifyPropertyChanged
    {
        private string _str1;
        public string Str1 { get { return _str1;  } set { _str1 = value; OnPropertyChanged("Str1"); } }

        private string _str2;
        public string Str2 { get { return _str2; } set { _str2 = value; OnPropertyChanged("Str2"); } }

        private string _str3;
        public string Str3 { get { return _str3; } set { _str3 = value; OnPropertyChanged("Str3"); } }

        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        private ICommand _cliccomand;
        public ICommand MyClickComand
        {
            get
            {
                _cliccomand = new RelayCommand(obj => { new Model().ShowMessage(Str1, Str2, Str3); });
                return _cliccomand;
            }
        }

        private ICommand _setText;
        public ICommand SetText
        {
            get
            {
                _setText = new RelayCommand(obj => { Str1 = new Model().SetText(); Str2= new Model().SetText(); Str3= new Model().SetText(); });
                return _setText;
            }
        }

    }

    public class Model /*: INotifyPropertyChanged*//*: ICommand*/
    {
        public void ShowMessage(string Str1, string Str2, string Str3)
        {
            MessageBox.Show(Str1 + Str2 + Str3);
        }

        public string SetText()
        {
            string str = "Привет!";
            return str;
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
