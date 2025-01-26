using System.Windows;
using System.Windows.Controls;
using local.ViewModel;

namespace local.View
{
    public partial class MainPage : Page
    {
        public MainPage()
        {
            InitializeComponent();
            DataContext = new MainVM();  // Привязываем ViewModel
        }

        private void EditCommand_Executed(object sender, RoutedEventArgs e)
        {
            if (DataContext is MainVM viewModel && viewModel.SelectedProduct != null)
            {
                // Переход на страницу редактирования
                this.NavigationService.Navigate(new EditPage(viewModel.SelectedProduct));
            }
        }
    }
}
