using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace laba_4.models.Implementation
{
    public class Furnace : INotifyPropertyChanged
    {
        public event EventHandler MaterialsDepleted;
        public event EventHandler Overheated;
        public event PropertyChangedEventHandler PropertyChanged;

        private int materials;
        private int temperature;
        private bool isOverheated;

        public int Materials
        {
            get => materials;
            set
            {
                materials = Math.Max(value, 0);
                OnPropertyChanged();
                if (materials <= 0)
                {
                    MaterialsDepleted?.Invoke(this, EventArgs.Empty);
                }
            }
        }

        public int Temperature
        {
            get => temperature;
            set
            {
                temperature = value;
                OnPropertyChanged();
                if (temperature > 1000) 
                {
                    IsOverheated = true;
                    Overheated?.Invoke(this, EventArgs.Empty);
                }
            }
        }

        public bool IsOverheated
        {
            get => isOverheated;
            private set
            {
                isOverheated = value;
                OnPropertyChanged();
            }
        }

        public void UseMaterial(int amount)
        {
            Materials -= amount;
            if (Materials <= 0)
            {
                MaterialsDepleted?.Invoke(this, EventArgs.Empty);
            }

            IncreaseTemperature(amount);

            Random rand = new Random();
            if (rand.NextDouble() < 0.05) 
            {
                Temperature += 100;
            }
        }

        private void IncreaseTemperature(int amount)
        {
            Random random = new Random();
            Temperature += amount * random.Next(5); 
        }

        protected void OnPropertyChanged([CallerMemberName] string name = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }
    }
}
