using Lab1_RPM2.Models;
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
    /// Логика взаимодействия для HistoryPartnerWindow.xaml
    /// </summary>
    public partial class HistoryPartnerWindow : Window
    {
        private Partner partner;

        public HistoryPartnerWindow(Partner p)
        {
            InitializeComponent();
            partner = p;
            var viewModel = new PartnerHistoryViewModel(partner);
            DataContext = viewModel;
            PartnerTitleText.Text = $"Партнёр: {viewModel.PartnerTitle}";
        }
        private void OnCancelClick(object sender, RoutedEventArgs e)
        {
            DialogResult = false;
            Close();
        }
    }
}
