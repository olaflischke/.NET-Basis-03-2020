using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;

namespace EierfarmBl
{
    public class Schnabeltier : Saeugetier, IEileger
    {
        public double Gewicht { get; set; }

        public ObservableCollection<Ei> Eier { get; set; }

        public event PropertyChangedEventHandler PropertyChanged;

        public void EiLegen()
        {
            if (this.Gewicht>2000)
            {
                Ei ei = new Ei(this);
                Eier.Add(ei);
                this.Gewicht -= ei.Gewicht;
            }
        }

        public void Fressen()
        {
            if (this.Gewicht<5000)
            {
                this.Gewicht += 500;
            }
        }

        public override void Saeugen()
        {
            throw new NotImplementedException();
        }
    }
}