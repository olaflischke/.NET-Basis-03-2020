using System;
using System.Collections.Generic;

namespace TradingDayDal
{
    public class TradingDay
    {
        public DateTime Date { get; set; }
        public List<Currency> Currencies { get; set; }
    }
}