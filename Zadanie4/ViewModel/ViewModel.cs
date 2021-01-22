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
 
        public DataBinding AddLocation { get; set; }
       // public DataBinding GetLocation { get; set; }
        public DataBinding GetAllLocations { get; set; }
        //public DataBinding UpdateLocation { get; set; }
        public DataBinding RemoveLocation { get; set; }

        public ViewModel()
        {
            Model = new Model.Model();
            Locations = new ObservableCollection<MyLocation>(model.GetAllLocations());
            AddLocation = new DataBinding(AddNewLocation);
            GetAllLocations = new DataBinding(DisplayAllLocations);
            RemoveLocation = new DataBinding(RemoveChosenLocation);

        }

        public ObservableCollection<MyLocation> Locations
        {
            get { return locations; }
            set
            {
                locations = value;
                OnPropertyChanged();
            }
        }

        public MyLocation Location
        {
            get { return location; }
            set
            {
                location = value;
                OnPropertyChanged();
            }
        }

        public IModel Model { 
            get { return model; }
            set
            {
                model = value;
            }
        }


        public void AddNewLocation()
        {
            if(Name == null || Name == "")
            {

            }
            else
            {
                MyLocation myLocation = new MyLocation();
                myLocation.Name = Name;
                myLocation.LocationID = 23;
                myLocation.ModifiedDate = DateTime.Now;

                Task.Run(() => {
                    
                });
            }
        }

        public void DisplayAllLocations()
        {
            //
        }

        public void RemoveChosenLocation()
        {
            //
        }

        protected void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        private IModel model;
        private MyLocation location;
        private ObservableCollection<MyLocation> locations;

    }
}
