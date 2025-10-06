using Lab1_RPM2.Data;
using Lab1_RPM2.Models;
using Lab1_RPM2.ViewModel;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
using System.Windows.Shapes;
using System.Xml.Linq;

namespace Lab1_RPM2.View
{
    /// <summary>
    /// Логика взаимодействия для AddEditPartner.xaml
    /// </summary>
    public partial class AddEditPartner : Window
    {
        public AddEditPartner(Partner partnerToEdit)
        {
            InitializeComponent();

            DataContext = new EditViewModel(partnerToEdit);
        }

        private void OnSaveClick(object sender, RoutedEventArgs e)
        {
            var vm = (EditViewModel)DataContext;
            if (string.IsNullOrWhiteSpace(vm.Partner?.TitlePa))
            {
                MessageBox.Show("Пожалуйста, укажите наименование партнёра.", "Внимание",
                    MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            DialogResult = true;
            Close();
        }

        private void OnCancelClick(object sender, RoutedEventArgs e)
        {
            DialogResult = false;
            Close();
        }
    }
    //public ObservableCollection<string> TypePartners { get; set; }
    //public AddEditPartner()
    //{
    //    InitializeComponent();
    //    var context = new AppDBContext();
    //    TypePartners = new(context.Partners.Select(x => x.TypePartner).Distinct());
    //}
    //private void LogoutButton_Click(object sender, RoutedEventArgs e)
    //{
    //    new MainWindow().Show();
    //    this.Close();
    //}
    //private void OnSaveClick(object sender, RoutedEventArgs e)
    //{           
    //    var window = Window.GetWindow(this);
    //    if (window != null)
    //    {
    //        window.Focus();
    //    }

    //    DialogResult = true;
    //    Close();             
    //}

    //private void OnCancelClick(object sender, RoutedEventArgs e)
    //{
    //    DialogResult = false;
    //    Close();
    //}
}

