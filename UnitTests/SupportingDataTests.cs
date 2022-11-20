using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenCdsi.SupportingData;
using OpenCdsi;

namespace Cdsi.UnitTests
{
    [TestClass]
    public class SupportingDataTests
    {
        [TestMethod]
        public void AntigenNames()
        {
            var names = Data.Antigen.Keys;
            Assert.AreEqual(26, names.Count);
        }

        [TestMethod]
        public void CanReadAntigenData()
        {
            var key = "Cholera";
            var data = Data.Antigen[key];
            Assert.AreEqual(key, data.series[0].targetDisease);
        }

        [TestMethod]
        public void CanReadcheduleData()
        {
            var data = Data.Schedule;
            Assert.IsInstanceOfType(data, typeof(scheduleSupportingData));
        }
    }
}
