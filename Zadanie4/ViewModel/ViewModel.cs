using Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace ViewModel
{
    class ViewModel : INotifyPropertyChanged
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

        private IModel model;

        public ViewModel(IModel model)
        {
            this.model = model;
            AddLocation = new DataBinding(AddNewLocation);
            GetAllLocations = new DataBinding(DisplayAllLocations);
            RemoveLocation = new DataBinding(RemoveChosenLocation);

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



    }
}
