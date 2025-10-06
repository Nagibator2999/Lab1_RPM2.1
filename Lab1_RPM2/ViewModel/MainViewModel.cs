using Lab1_RPM2.Data;
using Lab1_RPM2.Models;
using Microsoft.EntityFrameworkCore;
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
        private readonly AppDBContext _context = new AppDBContext();

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
            LoadPartners();
        }

        private void LoadPartners()
        {
            var partners = _context.Partners
                .Include(p => p.ProductPartners)
                .ToList();

            Partners = new ObservableCollection<Partner>((IEnumerable<Partner>)partners);
        }

        public void AddPartner(Partner newPartner)
        {
            _context.Partners.Add(newPartner);
            _context.SaveChanges();

            Partners.Add(newPartner);
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public void Dispose()
        {
            _context?.Dispose();
        }
        //private ObservableCollection<Partner> _partners;

        //public ObservableCollection<Partner> Partners
        //{
        //    get => _partners;
        //    set
        //    {
        //        _partners = value;
        //        OnPropertyChanged(nameof(Partners));
        //    }
        //}

        //public MainViewModel()
        //{
        //    LoadPartnersWithSalesByInn();
        //}

        //private void LoadPartnersWithSalesByInn()
        //{
        //    using var context = new AppDBContext();         
        //}

        //public event PropertyChangedEventHandler PropertyChanged;

        //protected virtual void OnPropertyChanged(string propertyName)
        //{
        //    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        //}
    }
}
