using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using ViewModel;

namespace View
{
    class NewWindow : INewWindow
    {
        public void OpenNewWindow(ViewModel.ViewModel viewModel)
        {
            LocationDetails window = new LocationDetails();
            window.DataContext = viewModel;
            window.Show();
        }
    }
}
