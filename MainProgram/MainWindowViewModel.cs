using ModuleManager;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace MainProgram
{
    public class MainWindowViewModel : INotifyPropertyChanged
    {
        public List<Parameter> parameters { get; set; } = new List<Parameter>();

        public List<IModule> modules { get; set; } = new List<IModule>();


        private ObservableCollection<Parameter> observableResults;

        public ObservableCollection<Parameter> ObservableResults
        {
            get {
                observableResults = observableResults ?? new ObservableCollection<Parameter>();
                return observableResults; }
            set
            {
                observableResults = value;
                OnPropertyChanged("ObservableResults");
            }
        }

        public List<IModule> GetModules()
        {
            var path = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Modules");

            var files = Directory.GetFiles(path, "*.dll").ToList();
            files.ForEach(o =>
            {
                var obj = Assembly.LoadFrom(o);
                var type = obj.GetTypes().Where(q => q.BaseType != null).SingleOrDefault(s => s.BaseType.Name == "ModuleManagerAbs");

                if (type != null)
                {
                    modules.Add(Activator.CreateInstance(type) as IModule);
                }
            });


            return modules;

        }

        private ICommand _moduleMethod;



        public ICommand ModuleMethod
        {
            get
            {
                if (_moduleMethod == null)
                {
                    _moduleMethod = new RelayCommand(
                        param => this.Deneme(),
                        param => this.CanExecute()
                    );
                }
                return _moduleMethod;
            }
        }

        private bool CanExecute()
        {
            return true;
        }

        public void Deneme()
        {
            MessageBox.Show("gd");
        }

        public void ModuleMethod2(IModule module)
        {
            observableResults.Clear();
            module.ModuleCalistir().ForEach(q =>
            {
                observableResults.Add(q);
            });
        }


        public event PropertyChangedEventHandler PropertyChanged;

        public void OnPropertyChanged(string property)
        {

            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(property));

        }

    }
}
