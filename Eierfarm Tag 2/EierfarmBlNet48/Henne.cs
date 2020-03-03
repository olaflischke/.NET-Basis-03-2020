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
    public class Henne : Gefluegel
    {

        /// <summary>
        /// Erzeugt eine Henne-Instanz
        /// </summary>
        public Henne():base("Neues Huhn")
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
        /// Die Henne legt ein Ei.
        /// </summary>
        public override void EiLegen()
        {
            if (this.Gewicht > 1500)
            {
                Ei ei = new Ei(this);
                this.Eier.Add(ei);
                //this.Gewicht = this.Gewicht - ei.Gewicht;
                this.Gewicht -= ei.Gewicht;
            }
        }

        public override void Fressen()
        {
            if (this.Gewicht < 3000)
            {
                this.Gewicht += 100;
            }
        }
    }
}