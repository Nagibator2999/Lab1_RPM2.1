using Lab1_RPM2.Data;
using Lab1_RPM2.Models;
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
        AppDBContext context = new AppDBContext();

        public MainWindow()
        {
            InitializeComponent();
            context.Partners.Load();
            listBox.ItemsSource = context.Partners.Local.Select(p => new {
                 Partner = p,
            Discount = CalculateDiscount(p)
        }).ToList(); 
        }

        //private int CalculateDiscount(Partner partner)
        //{
        //    return 0;
            
        //}
        private double _totalSales;
        public double TotalSales
        {
            get => _totalSales;
            set
            {
                _totalSales = value;
                OnPropertyChanged(nameof(DiscountDisplay));
            }
        }

        public string DiscountDisplay => $"{CalculateDiscount()}%";

        private int CalculateDiscount(Partner partner)
        {
            if (TotalSales < 10_000) return 0;
            if (TotalSales < 50_000) return 5;
            if (TotalSales < 300_000) return 10;
            return 15;
        }
        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

    }
}