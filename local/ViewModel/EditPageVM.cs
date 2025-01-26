using System;
using System.ComponentModel;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using local.Model;

namespace local.ViewModel
{
    public class EditPageVM : INotifyPropertyChanged
    {
        private Product _selectedProduct;
        public Product SelectedProduct
        {
            get { return _selectedProduct; }
            set
            {
                if (_selectedProduct != value)
                {
                    _selectedProduct = value;
                    OnPropertyChanged(nameof(SelectedProduct));
                }
            }
        }
        public ICommand SaveCommand { get; set; }

        public EditPageVM(Product selectedProduct)
        {
            SelectedProduct = selectedProduct;
            SaveCommand = new RelayCommand(SaveChanges); // Команда для сохранения
        }

        public void SaveChanges(object parameter) 
        {

        }

        public event PropertyChangedEventHandler PropertyChanged;

        // Метод для вызова события PropertyChanged
        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
