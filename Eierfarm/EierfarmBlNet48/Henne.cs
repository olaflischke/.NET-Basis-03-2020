using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace EierfarmBl
{
    /// <summary>
    /// Stellt eine Henne dar.
    /// </summary>
    public class Henne : INotifyPropertyChanged
    {

        public event PropertyChangedEventHandler PropertyChanged;

        public event EventHandler<GefluegelEventArgs> EigenschaftGeaendert;

        private void OnEigenschaftGeaendert([CallerMemberName]string propertyName="")
        {
            if (EigenschaftGeaendert != null)
            {
                EigenschaftGeaendert(this, new GefluegelEventArgs(propertyName));
            }
        }

        private void OnPropertyChanged([CallerMemberName]string propertyName="")
        {
            if (PropertyChanged!=null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }

        /// <summary>
        /// Erzeugt eine Henne-Instanz
        /// </summary>
        public Henne()
        {
            this.Id = Guid.NewGuid();
            this.Gewicht = 1000;
            //this.Name = "Neues Huhn";
        }

        public Henne(string name) : this()
        {
            this.Name = name;
        }

        /// <summary>
        /// Gibt die ID (GUID) der Henne zurück oder legt sie fest.
        /// </summary>
        public Guid Id { get; set; }

        private double _gewicht;

        public double Gewicht
        {
            get
            {
                return _gewicht;
            }
            set
            {
                _gewicht = value;
                OnEigenschaftGeaendert();
                OnPropertyChanged();
            }
        }

        private string _name = "Neues Huhn";
        public string Name
        {
            get
            {
                return _name;
            }
            set
            {
                _name = value;
                OnEigenschaftGeaendert();
                OnPropertyChanged();
            }
        }
        // Auto-Property-Initializer
        public ObservableCollection<Ei> Eier { get; set; } = new ObservableCollection<Ei>();


        /// <summary>
        /// Die Henne legt ein Ei.
        /// </summary>
        public void EiLegen()
        {
            if (this.Gewicht > 1500)
            {
                Ei ei = new Ei(this);
                this.Eier.Add(ei);
                //this.Gewicht = this.Gewicht - ei.Gewicht;
                this.Gewicht -= ei.Gewicht;
            }
        }

        public void Fressen()
        {
            if (this.Gewicht < 3000)
            {
                this.Gewicht += 100;
            }
        }
    }
}