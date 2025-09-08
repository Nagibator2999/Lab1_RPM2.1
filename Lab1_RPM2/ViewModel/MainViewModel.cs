using Lab1_RPM2.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Markup;

namespace Lab1_RPM2.ViewModel
{
    public class MainViewModel : INotifyPropertyChanged
    {
        private ObservableCollection<Partner> _partners;

        public ObservableCollection<Partner> Partners
        {
            get => _partners;
            set
            {
                _partners = value;
                OnPropertyChanged(nameof(Partners));
            }
        }

        public MainViewModel()
        {
            LoadPartnersWithSalesByInn();
        }

        private void LoadPartnersWithSalesByInn()
        {
            using var context = new PartnerContext();      

            var partners = context.Partners.ToList();

            foreach (var partner in partners)
            {
                var totalSales = context.ProductPartners
                    .Where(pp => pp.Inn == partner.Inn) 
                    .Sum(pp => pp.Quantity);

                partner.TotalSales = totalSales;
            }

            Partners = new ObservableCollection<Partner>(partners);
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
