using ModuleManager;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
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
using System.Windows.Shapes;

namespace WpfCustomControlLibrary1
{
    /// <summary>
    /// Interaction logic for Window1.xaml
    /// </summary>
    public partial class Window1 : Window
    {
        public static List<Parameter> list = new List<Parameter>();

        WindowModelView modelView = new WindowModelView();

        public Window1()
        {
            InitializeComponent();
            list.ForEach(o =>
            {
                modelView.list.Add(o);
            });
            DataContext = modelView;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (!String.IsNullOrEmpty(textBox1.Text) && !String.IsNullOrEmpty(textBox2.Text))
                modelView.list.Add(new Parameter { Key = textBox1.Text, Value = textBox2.Text });            
        }

        private void Window_Closing(object sender, CancelEventArgs e)
        {
            list = modelView.list.ToList();
        }
    }


    public class WindowModelView : INotifyPropertyChanged
    {
        private ObservableCollection<Parameter> _list;
        public ObservableCollection<Parameter> list
        {
            get { _list = _list ?? new ObservableCollection<Parameter>(); return _list; }

            set
            {
                _list = value;
                OnPropertyChanged("list");
            }

        }

        public event PropertyChangedEventHandler PropertyChanged;

        public void OnPropertyChanged(string property)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(property));
        }
    }
}
