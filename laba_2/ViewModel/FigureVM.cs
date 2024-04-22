using laba_2.models;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;


namespace laba_2.ViewModel
{
    public class FigureVM : INotifyPropertyChanged
    {
        private Figure selectedFigure;

        public ObservableCollection<Figure> Figures { get; set; }
        public Figure SelectedFigure
        {
            get { return selectedFigure; }
            set
            {
                selectedFigure = value;
                OnPropertyChanged("SelectedFigure");
            }
        }

        public FigureVM()
        {
            Figures = new ObservableCollection<Figure>
            {
                new Line (new Coordinate(0, 0), new Coordinate(2, 2)),
                new Point(new Coordinate(0, 0)),
                new Ellipse(new Coordinate(0, 0), 5, 6),
                new Polygon(new List<Coordinate> {
                    new Coordinate(-2, -2),
                    new Coordinate(-2, 2),
                    new Coordinate(2, 2),
                    new Coordinate(2, -2)
                })
            };
        }

        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }
    }
}
