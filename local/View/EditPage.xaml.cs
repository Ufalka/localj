using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using local.Model;
using local.ViewModel;

namespace local.View
{
    /// <summary>
    /// Interaction logic for EditPage.xaml
    /// </summary>
    public partial class EditPage : Page
    {
        public EditPage(Product selectedProduct)
        {
            InitializeComponent();
            var viewModel = new EditPageVM(selectedProduct);
            DataContext = viewModel; // Привязываем ViewModel
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (!name.Text.Equals("") && !description.Text.Equals("") && !price.Text.Equals("") &&
                (price.Text.All(char.IsDigit) && Convert.ToInt32(price.Text) > 0))//Проверка на корректность ввода данных
            {
                NavigationService.GoBack();
            }
            else
            {
                MessageBox.Show("Заполните все поля или поменяйте значение!");
            }

        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            NavigationService.GoBack(); //Выход обратно на MainPage
        }
    }
}
