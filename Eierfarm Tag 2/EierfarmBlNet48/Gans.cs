using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EierfarmBl
{
    public class Gans : Gefluegel
    {
        public Gans():base("Neue Gans")
        {
            this.Gewicht = 2000;
            this.Id = Guid.NewGuid();
        }

        private int _steuerkurs;

        public int Steuerkurs
        {
            get
            {
                return _steuerkurs;
            }
            set
            {
                _steuerkurs = value;
                OnPropertyChanged();
            }
        }

        public override void EiLegen()
        {
            if (this.Gewicht>2500)
            {
                Ei ei = new Ei(this);
                this.Gewicht -= ei.Gewicht;
                this.Eier.Add(ei);
            }
        }

        public void Fliegen()
        {
            throw new System.NotImplementedException();
        }

        public override void Fressen()
        {
            if (this.Gewicht<5000)
            {
                this.Gewicht += 250;
            }
        }
    }
}