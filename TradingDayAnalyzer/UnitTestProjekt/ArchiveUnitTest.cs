using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TradingDayDal;

namespace UnitTestProjekt
{
    [TestClass]
    public class ArchiveUnitTest
    {
        string url = "https://www.ecb.europa.eu/stats/eurofxref/eurofxref-hist-90d.xml";

        [TestMethod]
        public void ArchiveInit()
        {

            Archive archive = new Archive(url);

            Assert.AreEqual(GetNumberOfTimeAttributes(url), archive.TradingDays.Count);
        }

        private int GetNumberOfTimeAttributes(string url)
        {
            return 61;
        }
    }
}
