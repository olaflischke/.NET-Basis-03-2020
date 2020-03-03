using System;

namespace EierfarmBl
{
    public class Ei
    {
        //public double Gewicht2;

        public Ei(Henne mutter)
        {
            this.Legedatum = DateTime.Now;

            this.Mutter = mutter;

            Random random = new Random();
            this.Gewicht = random.Next(45, 80);
            this.Farbe = (EiFarbe)random.Next(Enum.GetNames(typeof(EiFarbe)).Length); // DirectCast, löst Exception aus, wenn Cast fehlschlägt
        }

        public DateTime Legedatum { get; set; }
        public Henne Mutter { get; set; }
        public EiFarbe Farbe { get; set; }

        // Backing Field
        private double _gewicht;

        // Public Property - öffentliche Eigenschaft
        public double Gewicht
        {
            get { return _gewicht; }
            set
            {
                if (value > 0)
                {
                    _gewicht = value;
                }
                else
                {
                    throw new ArgumentOutOfRangeException();
                }
            }
        }

    }

    public enum EiFarbe
    {
        Hell,
        Dunkel,
        Gruen
    }

}
