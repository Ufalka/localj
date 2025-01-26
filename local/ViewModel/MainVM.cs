using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows.Input;
using System.Windows.Navigation;
using local.Model;
using local.View;

namespace local.ViewModel
{
    public class MainVM
    {
        public ObservableCollection<Product> Products { get; set; }
        public ICommand AddCommand { get; set; }
        public ICommand DeleteCommand { get; set; }

        public ICommand EditCommand { get; set; }

        public Product SelectedProduct { get; set; } //Выбранный товар
        public MainVM()
        {
            Products = new ObservableCollection<Product> 
            {
                new Product //Появляется при запуске приложения для возможности сразу перейти в режим редактирования
                {
                    Id = 1,
                    Name = "Название товара",
                    Description = "Описание товара",
                    Price = 100
                }
            };

            AddCommand = new RelayCommand(_ => Products.Add(new Product //Добавляет новую строку
            {
                Id = Products.Count + 1,
                Name = "Название товара",
                Description = "Описание товара",
                Price = 150
            }));

            DeleteCommand = new RelayCommand(_ => //Удаляет выбранную строку
            {
                if (SelectedProduct != null)
                {
                    Products.Remove(SelectedProduct);
                }
            });

            EditCommand = new RelayCommand(_ =>
            {
                if (SelectedProduct != null)
                {
                    // Переход на страницу редактирования
                    // Используем NavigationService из MainPage
                    var navigationService = (App.Current.MainWindow as MainWindow)?.MainFrame.NavigationService;
                    if (navigationService != null)
                    {
                        navigationService.Navigate(new EditPage(SelectedProduct));
                    }
                }
            });
        }
    }
}
