using Model;
using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;

namespace ViewModel
{
    public class ViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        // input data
        public string Name { get; set; }
        public decimal CostRate { get; set; }
        public decimal Availability { get; set; }

        private Model.Model model;
        private MyLocation location;
        private ObservableCollection<MyLocation> locations;



        public DataBinding AddLocation { get; set; }
       // public DataBinding GetLocation { get; set; }
        public DataBinding GetAllLocations { get; set; }
        //public DataBinding UpdateLocation { get; set; }
        public DataBinding RemoveLocation { get; set; }
        public DataBinding InitLocations { get; set; }

        public ViewModel()
        {
            model = new Model.Model();   
            Locations = new ObservableCollection<MyLocation>(model.GetAllLocations());
            location = Locations[0];
            AddLocation = new DataBinding(AddNewLocation);
            RemoveLocation = new DataBinding(RemoveChosenLocation);
            InitLocations = new DataBinding(InitList);

        }

        public ViewModel(Model.Model model)
        {
            this.model = model;
            Locations = new ObservableCollection<MyLocation>(model.GetAllLocations());
            location = Locations[0];
            AddLocation = new DataBinding(AddNewLocation);
            RemoveLocation = new DataBinding(RemoveChosenLocation);
            InitLocations = new DataBinding(InitList);
        }

        public ObservableCollection<MyLocation> Locations
        {
            get { return locations; }
            set
            {
                locations = value;
                OnPropertyChanged(nameof(Locations));
            }
        }

        public MyLocation Location
        {
            get { return location; }
            set
            {
                location = value;
                OnPropertyChanged(nameof(Location));
            }
        }

        public Model.Model Model { 
            get { return model; }
            set
            {
                model = value;
                Locations = new ObservableCollection<MyLocation>(value.locations);
            }
        }

        public void InitList()
        {
            Task.Run(() =>
            {
                model.InitLocations();
            });
        }

        public void AddNewLocation()
        {
                Task.Run(() => {
                    model.AddLocation(0, Name, CostRate, Availability, DateTime.Now);
                    Locations = model.locations;
                });
        }

        public void RemoveChosenLocation()
        {
            Task.Run(() => {
                model.DeleteLocation(location.LocationID);
                Locations = model.locations;
            });
        }

        protected void OnPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }
}
