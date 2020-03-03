using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;

namespace EierfarmBl
{
    public abstract class Gefluegel : INotifyPropertyChanged, IEileger
    {
        public Gefluegel(string name)
        {
            this.Name = name;
        }


        private double _gewicht;

        private string _name ;

        public event PropertyChangedEventHandler PropertyChanged;

        public event EventHandler<GefluegelEventArgs> EigenschaftGeaendert;
        public ObservableCollection<Ei> Eier { get; set; } = new ObservableCollection<Ei>();

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

        /// <summary>
        /// Gibt die ID (GUID) der Henne zurück oder legt sie fest.
        /// </summary>
        public Guid Id { get; set; }

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

        public DateTime Schluepfdatum { get;  set; }

        private void OnEigenschaftGeaendert([CallerMemberName]string propertyName = "")
        {
            if (EigenschaftGeaendert != null)
            {
                EigenschaftGeaendert(this, new GefluegelEventArgs(propertyName));
            }
        }

        protected void OnPropertyChanged([CallerMemberName]string propertyName = "")
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }

        public abstract void EiLegen();
        public abstract void Fressen();

    }
}