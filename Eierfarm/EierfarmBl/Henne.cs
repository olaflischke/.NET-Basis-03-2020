using System;
using System.Collections.Generic;

namespace EierfarmBl
{
    /// <summary>
    /// Stellt eine Henne dar.
    /// </summary>
    public class Henne
    {
        /// <summary>
        /// Erzeugt eine Henne-Instanz
        /// </summary>
        public Henne()
        {
            this.Id = Guid.NewGuid();
            this.Gewicht = 1000;
            this.Name = "Neues Huhn";
        }

        public Henne(string name) : this()
        {
            this.Name = name;
        }

        /// <summary>
        /// Gibt die ID (GUID) der Henne zurück oder legt sie fest.
        /// </summary>
        public Guid Id { get; set; }
        public double Gewicht { get; set; }
        public string Name { get; set; } //= "Neues Huhn";

        // Auto-Property-Initializer
        public List<Ei> Eier { get; set; } = new List<Ei>();

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