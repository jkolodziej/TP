using System.Windows;
using ViewModel;

namespace View
{
    class NewWindow : INewWindow, IMessageBox
    {
        public void OpenNewWindow(ViewModel.ViewModel viewModel)
        {
            LocationDetails window = new LocationDetails();
            window.DataContext = viewModel;
            window.Show();
        }

        public void Show(string message, string title)
        {
            MessageBox.Show(message, title);
        }
    }
}
