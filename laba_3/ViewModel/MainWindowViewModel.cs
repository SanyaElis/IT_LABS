using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using System.Windows.Input;
using laba_3.Models;
using Microsoft.Win32;

namespace laba_3.ViewModel
{
    public class MainWindowViewModel : INotifyPropertyChanged
    {
        private string _assemblyPath;
        private FigureLoader _loader;
        private Type _selectedType;
        private MethodInfo _selectedMethod;
        private string _methodResult;

        public ObservableCollection<string> FigureNames { get; set; }
        public ObservableCollection<MethodInfo> Methods { get; set; }
        public ObservableCollection<ParameterViewModel> ConstructorParameters { get; set; }
        public ICommand LoadAssemblyCommand { get; set; }
        public ICommand ExecuteMethodCommand { get; set; }

        public string AssemblyPath
        {
            get => _assemblyPath;
            set
            {
                _assemblyPath = value;
                OnPropertyChanged(nameof(AssemblyPath));
            }
        }
    
        public string SelectedFigureName
        {
            get => _selectedType?.Name;
            set
            {
                _selectedType = _loader.GeometricFigureTypes.Find(t => t.Name == value);
                Methods.Clear();
                ConstructorParameters.Clear();
                foreach (var method in _loader.GetMethods(_selectedType))
                {
                    Methods.Add(method);
                }

                var constructor = _selectedType.GetConstructors().First();
                foreach (var param in constructor.GetParameters())
                {
                    ConstructorParameters.Add(new ParameterViewModel { Name = param.Name, Type = param.ParameterType });
                }
            }
        }

        public MethodInfo SelectedMethod
        {
            get => _selectedMethod;
            set
            {
                _selectedMethod = value;
                OnPropertyChanged(nameof(SelectedMethod));
            }
        }
    
        public string MethodResult
        {
            get => _methodResult;
            set
            {
                _methodResult = value;
                OnPropertyChanged(nameof(MethodResult));
            }
        }
    
        public event PropertyChangedEventHandler PropertyChanged;

        public MainWindowViewModel()
        {
            _loader = new FigureLoader();
            FigureNames = new ObservableCollection<string>();
            Methods = new ObservableCollection<MethodInfo>();
            ConstructorParameters = new ObservableCollection<ParameterViewModel>();
            LoadAssemblyCommand = new RelayCommand(LoadAssembly);
            ExecuteMethodCommand = new RelayCommand(ExecuteMethod);
        }

        private void LoadAssembly(object parameter)
        {
            var openFileDialog = new OpenFileDialog();
            if (openFileDialog.ShowDialog() == true)
            {
                AssemblyPath = openFileDialog.FileName;
                _loader.LoadAssembly(AssemblyPath);
                FigureNames.Clear();
                foreach (var type in _loader.GeometricFigureTypes)
                {
                    FigureNames.Add(type.Name);
                }
            }
        }

        private void ExecuteMethod(object parameter)
        {
            if (_selectedType != null && _selectedMethod != null)
            {
                var constructor = _selectedType.GetConstructors().First();
                var constructorArgs = ConstructorParameters.Select(p => ConvertParameterValue(p.Type, p.Value)).ToArray();
                var instance = constructor.Invoke(constructorArgs);
            
                var result = _selectedMethod.Invoke(instance, Array.Empty<object>());
            
                MethodResult = result == null ? "" : result.ToString();
            }
        }

        private object ConvertParameterValue(Type type, object value)
        {
            if (type == typeof(IEnumerable<(double X, double Y)>))
            {
                return ParseVertices((string)value);
            }
            return Convert.ChangeType(value, type);
        }

        private IEnumerable<(double X, double Y)> ParseVertices(string input)
        {
            var vertices = new List<(double, double)>();
            var points = input.Split(';');
            foreach (var point in points)
            {
                var coordinates = point.Split(',');
                if (coordinates.Length == 2 && double.TryParse(coordinates[0], out double x) && double.TryParse(coordinates[1], out double y))
                {
                    vertices.Add((x, y));
                }
            }
            return vertices;
        }
    
        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}