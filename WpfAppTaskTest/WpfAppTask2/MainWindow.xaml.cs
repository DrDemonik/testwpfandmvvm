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

using System.Data.Entity;

using System.Linq.Expressions;

namespace WpfAppTask2
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        //TestDB3Entities context = new TestDB3Entities();



        public MainWindow()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {

            //System.Windows.Data.CollectionViewSource tableForWPFappViewSource = ((System.Windows.Data.CollectionViewSource)(this.FindResource("tableForWPFappViewSource")));
            //context.tableForWPFapp.Load();
            // Загрузите данные, установив свойство CollectionViewSource.Source:
            //tableForWPFappViewSource.Source = context.tableForWPFapp.Local;

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            //context.SaveChanges();
        }
    }
}
