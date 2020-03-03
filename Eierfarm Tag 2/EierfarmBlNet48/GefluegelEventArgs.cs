using System;

namespace EierfarmBl
{
    public class GefluegelEventArgs:EventArgs
    {
        public GefluegelEventArgs(string propName)
        {
            this.GeaenderteProperty = propName;
        }
        public string GeaenderteProperty { get; set; }

    }
}