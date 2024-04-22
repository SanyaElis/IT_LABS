using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace laba_2.models
{
    public abstract class Figure : INotifyPropertyChanged
    {
        protected Coordinate center;
        protected string name;
        public double Area => CountArea();

        public string Description => GenerateDescription();
        protected abstract double CountArea();
        protected abstract string GenerateDescription();

        protected string description;


        protected abstract Coordinate[] GetBounds();



        public string Bounds
        {
            get
            {
                Coordinate[] bounds = GetBounds();
                if (bounds == null || bounds.Length != 4)
                {
                    return null;
                }
                return $"{bounds[0]}\n{bounds[1]}\n{bounds[2]}\n{bounds[3]}";
            }
        }
        protected Figure()
        {

        }

        public string Name
        {
            get
            { return name; }
            set
            {
                name = value;
                OnPropertyChanged("Name");
            }
        }
        public string Center
        {
            get { return center.ToString(); }
            /*set
            {
                center = value;
                OnPropertyChanged("Center");
            }*/
        }

        //public abstract Coordinate[] GetBounds();


        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }
    }
}
