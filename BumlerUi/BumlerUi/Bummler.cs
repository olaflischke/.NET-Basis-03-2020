using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BumlerUi
{
    public class Bummler
    {
        public string Bummeln()
        {
            double erg = Wurzelsumme(1e9);
            return "Fertig mit Bummeln!";
        }

        public async Task<string> BummelnAsnyc()
        {
            double erg = await Task.Run(() => Wurzelsumme(1e9));
            return "Fertig mit Bummeln!";
        }

        public string Troedeln()
        {
            double erg = Wurzelsumme(3e9);
            return "Fertig mit Trödeln!";
        }

        public async Task<string> TroedelnAsync()
        {
            double erg = await Task.Run(() => Wurzelsumme(1e9));
            return "Fertig mit Trödeln!";
        }


        private double Wurzelsumme(double zahl)
        {
            double sum = 0;

            for (int i = 0; i < zahl; i++)
            {
                sum += Math.Sqrt(i);
            }

            return sum;
        }
    }
}
