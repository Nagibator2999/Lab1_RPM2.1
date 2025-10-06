using Lab1_RPM2.Data;
using Lab1_RPM2.Models;
using Lab1_RPM2.View;
using Lab1_RPM2.ViewModel;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Lab1_RPM2
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private MainViewModel _viewModel;

        public MainWindow()
        {
            InitializeComponent();
            _viewModel = new MainViewModel();
            DataContext = _viewModel;
        }

        private void AddPartnerButton_Click(object sender, RoutedEventArgs e)
        {
            var dialog = new AddPartnerWindow();
            if (dialog.ShowDialog() == true)
            {
                var newPartner = ((AddPartnerViewModel)dialog.DataContext).Partner;
                _viewModel.AddPartner(newPartner);
            }
        }

        protected override void OnClosed(EventArgs e)
        {
            _viewModel?.Dispose();
            base.OnClosed(e);
        }
        private void ShowHistory_Click(object sender, RoutedEventArgs e)
        {
            if (listBox.SelectedItem is Partner p)
            {
                new HistoryPartnerWindow(p).ShowDialog();
            }
            else
            {
                MessageBox.Show("Выберите партнёра.");
            }
        }
        //private void DeletePartnerButton_Click(object sender, RoutedEventArgs e)
        //{
        //    if (listBox.SelectedItem is Partner selectedItem)
        //    {

        //        using var db = new AppDBContext();
        //        var itemToDelete = db.Partners.FirstOrDefault(i => i.Inn == selectedItem.Inn);
        //        if (itemToDelete != null)
        //        {
        //            db.Partners.Remove(itemToDelete);
        //            db.SaveChanges();
        //            LoadPartner();
        //        }
        //    }
        //    else
        //    {
        //        MessageBox.Show(
        //            "Пожалуйста, выберите партнера для удаления",
        //            "Не выбрана запись",
        //            MessageBoxButton.OK,
        //            MessageBoxImage.Warning);
        //    }
        //}

        private void listBox_Selected(object sender, RoutedEventArgs e)
        {

        }

        private void listBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            //listBox.SelectedItem = null;
        }
        private void listBox_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            if (listBox.SelectedItem is Partner selectedPartner)
            {
                var editWindow = new AddEditPartner(selectedPartner);
                if (editWindow.ShowDialog() == true)
                {
                    using var context = new AppDBContext();
                    context.Partners.Update(selectedPartner);
                    context.SaveChanges();
                }
            }
        }
    }
}