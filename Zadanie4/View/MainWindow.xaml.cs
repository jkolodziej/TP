using System;
using System.Windows;


namespace View
{
    /// <summary>
    /// Logika interakcji dla klasy MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            var viewModel = new ViewModel.ViewModel();
            viewModel.LocationDetails = new NewWindow(); 
            DataContext = viewModel;

        }
    }
}

