using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace TradingDayDal
{
    public class Archive
    {
        public Archive(string url)
        {
            this.TradingDays = GetData(url);
        }

        private List<TradingDay> GetData(string url)
        {

            List<TradingDay> days = new List<TradingDay>();

            XDocument document = XDocument.Load(url);

            var qKnoten = from nd in document.Root.Descendants().AsParallel()
                          where nd.Name.LocalName == "Cube" && nd.Attributes().Any(at => at.Name=="time") //CheckName(at, "time"))
                          select new TradingDay() { Date = Convert.ToDateTime(nd.Attribute("time").Value) };

            days = qKnoten.ToList();

            //foreach (XElement item in qKnoten)
            //{
            //    TradingDay day = new TradingDay() { Date = Convert.ToDateTime(item.Attribute("time").Value) };
            //    days.Add(day);
            //}

            return days;
        }

        private bool CheckName(XAttribute at, string name)
        {
            if (at.Name == name) return true;
            return false;
        }

        public List<TradingDay> TradingDays { get; set; } = new List<TradingDay>();

    }
}
