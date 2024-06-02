using laba_4.models;
using laba_4.models.Implementation;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Input;

namespace laba_4.ViewModel
{
    public class MainWindowViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        private Furnace furnace;
        private ObservableCollection<Worker> workers;
        private ICommand startFurnaceCommand;
        private ICommand addWorkerCommand;
        private string workerName;
        private ComboBoxItem selectedWorkerType;
        private ComboBoxItem selectedTool;
        private bool isStarted;
        private string status;

        public Furnace Furnace
        {
            get => furnace;
            set
            {
                furnace = value;
                OnPropertyChanged();
            }
        }

        public ObservableCollection<Worker> Workers
        {
            get => workers;
            set
            {
                workers = value;
                OnPropertyChanged();
            }
        }

        public string WorkerName
        {
            get => workerName;
            set
            {
                workerName = value;
                OnPropertyChanged();
            }
        }

        public string Status
        {
            get => status;
            set
            {
                status = value;
                OnPropertyChanged();
            }
        }

        public ComboBoxItem SelectedWorkerType
        {
            get => selectedWorkerType;
            set
            {
                selectedWorkerType = value;
                OnPropertyChanged();
            }
        }

        public ComboBoxItem SelectedTool
        {
            get => selectedTool;
            set
            {
                selectedTool = value;
                OnPropertyChanged();
            }
        }

        public bool IsStarted
        {
            get => isStarted;
            set
            {
                isStarted = value;
                OnPropertyChanged();
                OnPropertyChanged(nameof(IsNotStarted));
            }
        }

        public bool IsNotStarted => !IsStarted;

        public ICommand StartFurnaceCommand
        {
            get
            {
                if (startFurnaceCommand == null)
                {
                    startFurnaceCommand = new RelayCommand(
                        param => StartFurnace(),
                        param => CanStartFurnace());
                }
                return startFurnaceCommand;
            }
        }

        public ICommand AddWorkerCommand
        {
            get
            {
                if (addWorkerCommand == null)
                {
                    addWorkerCommand = new RelayCommand(
                        param => AddWorker(),
                        param => CanAddWorker());
                }
                return addWorkerCommand;
            }
        }

        public MainWindowViewModel()
        {
            Status = "Ожидание запуска доменной печи";

            Furnace = new Furnace()
            {
                Materials = 1000,
                Temperature = 0
            };

            Workers = new ObservableCollection<Worker>();
            IsStarted = false;

            Furnace.MaterialsDepleted += (s, e) => Status = "Закончился материал";
            Furnace.Overheated += (s, e) => Status = "Перегрев доменной печи";
        }

        public void AddWorker()
        {
            ILoader tool;
            switch (selectedTool.Tag.ToString())
            {
                case "BeginnerLoader":
                    tool =new BeginnerLoader();
                    break;
                case "Loader":
                    tool = new Loader();
                    break;
                case "AdvancedLoader":
                    tool = new AdvancedLoader();
                    break;
                default:
                    throw new ArgumentException("Invalid tool type.");
            };

            if (tool != null)
            {
                workers.Add(new LoaderWorker(workerName, tool));
            }

            WorkerName = string.Empty;
            SelectedWorkerType = null;
            SelectedTool = null;
        }

        private void StartFurnace()
        {
            Status = "Доменная печь запущена";

            IsStarted = true;
            foreach (var worker in Workers)
            {
                ThreadPool.QueueUserWorkItem(x => worker.Work(Furnace));
            }
        }

        private bool CanStartFurnace()
        {
            return Furnace != null && Workers.Count > 0;
        }

        private bool CanAddWorker()
        {
            return !string.IsNullOrWhiteSpace(workerName) && selectedTool != null;
        }


        protected void OnPropertyChanged([CallerMemberName] string name = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }
    }
}
