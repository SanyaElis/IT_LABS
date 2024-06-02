using laba_4.models.Implementation;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace laba_4.models
{
    public abstract class Worker : INotifyPropertyChanged
    {
        protected ILoader Loader;

        private bool isWorking;
        public bool IsWorking
        {
            get => isWorking;
            set
            {
                isWorking = value;
                OnPropertyChanged();
            }
        }

        public string Name { get; set; }
        public string LoaderName => Loader.Name;
        public int LoaderEfficiency => Loader.Efficiency;

        protected Worker(string name, ILoader loader)
        {
            Name = name;
            Loader = loader;
            IsWorking = false;
        }

        public abstract void Work(Furnace furnace);

        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName] string name = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }
    }
}
