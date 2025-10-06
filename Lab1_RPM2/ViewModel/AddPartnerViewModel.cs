using Lab1_RPM2.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab1_RPM2.ViewModel
{
    public class AddPartnerViewModel
    {
        public Partner Partner { get; set; } = new Partner();

        public ObservableCollection<string> PartnerTypes { get; } = new ObservableCollection<string>
        {
            "ООО",
            "ОАО",
            "ЗАО",
            "ПАО"
        };
    }
}
