using Model;
using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Threading.Tasks;
using System.Windows;

namespace ViewModel
{
    public class ViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        public string Name { get; set; }
        public decimal CostRate { get; set; }
        public decimal Availability { get; set; }
        public bool Async { get; set; }
        public bool DisplayMessageBoxes { get; set; }
        public INewWindow LocationDetails { get; set; }
        public DataBinding AddLocation { get; set; }
        public DataBinding GetLocation { get; set; }
        public DataBinding GetAllLocations { get; set; }
        public DataBinding UpdateLocation { get; set; }
        public DataBinding RemoveLocation { get; set; }
        public DataBinding InitLocations { get; set; }

        public ViewModel()
        {
            model = new Model.Model();
            Locations = new ObservableCollection<MyLocation>(model.GetAllLocations());
            location = Locations[0];
            DisplayMessageBoxes = true;
            AddLocation = new DataBinding(AddNewLocation);
            GetLocation = new DataBinding(GoToLocationDetails);
            GetAllLocations = new DataBinding(() => Model = new Model.Model());
            UpdateLocation = new DataBinding(UpdateChosenLocation);
            RemoveLocation = new DataBinding(RemoveChosenLocation);
        }

        public ViewModel(IModel model)
        {
            this.model = model;
            Locations = new ObservableCollection<MyLocation>(model.GetAllLocations());
            location = Locations[0];
            DisplayMessageBoxes = true;
            AddLocation = new DataBinding(AddNewLocation);
            GetLocation = new DataBinding(GoToLocationDetails);
            GetAllLocations = new DataBinding(() => Locations = Locations = new ObservableCollection<MyLocation>(model.GetAllLocations()));
            UpdateLocation = new DataBinding(UpdateChosenLocation);
            RemoveLocation = new DataBinding(RemoveChosenLocation);
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

        public ObservableCollection<MyLocation> LocationsInfo
        {
            get { return locationsInfo; }
            set
            {
                locationsInfo = value;
                OnPropertyChanged(nameof(LocationsInfo));
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

        public MyLocation LocationInfo
        {
            get { return locationInfo; }
            set
            {
                locationInfo = value;
                OnPropertyChanged(nameof(LocationInfo));
            }
        }

        public IModel Model
        {
            get { return model; }
            set
            {
                model = value;
                Locations = new ObservableCollection<MyLocation>(value.GetAllLocations());
            }
        }

        private IModel model;
        private MyLocation location;
        private MyLocation locationInfo;
        private ObservableCollection<MyLocation> locations;
        private ObservableCollection<MyLocation> locationsInfo;


        public void runAsynchronously(Action action)
        {
            if (Async)
            {
                Task.Run(action);
            }
            else
            {
                action();
            }
        }

        public void AddNewLocation()
        {
            if(Name == null || Name == "" || CostRate < 0 || Availability < 0)
            {
                if (DisplayMessageBoxes)
                {
                    MessageBox.Show("You provided incorrect value", "Error message");
                }             
                else
                {
                    throw new FormatException();
                }
            }
            else
            {
                runAsynchronously(() =>
                {
                    model.AddLocation(0, Name, CostRate, Availability, DateTime.Now);
                    GetAllLocations.Execute(null);
                });
            }
        }

        public void RemoveChosenLocation()
        {
            if (location == null)
            {
                if (DisplayMessageBoxes)
                {
                    MessageBox.Show("Choose element to remove", "Error message");
                }
                else
                {
                    throw new NullReferenceException();
                }    
            }
            else
            {
                runAsynchronously(() =>
                {
                    model.DeleteLocation(location.LocationID);
                    GetAllLocations.Execute(null);

                });
            }
        }

        public void UpdateChosenLocation()
        {
            if (location == null)
            {
                if (DisplayMessageBoxes)
                {
                    MessageBox.Show("Choose element to update", "Error message");
                }
                else
                {
                    throw new NullReferenceException();
                }
            }
            else if (Name == null || Name == "" || CostRate < 0 || Availability < 0)
            {
                if (DisplayMessageBoxes)
                {
                    MessageBox.Show("You provided incorrect value", "Error message");
                }
                else
                {
                    throw new FormatException();
                }               
            }
            else
            {
                runAsynchronously(() =>
                {
                    model.UpdateLocation(location.LocationID, Name, CostRate, Availability, DateTime.Now);
                    GetAllLocations.Execute(null);
                });

            }
        }

        public void GoToLocationDetails()
        {
            if(location == null)
            {
                if (DisplayMessageBoxes)
                {
                    MessageBox.Show("Choose element to display details", "Error message");
                }
                else
                {
                    throw new NullReferenceException();
                }              
            }
            else
            {
                runAsynchronously(() =>
                {
                    LocationsInfo = new ObservableCollection<MyLocation>();
                    LocationsInfo.Add(model.GetLocation(location.LocationID));
                    LocationInfo = model.GetLocation(location.LocationID);
                });
                LocationDetails.OpenNewWindow(this);
            }
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
