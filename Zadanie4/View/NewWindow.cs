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
