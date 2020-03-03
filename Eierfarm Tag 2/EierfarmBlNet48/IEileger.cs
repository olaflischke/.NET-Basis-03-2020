using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;

namespace EierfarmBl
{
    public interface IEileger : INotifyPropertyChanged
    {
        double Gewicht { get; set; }
        ObservableCollection<Ei> Eier { get; set; }

        void EiLegen();
        void Fressen();
    }
}