using Lab1_RPM2.ViewModel;
using System;
using System.Collections.Generic;
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

namespace Lab1_RPM2.View
{
    /// <summary>
    /// Логика взаимодействия для AddPartnerWindow.xaml
    /// </summary>
    public partial class AddPartnerWindow : Window
    {
        public AddPartnerWindow()
        {
            InitializeComponent();
            DataContext = new AddPartnerViewModel();
        }
        private void OnSaveClick(object sender, RoutedEventArgs e)
        {
            this.Focus();

            var vm = (AddPartnerViewModel)DataContext;
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
}
