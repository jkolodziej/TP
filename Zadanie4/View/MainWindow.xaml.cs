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
            DataContext = viewModel;

        }

        /*protected override void OnInitialized(EventArgs e)
        {
            base.OnInitialized(e);
            ViewModel.ViewModel _vm = (ViewModel.ViewModel)DataContext;
        }*/
    }
}

